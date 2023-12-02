using API.Contracts;
using API.Data;
using API.DTOs.AccountData;
using API.DTOs.EmployeeData;
using API.Models;
using API.Utilities;
using API.Utilities.Handlers;
using API.Utilities.Message;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly HumanResourcesDbContext context;
    private readonly IAccountRepository accountRepository;
    private readonly IAccountRoleRepository accountRoleRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IDepartmentRepository departmentRepository;
    private readonly IJobRepository jobRepository;
    private readonly IJobHistoryRepository jobHistoryRepository;
    private readonly IRoleRepository roleRepository;
    private readonly IJWTokenHandler tokenHandler;

    public EmployeeController(HumanResourcesDbContext context,
        IAccountRepository accountRepository,
        IAccountRoleRepository accountRoleRepository,
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository,
        IJobRepository jobRepository,
        IRoleRepository roleRepository,
        IJWTokenHandler tokenHandler,
        IJobHistoryRepository jobHistoryRepository)
    {
        this.context = context;
        this.accountRepository = accountRepository;
        this.accountRoleRepository = accountRoleRepository;
        this.employeeRepository = employeeRepository;
        this.departmentRepository = departmentRepository;
        this.jobRepository = jobRepository;
        this.roleRepository = roleRepository;
        this.tokenHandler = tokenHandler;
        this.jobHistoryRepository = jobHistoryRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            // Get all employee
            var getEmployees = employeeRepository.GetAll();

            if (!getEmployees.IsSuccess)
            {
                throw new Exception(getEmployees.Exception);
            }

            if (!getEmployees.Data.Any())
            {
                return NotFound(ErrorResponse.DataNotFound("Employee data is empty!"));
            }

            // Get all account
            var getAccounts = accountRepository.GetAll();

            if (!getAccounts.IsSuccess)
            {
                throw new Exception(getAccounts.Exception);
            }

            // Get all department
            var getDepartments = departmentRepository.GetAll();

            if (!getDepartments.IsSuccess)
            {
                throw new Exception(getDepartments.Exception);
            }

            if (!getDepartments.Data.Any())
            {
                return NotFound(ErrorResponse.DataNotFound("Department data is empty!"));
            }

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

            // Merge employee data
            var employeeDetails = from employee in getEmployees.Data
                                  join account in getAccounts.Data on employee.Guid equals account.Guid
                                  join department in getDepartments.Data on employee.DepartmentGuid equals department.Guid
                                  join job in getJobs.Data on employee.JobGuid equals job.Guid
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
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        // Get employee from repository
        var employee = employeeRepository.GetByGuid(guid);

        if (employee is null)
        {
            return NotFound(ErrorResponse.DataNotFound("Employee data not found for the specified ID."));
        }

        var account = accountRepository.GetByGuid(guid);

        // Get department and job
        Department? department = departmentRepository.GetByGuid(employee.DepartmentGuid);
        if (department is null)
        {
            department.Name = "No department";
        }

        Job? job = jobRepository.GetByGuid(employee.JobGuid);
        if (job is null)
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
        var response = new ResponseOkHandler<EmployeeDetailData>(Message.SuccessRetrieve, employeeDetail);

        return Ok(response);
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        try
        {
            // Check employee data avaialability
            var employee = employeeRepository.GetByGuid(guid);

            if (employee is null)
            {
                return NotFound(ErrorResponse.DataNotFound(Message.EmployeeDataNotFound));
            }

            // Delete employee data
            var deleteEmployee = employeeRepository.Delete(employee);

            if (!deleteEmployee.IsSuccess)
            {
                throw new Exception(deleteEmployee.Exception);
            }

            return Ok(new ResponseOkHandler<string>("Employee data deleted successfully"));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpPost]
    public IActionResult Register(CreateEmployeeData createData)
    {
        using var transaction = context.Database.BeginTransaction();
        try
        {
            // Email validation
            var isEmailRegistered = accountRepository.IsEmailRegistered(createData.Email);

            if (isEmailRegistered)
            {
                return Conflict(ErrorResponse.Conflict("Email is already registered"));
            }

            // Phone number validation
            var isPhoneNumberRegistered = employeeRepository.IsPhoneNumberRegistered(createData.PhoneNumber);

            if (isPhoneNumberRegistered)
            {
                return Conflict(ErrorResponse.Conflict("Phone number is already registered"));
            }
            // Check Job Availability
            var job = jobRepository.GetByCode(createData.JobCode);

            if (job is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Job not available or does not exist."));
            }

            // Check Department Availability
            var department = departmentRepository.GetByCode(createData.DepartmentCode);

            if (department is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Department not available or does not exist."));
            }

            // Check Role Availability
            var role = roleRepository.GetByName(createData.Role);

            if (role is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Role not available or does not exist."));
            }

            // Create employee data
            Employee newEmployee = new Employee
            {
                Guid = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                FirstName = createData.FirstName,
                LastName = createData.LastName,
                Gender = createData.Gender,
                BirthDate = createData.BirthDate,
                HiringDate = createData.HiringDate,
                PhoneNumber = createData.PhoneNumber,
                DepartmentGuid = department.Guid,
                JobGuid = job.Guid
            };

            var createEmployee = employeeRepository.Create(newEmployee);

            if (!createEmployee.IsSuccess)
            {
                throw new Exception(createEmployee.Exception);
            }

            // Create account data
            Account newAccount = new Account
            {
                Guid = newEmployee.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Email = createData.Email,
                Password = HashHandler.Password(createData.Password),
                IsDisabled = false,
                OTP = 0,
                IsOtpUsed = true,
                OtpExpiredTime = DateTime.Now
            };

            var createAccount = accountRepository.Create(newAccount);

            if (!createAccount.IsSuccess)
            {
                throw new Exception(createAccount.Exception);
            }

            // Create account role data
            AccountRole newAccountRole = new AccountRole
            {
                Guid = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                AccountGuid = newEmployee.Guid,
                RoleGuid = role.Guid
            };

            var createAccountRole = accountRoleRepository.Create(newAccountRole);

            if (!createAccountRole.IsSuccess)
            {
                throw new Exception(createAccountRole.Exception);
            }

            // Create job history data
            JobHistory newJobHistory = new JobHistory
            {
                Guid = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                EmployeeGuid = newEmployee.Guid,
                JobGuid = job.Guid,
                StartDate = createData.HiringDate,
                EndDate = null
            };

            var createJobHistory = jobHistoryRepository.Create(newJobHistory);

            if (!createJobHistory.IsSuccess)
            {
                throw new Exception(createJobHistory.Exception);
            }

            // Commit changes
            transaction.Commit();

            // Return success response
            return Ok(OkResponse.SuccessRetrieveData());
        }
        catch(Exception ex)
        {
            context.Database.RollbackTransaction();

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpPut]
    public IActionResult Update(UpdateEmployeeData updateData)
    {
        using var transaction = context.Database.BeginTransaction();

        try
        {
            // Check employee data
            var employee = employeeRepository.GetByGuid(updateData.Guid);

            if(employee is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Employee data not found for the specified ID."));
            }

            // Check department
            var department = departmentRepository.GetByCode(updateData.DepartmentCode);

            if (department is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Department not available or does not exist."));
            }

            // Check job
            var job = jobRepository.GetByCode(updateData.JobCode);

            if (job is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Job not available or does not exist."));
            }

            // Check role
            var role = roleRepository.GetByName(updateData.Role);

            if (role is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Role not available or does not exist."));
            }

            // Update employee data
            employee.ModifiedDate = DateTime.Now;
            employee.BirthDate = updateData.BirthDate;
            employee.HiringDate = updateData.HiringDate;
            employee.FirstName = updateData.FirstName;
            employee.LastName = updateData.LastName;
            employee.JobGuid = job.Guid;
            employee.DepartmentGuid = department.Guid;
            employee.PhoneNumber = updateData.PhoneNumber;
            employee.Gender = updateData.Gender;

            var updateEmployee = employeeRepository.Update(employee);

            if(!updateEmployee.IsSuccess)
            {
                throw new Exception(updateEmployee.Exception);
            }

            // Update account data 
            var account = accountRepository.GetByGuid(updateData.Guid);

            if (updateData.Email != account.Email)
            {
                if (accountRepository.IsEmailRegistered(updateData.Email))
                {
                    return Conflict(ErrorResponse.Conflict("Email is already registered"));
                }

                account.Email = updateData.Email;

                var updateAccount = accountRepository.Update(account);

                if (!updateAccount.IsSuccess)
                {
                    throw new Exception(updateAccount.Exception);
                }
            }

            // Commit changes
            transaction.Commit();

            // Return success
            return Ok(OkResponse.SuccessRetrieveData());
        }
        catch(Exception ex)
        {
            context.Database.RollbackTransaction();

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }
}
