using ESettOpenApiInterfaces.Models;

namespace ESettOpenApiInterfaces.Interfaces
{
    public interface IBankService
    {
        public Task<IEnumerable<BankApi>?> GetBanks();
    }
}
