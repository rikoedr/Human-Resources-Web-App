using API.Contracts;
using API.DTOs.Auth;
using API.Utilities.Handlers;
using API.Utilities.Message;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAccountRepository accountRepository;

    public AuthController(IAccountRepository accountRepository)
    {
        this.accountRepository = accountRepository;
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

        // Success login
        return Ok(new ResponseOkHandler<string>("Success"));
    }
}
