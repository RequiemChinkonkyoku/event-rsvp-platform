using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.Request;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById([FromRoute] Guid id)
    {
        var response = await _accountService.GetAccountById(id);
        return Ok(new ApiResponse<AccountResponse> { Success = true, Data = response });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var response = await _accountService.CreateAccount(request);
            return Ok(new ApiResponse<AccountResponse> { Success = true, Data = response });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}