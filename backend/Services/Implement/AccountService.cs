using AutoMapper;
using Microsoft.Extensions.Configuration;
using Models.DTOs.Response;
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
}