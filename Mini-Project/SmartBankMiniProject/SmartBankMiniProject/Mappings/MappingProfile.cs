using SmartBankMiniProject.DTOs;
using SmartBankMiniProject.Models;
using AutoMapper;

namespace SmartBankMiniProject.Mappings
{
    // Inherit from Profile to access CreateMap
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<CreateAccountDto, Account>(); 
        }
    }
}
