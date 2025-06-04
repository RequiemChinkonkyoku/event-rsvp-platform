using Models.DTOs.Request;
using Models.DTOs.Response;

namespace Services.Interface;

public interface IAccountService
{
    Task<List<AccountResponse>> GetAllAccounts();
    Task<AccountResponse> CreateAccount(CreateAccountRequest request);
    Task<AccountResponse> GetAccountById(Guid id);
}