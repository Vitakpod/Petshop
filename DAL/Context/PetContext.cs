using Microsoft.EntityFrameworkCore;
using Petshop.DAL.Entities;

namespace Petshop.DAL.Context
{
    public class PetContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Order> Orders { get; set; }

        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}



