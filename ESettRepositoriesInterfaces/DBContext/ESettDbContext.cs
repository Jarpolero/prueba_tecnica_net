using ESettRepositoriesInterfaces.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESettRepositoriesInterfaces.DBContext
{
    public class ESettDbContext : DbContext
    {
        public ESettDbContext(DbContextOptions<ESettDbContext> options) : base(options)
        {
        }

        public DbSet<BankDAO> Banks { get; set; }
    }
}