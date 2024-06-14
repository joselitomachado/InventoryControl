using InventoryControl.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.API.Persistence;

public class InventoryControlDbContext : DbContext
{
    public InventoryControlDbContext(DbContextOptions<InventoryControlDbContext> options) : base(options)
    {
    }

    public DbSet<Medication> Medications { get; set; }
}
