using API.Contracts;
using API.DTOs.DepartmentData;
using API.DTOs.JobData;
using API.Models;
using API.Utilities.Handlers;
using API.Utilities.Message;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository departmentRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IAccountRepository accountRepository;
    private readonly IJobRepository jobRepository;

    public DepartmentController(
        IDepartmentRepository departmentRepository, 
        IEmployeeRepository employeeRepository,
        IJobRepository jobRepository,
        IAccountRepository accountRepository)
    {
        this.departmentRepository = departmentRepository;
        this.employeeRepository = employeeRepository;
        this.jobRepository = jobRepository;
        this.accountRepository = accountRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            // Get All Department Data
            var getDepartments = departmentRepository.GetAll();

            // Getting data error handling
            if (!getDepartments.IsSuccess)
            {
                throw new Exception(getDepartments.Exception);
            }

            // Empty Data Response
            if (!getDepartments.Data.Any())
            {
                return NotFound(ErrorResponse.DataNotFound("No department data"));
            }

            // Success Response
            var departmentDTOs = getDepartments.Data.Select(item => (DepartmentDTO)item);

            return Ok(new ResponseOkHandler<IEnumerable<DepartmentDTO>>(Message.SuccessRetrieve, departmentDTOs));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpPost]
    public IActionResult Create(CreateDepartmentDTO departmentDTO)
    {
        try
        {
            // Create New Department
            var createDepartment = departmentRepository.Create(departmentDTO);

            // Error Handling
            if (!createDepartment.IsSuccess)
            {
                throw new Exception(createDepartment.Exception);
            }

            // Success Response
            return Ok(OkResponse.SuccessRetrieveData());
        }
        catch(Exception ex)
        {
            if (ex.Message.Contains("name"))
            {
                return Conflict(ErrorResponse.Conflict("Department name already registered, try another one."));
            }

            if (ex.Message.Contains("code"))
            {
                return Conflict(ErrorResponse.Conflict("Department code already registered, try another one."));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpPut]
    public IActionResult Update(DepartmentDTO departmentDTO)
    {
        try
        {
            // Get Department Data
            var getDepartment = departmentRepository.TakeById(departmentDTO.Guid);

            if (!getDepartment.IsSuccess)
            {
                throw new Exception(getDepartment.Exception);
            }

            if(getDepartment.Data is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Department data not found for the specified ID."));
            }

            // Update Department Data
            getDepartment.Data.Code = departmentDTO.Code;
            getDepartment.Data.Name = departmentDTO.Name;
            getDepartment.Data.ManagerGuid = departmentDTO.ManagerGuid;
            getDepartment.Data.ModifiedDate = DateTime.Now;

            var updateDepartment = departmentRepository.Update(getDepartment.Data);

            if (!updateDepartment.IsSuccess)
            {
                throw new Exception(updateDepartment.Exception);
            }

            // Success Response

            return Ok(OkResponse.SuccessRetrieveData());
        }
        catch(Exception ex)
        {
            if (ex.Message.Contains("name"))
            {
                return Conflict(ErrorResponse.Conflict("Department name already registered, try another one."));
            }

            if (ex.Message.Contains("code"))
            {
                return Conflict(ErrorResponse.Conflict("Department code already registered, try another one."));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        try
        {
            // Get Department Data by Guid
            var getDepartment = departmentRepository.TakeById(guid);

            if (!getDepartment.IsSuccess)
            {
                throw new Exception(getDepartment.Exception);
            }

            if(getDepartment.Data is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Department data with specified ID not found."));
            }

            // Delete Department Data
            var deleteDepartment = departmentRepository.Delete(getDepartment.Data);

            if (!deleteDepartment.IsSuccess)
            {
                throw new Exception(deleteDepartment.Exception);
            }

            // Send success response
            return Ok(OkResponse.DataDeletedSuccessfully());
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("conflicted"))
            {
                return Conflict(ErrorResponse.Conflict("Department cannot be deleted as it contains associated employee data."));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        try
        {
            // Get Department Data
            var getDepartment = departmentRepository.TakeById(guid);

            if (!getDepartment.IsSuccess)
            {
                throw new Exception(getDepartment.Exception);
            }

            if(getDepartment.Data is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Department data for the specified ID not found."));
            }

            // Create Department Detail DTO
            var departmentDetailDTO = (DepartmentDetailDTO) getDepartment.Data;

            // Get Department Employee
            var getDepartmentEmployee = employeeRepository.GetByDepartment(guid);

            if (!getDepartmentEmployee.IsSuccess)
            {
                throw new Exception(getDepartmentEmployee.Exception);
            }

            // Success Response With Empty Department Employees

            if(getDepartmentEmployee.Data is null)
            {
                return Ok(new ResponseOkHandler<DepartmentDetailDTO>(Message.SuccessRetrieve, departmentDetailDTO));
            }

            // Merge Employees Data
            var getAccounts = accountRepository.GetAll();
            
            if (!getAccounts.IsSuccess)
            {
                throw new Exception(getAccounts.Exception);
            }

            var getJobs = jobRepository.GetAll();

            if (!getJobs.IsSuccess)
            {
                throw new Exception(getAccounts.Exception);
            }

            departmentDetailDTO.Employees = from employee in getDepartmentEmployee.Data
                                            join account in getAccounts.Data on employee.Guid equals account.Guid
                                            join job in getJobs.Data on employee.JobGuid equals job.Guid
                                            select new DepartmentEmployeeDTO
                                            {
                                                Guid = employee.Guid,
                                                FirstName = employee.FirstName,
                                                LastName = employee.LastName,
                                                BirthDate = employee.BirthDate,
                                                HiringDate = employee.HiringDate,
                                                Gender = employee.Gender,
                                                PhoneNumber = employee.PhoneNumber,
                                                Email = account.Email,
                                                Job = job.Name
                                            };

            // Success Response With Department Employees
            return Ok(new ResponseOkHandler<DepartmentDetailDTO>(Message.SuccessRetrieve, departmentDetailDTO));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }
}
