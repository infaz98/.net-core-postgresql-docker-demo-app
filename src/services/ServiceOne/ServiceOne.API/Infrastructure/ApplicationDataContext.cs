using Microsoft.EntityFrameworkCore;
using ServiceOne.API.Domain;

namespace ProjectManagement.Infrastructure;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(
        DbContextOptions<ApplicationDataContext> options
    ) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>()
          .HasKey(customer => new { customer.Id });
    }
}