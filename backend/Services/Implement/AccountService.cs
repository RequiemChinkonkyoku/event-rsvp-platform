using AutoMapper;
using Microsoft.Extensions.Configuration;
using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.Entities;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    
    public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _config = config;
    }

    public async Task<List<AccountResponse>> GetAllAccountsAsync()
    {
        var accounts = await _unitOfWork.Accounts.GetAllAsync();
        
        return _mapper.Map<List<AccountResponse>>(accounts);
    }

    public async Task<AccountResponse> GetAccountByIdAsync(Guid id)
    {
        var account = await _unitOfWork.Accounts.GetByIdAsync(id);
        
        return _mapper.Map<AccountResponse>(account);
    }

    public async Task<AccountResponse> CreateAccountAsync(CreateAccountRequest request)
    {
        var existingEmail = await _unitOfWork.Accounts.GetSingleAsync(x => x.Email == request.Email);
        if (existingEmail != null)
        {
            throw new Exception($"Email {request.Email} already exists");
        }
        
        var account = _mapper.Map<Account>(request);
        account.Id = Guid.NewGuid();
        
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        account.PasswordHash = passwordHash;
        
        await _unitOfWork.Accounts.AddAsync(account);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<AccountResponse>(account);
    }

    public async Task<AccountResponse> UpdateAccountAsync(Guid id, UpdateAccountRequest request)
    {
        var account = await _unitOfWork.Accounts.GetByIdAsync(id);
        if (account == null)
        {
            throw new Exception($"Account {id} does not exist");
        }
        
        account.FullName = request.FullName;
        account.AvatarUrl = request.AvatarUrl;
        account.LastUpdatedTime = DateTime.UtcNow;
        account.LastUpdatedBy = request.UpdatedBy;
        
        await _unitOfWork.Accounts.UpdateAsync(account);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<AccountResponse>(account);
    }

    public async Task<AccountResponse> UpdatePasswordAsync(Guid id, UpdatePasswordRequest request)
    {
        var account = await _unitOfWork.Accounts.GetByIdAsync(id);
        if (account == null)
        {
            throw new Exception($"Account {id} does not exist");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, account.PasswordHash))
        {
            throw new UnauthorizedAccessException("Current password is incorrect");
        }
        
        account.Password = request.NewPassword;
        account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        account.LastUpdatedTime = DateTime.UtcNow;
        account.LastUpdatedBy = request.UpdatedBy;
        
        await _unitOfWork.Accounts.UpdateAsync(account);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<AccountResponse>(account);
    }
}