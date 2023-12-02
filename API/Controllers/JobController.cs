using API.Contracts;
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
public class JobController : ControllerBase
{
    private readonly IDepartmentRepository departmentRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IAccountRepository accountRepository;
    private readonly IJobRepository jobRepository;

    public JobController(
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
            // Get all job
            var getJobs = jobRepository.GetAll();

            if (!getJobs.IsSuccess)
            {
                throw new Exception(getJobs.Exception);
            }

            if (!getJobs.Data.Any())
            {
                return NotFound(ErrorResponse.DataNotFound("Job data is empty!"));
            }

            // Convert to DTO format
            IEnumerable<JobDTO> jobDTOs = getJobs.Data.Select(item => (JobDTO)item);

            return Ok(new ResponseOkHandler<IEnumerable<JobDTO>>("Success to retrieve data", jobDTOs));
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
            // Creating job
            var createJob = jobRepository.Create(createJobDTO);

            if (!createJob.IsSuccess)
            {
                throw new Exception(createJob.Exception);
            }

            // Return success response
            return Ok(OkResponse.SuccessRetrieveData());
        }
        catch(Exception ex)
        {
            if (ex.Message.Contains("name"))
            {
                return Conflict(ErrorResponse.Conflict("Failed to create job data", "Job name is already registered."));
            }

            if (ex.Message.Contains("code"))
            {
                return Conflict(ErrorResponse.Conflict("Failed to create job data", "Job code is already registered."));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpPut]
    public IActionResult Update(JobDTO jobDTO)
    {
        try
        {
            // Check job data by dto guid
            var job = jobRepository.GetByGuid(jobDTO.Guid);

            if(job is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Job data not found for the specified ID."));
            }

            // Update job data 
            job.Code = jobDTO.Code;
            job.Name = jobDTO.Name;
            job.MinSalary = jobDTO.MinSalary;
            job.MaxSalary = jobDTO.MaxSalary;
            job.ModifiedDate = DateTime.Now;

            var updateJob = jobRepository.Update(job);

            if (!updateJob.IsSuccess)
            {
                throw new Exception(updateJob.Exception);
            }

            return Ok(OkResponse.SuccessRetrieveData());
        }
        catch(Exception ex)
        {
            if (ex.Message.Contains("name"))
            {
                return Conflict(ErrorResponse.Conflict("Failed to update job data", "Job name is already registered."));
            }

            if (ex.Message.Contains("code"))
            {
                return Conflict(ErrorResponse.Conflict("Failed to update job data", "Job code is already registered."));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        try
        {
            // Check job data availability
            var getJob = jobRepository.TakeById(guid);

            if (!getJob.IsSuccess)
            {
                throw new Exception(getJob.Exception);
            }

            if(getJob.Data is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Job data not found for the specified ID."));
            }

            // Delete job data
            var deleteJob = jobRepository.Delete(getJob.Data);

            if (!deleteJob.IsSuccess)
            {
                throw new Exception(deleteJob.Exception);
            }

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
            // Get Job Data 
            var getJob = jobRepository.TakeById(guid);

            if (!getJob.IsSuccess)
            {
                throw new Exception(getJob.Exception);
            }

            if(getJob.Data is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Job data not found for the specified ID."));
            }

            var jobDetail = (JobDetailDTO)getJob.Data;

            // Get Job Employee Data
            var getEmployees = employeeRepository.GetByJob(guid);

            if (!getEmployees.IsSuccess)
            {
                throw new Exception(getEmployees.Exception);
            }

            // Success Response with Empty Job Employees
            if (!getEmployees.Data.Any())
            {
                return Ok(new ResponseOkHandler<JobDetailDTO>(Message.SuccessRetrieve, jobDetail));
            }

            // Get Accounts and Departments
            var getAccounts = accountRepository.GetAll();
            if(!getAccounts.IsSuccess) 
            { 
                throw new Exception(getAccounts.Exception); 
            }

            var getDepartments = departmentRepository.GetAll();
            if (!getDepartments.IsSuccess)
            {
                throw new Exception(getDepartments.Exception);
            }
            
            // Create Data For Job Employees
            jobDetail.Employees = from employee in getEmployees.Data
                                  join account in getAccounts.Data on employee.Guid equals account.Guid
                                  join department in getDepartments.Data on employee.DepartmentGuid equals department.Guid
                                  select new JobEmployeeDTO
                                  {
                                      Guid = employee.Guid,
                                      FirstName = employee.FirstName,
                                      LastName = employee.LastName,
                                      Gender = employee.Gender,
                                      BirthDate = employee.BirthDate,
                                      HiringDate = employee.HiringDate,
                                      PhoneNumber = employee.PhoneNumber,
                                      Email = account.Email,
                                      Department = department.Name
                                  };

            return Ok(new ResponseOkHandler<JobDetailDTO>(Message.SuccessRetrieve, jobDetail));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }
}
