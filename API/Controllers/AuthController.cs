using API.Contracts;
using API.DTOs.Auth;
using API.Utilities.Handlers;
using API.Utilities.Message;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace API.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAccountRepository accountRepository;
    private readonly IAccountRoleRepository accountRoleRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly IRoleRepository roleRepository;
    private readonly IJWTokenHandler tokenHandler;

    public AuthController(IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, IEmployeeRepository employeeRepository, IRoleRepository roleRepository, IJWTokenHandler tokenHandler)
    {
        this.accountRepository = accountRepository;
        this.accountRoleRepository = accountRoleRepository;
        this.employeeRepository = employeeRepository;
        this.roleRepository = roleRepository;
        this.tokenHandler = tokenHandler;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginData loginData)
    {
        // Get account by email
        var account = accountRepository.GetByEmail(loginData.Email);

        // Account result handling
        if(account is null)
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

        var getAccountRoles = from ar in accountRoleRepository.GetByAccountGuid(account.Guid)
                              join r in roleRepository.GetAll() on ar.RoleGuid equals r.Guid
                              select r.Name;

        foreach(string roleName in getAccountRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, roleName));
        }

        var token = tokenHandler.Generate(claims);


        // Success login
        return Ok(new ResponseOkHandler<string>("Login Success", token));
    }
}
