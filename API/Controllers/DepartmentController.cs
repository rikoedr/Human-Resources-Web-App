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
    public IActionResult Create(CreateJobDTO createJobDTO)
    {
        try
        {
            
            return Ok(OkResponse.SuccessRetrieveData());
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpPut]
    public IActionResult Update(JobDTO jobDTO)
    {
        try
        {
            

            return Ok(OkResponse.SuccessRetrieveData());
        }
        catch(Exception ex)
        { 
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        try
        {
            

            // Send success response
            return Ok(OkResponse.DataDeletedSuccessfully());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        try
        {
            
            return Ok();
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }
}
