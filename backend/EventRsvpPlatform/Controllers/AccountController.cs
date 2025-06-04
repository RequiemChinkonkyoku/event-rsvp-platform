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
        var response = await _accountService.GetAllAccountsAsync();
        return Ok(new ApiResponse<List<AccountResponse>> { Success = true, Data = response });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById([FromRoute] Guid id)
    {
        var response = await _accountService.GetAccountByIdAsync(id);
        return Ok(new ApiResponse<AccountResponse> { Success = true, Data = response });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
    {
        var response = await _accountService.CreateAccountAsync(request);
        return Ok(new ApiResponse<AccountResponse> { Success = true, Data = response });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount([FromRoute] Guid id, [FromBody] UpdateAccountRequest request)
    {
        var response = await _accountService.UpdateAccountAsync(id, request);
        return Ok(new ApiResponse<AccountResponse> { Success = true, Data = response });
    }

    [HttpPut("{id}/password")]
    public async Task<IActionResult> UpdatePassword([FromRoute] Guid id, [FromBody] UpdatePasswordRequest request)
    {
        var response = await _accountService.UpdatePasswordAsync(id, request);
        return Ok(new ApiResponse<AccountResponse> { Success = true, Data = response });
    }
}