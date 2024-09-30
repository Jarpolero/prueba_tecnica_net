using ESettRepositoriesInterfaces.Models;

namespace ESettRepositoriesInterfaces.Interfaces
{
    public interface IeSettDataAccess
    {
        Task<BankDAO?> GetBank(string bankId);
        Task<IEnumerable<BankDAO>?> GetBanks();
        Task InsertBanks(IEnumerable<BankDAO> banks);

    }
}
