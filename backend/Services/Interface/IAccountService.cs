using Models.DTOs.Response;

namespace Services.Interface;

public interface IAccountService
{
    Task<List<AccountResponse>> GetAllAccounts();
}