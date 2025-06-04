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

    public async Task<List<AccountResponse>> GetAllAccounts()
    {
        var accounts = await _unitOfWork.Accounts.GetAllAsync();
        
        return _mapper.Map<List<AccountResponse>>(accounts);
    }

    public async Task<AccountResponse> GetAccountById(Guid id)
    {
        var account = await _unitOfWork.Accounts.GetByIdAsync(id);
        
        return _mapper.Map<AccountResponse>(account);
    }

    public async Task<AccountResponse> CreateAccount(CreateAccountRequest request)
    {
        var accounts = await _unitOfWork.Accounts.GetAllAsync();
        
        var existingEmail = await _unitOfWork.Accounts.GetSingleAsync(x => x.Email == request.Email);
        if (existingEmail != null)
        {
            throw new Exception($"Email {request.Email} already exists");
        }
        
        var account = _mapper.Map<Account>(request);
        account.Id = Guid.NewGuid();
        
        await _unitOfWork.Accounts.AddAsync(account);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<AccountResponse>(account);
    }
}