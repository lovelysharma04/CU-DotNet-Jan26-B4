using AutoMapper;
using SmartBank.TransactionService.DTOs;
using SmartBank.TransactionService.Models;


namespace SmartBank.TransactionService.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity → DTO
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
