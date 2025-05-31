using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace EventRsvpPlatform.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
}