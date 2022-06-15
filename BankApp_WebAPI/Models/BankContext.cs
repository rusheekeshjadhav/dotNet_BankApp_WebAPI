using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BankApp_WebAPI.Models
{
    public class BankContext: DbContext
    {
        public BankContext(DbContextOptions<BankContext> options): base(options)
        {
        }

        public DbSet<BankAccount> AccountList { get; set; } = null!;
    }
}
