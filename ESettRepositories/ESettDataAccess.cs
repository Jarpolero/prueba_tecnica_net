using ESettRepositoriesInterfaces.DBContext;
using ESettRepositoriesInterfaces.Interfaces;
using ESettRepositoriesInterfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace ESettRepositories
{
    public class ESettDataAccess : IeSettDataAccess
    {
        ESettDbContext _dbContext;

        public ESettDataAccess(ESettDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ApplicationException("Critical configuration failed.");
            }
            _dbContext = dbContext;
        }

        public async Task<BankDAO?> GetBank(string? bankBic)
        {
            if (bankBic == null)
            {
                return null;
            }
            return await _dbContext.Banks.FirstOrDefaultAsync(x => x.Bic == bankBic);
        }

        public async Task<IEnumerable<BankDAO>?> GetBanks()
        {
            return await _dbContext.Banks.ToListAsync();
        }

        public async Task InsertBanks(IEnumerable<BankDAO> banks)
        {
            await _dbContext.Banks.AddRangeAsync(banks);
            await _dbContext.SaveChangesAsync();
        }
    }
}
