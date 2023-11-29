using API.Contracts;
using API.DTOs.Auth;
using API.DTOs.Employee;
using API.Models;
using API.Utilities;
using API.Utilities.Handlers;
using API.Utilities.Message;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IAccountRepository accountRepository;
    private readonly IAccountRoleRepository accountRoleRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IDepartmentRepository departmentRepository;
    private readonly IJobRepository jobRepository;
    private readonly IRoleRepository roleRepository;
    private readonly IJWTokenHandler tokenHandler;

    public EmployeeController(IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IJobRepository jobRepository, IRoleRepository roleRepository, IJWTokenHandler tokenHandler)
    {
        this.accountRepository = accountRepository;
        this.accountRoleRepository = accountRoleRepository;
        this.employeeRepository = employeeRepository;
        this.departmentRepository = departmentRepository;
        this.jobRepository = jobRepository;
        this.roleRepository = roleRepository;
        this.tokenHandler = tokenHandler;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        // Get all employee
        var employees = employeeRepository.GetAll();

        if (!employees.Any())
        {
            return NotFound(ErrorResponse.DataNotFound("Employee data is empty!"));
        }

        // Get all account
        var accounts = accountRepository.GetAll();

        // Get all department
        var departments = departmentRepository.GetAll();

        if (!departments.Any())
        {
            return NotFound(ErrorResponse.DataNotFound("Department data is empty!"));
        }

        // Get all job
        var jobs = jobRepository.GetAll();

        if (!jobs.Any())
        {
            return NotFound(ErrorResponse.DataNotFound("Job data is empty!"));

        }

        // Merge employee data
        var employeeDetails = from employee in employees
                              join account in accounts on employee.Guid equals account.Guid
                              join department in departments on employee.DepartmentGuid equals department.Guid
                              join job in jobs on employee.JobGuid equals job.Guid
                              select new EmployeeDetailData
                              {
                                  Guid = employee.Guid,
                                  CreatedDate = employee.CreatedDate,
                                  ModifiedDate = employee.ModifiedDate,
                                  FirstName = employee.FirstName,
                                  LastName = employee.LastName,
                                  BirthDate = employee.BirthDate,
                                  HiringDate = employee.HiringDate,
                                  Gender = employee.Gender,
                                  Department = department.Name,
                                  Job = job.Name,
                                  Email = account.Email,
                                  PhoneNumber = employee.PhoneNumber,
                                  IsAccountDisabled = account.IsDisabled
                              };
        // Success response
        var response = new ResponseOkHandler<IEnumerable<EmployeeDetailData>>(Message.SuccessRetrieve, employeeDetails);

        return Ok(response);
    }

    [HttpGet("employees/{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        // Get employee from repository
        var employee = employeeRepository.GetByGuid(guid);
        
        if(employee is null)
        {
            return NotFound(ErrorResponse.DataNotFound("Employee Employee data not found for the specified ID."));
        }

        var account = accountRepository.GetByGuid(guid);

        // Get department and job
        Department? department = departmentRepository.GetByGuid(employee.DepartmentGuid);
        if(department is null)
        {
            department.Name = "No department";
        }

        Job? job = jobRepository.GetByGuid(employee.JobGuid);
        if(job is null)
        {
            job.Name = "No job";
        }

        // Merge employee data
        var employeeDetail = new EmployeeDetailData
        {
            Guid = employee.Guid,
            CreatedDate = employee.CreatedDate,
            ModifiedDate = employee.ModifiedDate,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            HiringDate = employee.HiringDate,
            Gender = employee.Gender,
            Department = department.Name,
            Job = job.Name,
            Email = account.Email,
            PhoneNumber = employee.PhoneNumber,
            IsAccountDisabled = account.IsDisabled
        };

        // Success response
        var response = new ResponseOkHandler<EmployeeDetailData>(Message.SuccessRetrieve,employeeDetail);

        return Ok(response);
    }

    [HttpDelete("employees/{guid}")]
    public IActionResult Delete(Guid guid)
    {
        // Check employee data avaialability
        var employee = employeeRepository.GetByGuid(guid);

        if(employee is null)
        {
            return NotFound(ErrorResponse.DataNotFound("Employee Employee data not found for the specified ID."));
        }

        // Delete employee data
        var isEmployeeDeleted = employeeRepository.Delete(employee);

        if (!isEmployeeDeleted)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                ErrorResponse.InternalServerError("Failed to delete employee data")
                );
        }

        return Ok(new ResponseOkHandler<string>());
    }
}
