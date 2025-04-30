using Microsoft.EntityFrameworkCore;
using SUM.Models;

public class ExpenseContext : DbContext
{
    public ExpenseContext(DbContextOptions<ExpenseContext> options)
        : base(options)
    {
    }

    public DbSet<Expense> Expenses { get; set; }
}

