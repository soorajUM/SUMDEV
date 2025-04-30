

using Microsoft.EntityFrameworkCore;
using SUM.Models;

public class sumAppContext : DbContext
{
    public sumAppContext(DbContextOptions<sumAppContext> options)
    : base(options)
    {
    }

    public DbSet<Expence> Expences { get; set; }
}

