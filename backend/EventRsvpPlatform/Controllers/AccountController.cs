using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.Response;
using Models.Entities;
using Services.Interface;

namespace EventRsvpPlatform.Controllers;

[ApiController]
[Route("/api/accounts")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAccounts()
    {
        var response = await _accountService.GetAllAccounts();
        return Ok(new ApiResponse<List<AccountResponse>> { Success = true, Data = response });
    }
}