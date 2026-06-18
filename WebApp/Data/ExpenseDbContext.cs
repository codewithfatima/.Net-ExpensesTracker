using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApp.Models;

namespace WebApp.Data
{
    public class ExpenseDbContext:DbContext //inheritane all the features of db built by microsoft
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options) { }
            // This line tells EF Core: "I have a table called Expenses"
             public DbSet<Expense> Expenses { get; set; }
        
    }
}
