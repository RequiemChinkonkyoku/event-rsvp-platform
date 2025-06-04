using Models.DTOs.Request;
using Models.DTOs.Response;

namespace Services.Interface;

public interface IAccountService
{
    Task<List<AccountResponse>> GetAllAccountsAsync();
    Task<AccountResponse> CreateAccountAsync(CreateAccountRequest request);
    Task<AccountResponse> GetAccountByIdAsync(Guid id);
    Task<AccountResponse> UpdateAccountAsync(Guid id, UpdateAccountRequest request);
    Task<AccountResponse> UpdatePasswordAsync(Guid id, UpdatePasswordRequest request);
}