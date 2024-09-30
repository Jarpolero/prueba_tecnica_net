using AutoMapper;
using ESettOpenApiInterfaces.Models;
using ESettRepositoriesInterfaces.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlicundeTechTest.Mappings
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<BankApi, BankDAO>();
            CreateMap<BankDAO, BankApi>();

            CreateMap<BankEntity, BankDAO>();
            CreateMap<BankDAO, BankEntity>();
        }
    }
}
