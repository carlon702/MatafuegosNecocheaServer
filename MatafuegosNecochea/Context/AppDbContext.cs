using MatafuegosNecochea.Models.Clients;
using Microsoft.EntityFrameworkCore;

namespace MatafuegosNecochea.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)  
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<MatafuegosNecochea.Models.Users.User> User { get; set; } = default!;
        public DbSet<MatafuegosNecochea.Models.FireE.FireExtinguisher> FireExtinguisher { get; set; } = default!;
        public DbSet<MatafuegosNecochea.Models.FireE.Charge> Charge { get; set; } = default!;
        public DbSet<MatafuegosNecochea.Models.FireE.Capacity> Capacity { get; set; } = default!;
        public DbSet<MatafuegosNecochea.Models.Clients.Iva> Iva { get; set; } = default!;
        public DbSet<MatafuegosNecochea.Models.Clients.Address> Address { get; set; } = default!;
        public DbSet<MatafuegosNecochea.Models.FireE.Brand> Brand { get; set; } = default!;

    }
}
