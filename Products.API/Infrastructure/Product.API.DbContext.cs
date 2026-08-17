using Microsoft.EntityFrameworkCore;
using Products.API.Entities;

namespace Products.API.Infrastructure;

public class ProductDbContext : DbContext
{
	public DbSet<Client> Clients { get; set; } = default!;
	public DbSet<Product> Products { get; set; } = default!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=data.db");
	}
}