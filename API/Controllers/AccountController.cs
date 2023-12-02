using API.Contracts;
using API.DTOs.AccountData;
using API.Utilities.Handlers;
using API.Utilities.Message;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository accountRepository;
    private readonly IAccountRoleRepository accountRoleRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IRoleRepository roleRepository;
    private readonly IJWTokenHandler tokenHandler;
    private readonly IEmailHandler emailHandler;

    public AccountController(IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, IEmployeeRepository employeeRepository, IRoleRepository roleRepository, IJWTokenHandler tokenHandler, IEmailHandler emailHandler)
    {
        this.accountRepository = accountRepository;
        this.accountRoleRepository = accountRoleRepository;
        this.employeeRepository = employeeRepository;
        this.roleRepository = roleRepository;
        this.tokenHandler = tokenHandler;
        this.emailHandler = emailHandler;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginData loginData)
    {
        try
        {
            // Get account by email
            var account = accountRepository.GetByEmail(loginData.Email);

            // Account result handling
            if (account is null)
            {
                return Unauthorized(ErrorResponse.EmailPasswordInvalid());
            }

            // Validate password
            var isPasswordValid = HashHandler.VerifyPassword(loginData.Password, account.Password);

            if (!isPasswordValid)
            {
                return Unauthorized(ErrorResponse.EmailPasswordInvalid());
            }

            // Get account detailed data
            var employee = employeeRepository.GetByGuid(account.Guid);

            // Create JWT Token
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, account.Guid.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, account.Guid.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, employee.FirstName + " " + employee.LastName));

            var getRoles = roleRepository.GetAll();

            if (!getRoles.IsSuccess)
            {
                throw new Exception(getRoles.Exception);
            }

            var getAccountRoles = from ar in accountRoleRepository.GetByAccountGuid(account.Guid)
                                  join r in getRoles.Data on ar.RoleGuid equals r.Guid
                                  select r.Name;

            foreach (string roleName in getAccountRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }

            var token = tokenHandler.Generate(claims);


            // Success login
            return Ok(new ResponseOkHandler<string>("Login Success", token));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpPut("password")]
    public IActionResult UpdatePassword(UpdatePasswordData updatePassword)
    {
        try
        {
            // Get account by email
            var account = accountRepository.GetByEmail(updatePassword.Email);

            if (account is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Employee data not found for the specified email."));
            }

            // Check OTP Expired 
            bool isOtpExpired = account.OtpExpiredTime == DateTime.Now;

            if (isOtpExpired)
            {
                return Unauthorized(ErrorResponse.Unauthorized("The OTP code has expired."));
            }

            // Check OTP code use status
            if (account.IsOtpUsed)
            {
                return Unauthorized(ErrorResponse.Unauthorized("The OTP code has been used."));
            }

            // OTP Code validation
            if (account.OTP != updatePassword.Otp)
            {
                return Unauthorized(ErrorResponse.Unauthorized("The OTP code is not valid."));
            }

            // Change Password
            account.Password = HashHandler.Password(updatePassword.Password);
            account.IsOtpUsed = true;
            account.ModifiedDate = DateTime.Now;

            var updateAccountPassword = accountRepository.Update(account);

            if (!updateAccountPassword.IsSuccess)
            {
                throw new Exception(updateAccountPassword.Exception);
            }

            // Success response
            return Ok(OkResponse.SuccessRetrieveData());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));
        }
    }

    [HttpPost("password/reset")]
    public IActionResult ResetPassword(ResetPasswordData resetPasswordData)
    {
        try
        {
            // Check email
            var account = accountRepository.GetByEmail(resetPasswordData.Email);

            if (account is null)
            {
                return NotFound(ErrorResponse.DataNotFound("Employee data not found for the specified email."));
            }

            // Generate otp
            account.OTP = GenerateHandler.OTP();
            account.OtpExpiredTime = DateTime.Now.AddMinutes(5);
            account.IsOtpUsed = false;

            // Update account OTP
            var updateAccountOtp = accountRepository.Update(account);

            if (!updateAccountOtp.IsSuccess)
            {
                throw new Exception(updateAccountOtp.Exception);
            }

            // Send OTP Code to Email
            string emailResponse = $"Your OTP Code : {account.OTP}, Valid Until : {account.OtpExpiredTime}";

            emailHandler.Send("Reset Password", emailResponse, resetPasswordData.Email);

            // Send success response
            return Ok(new ResponseOkHandler<string>($"OTP code sent to email. Valid until {account.OtpExpiredTime}."));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message));

        }
    }
}
