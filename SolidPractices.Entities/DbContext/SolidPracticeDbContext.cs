using Microsoft.EntityFrameworkCore;
using SolidPractices.Entities.Entities;

namespace SolidPractices.Entities
{
    public class SolidPracticeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\Eren;Database=SolidPracticeDb;Trusted_Connection=True;MultipleActiveResultSets=True");
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BİRE BİR İLİŞKİLER
            modelBuilder.Entity<Address>().HasOne(x=>x.Customer).WithOne(x=>x.Address).HasForeignKey<Customer>(x=>x.AddressId);
            modelBuilder.Entity<Address>().HasOne(x => x.Employee).WithOne(x => x.Address).HasForeignKey<Employee>(x => x.AddressId);
            modelBuilder.Entity<Address>().HasOne(x => x.Supplier).WithOne(x => x.Address).HasForeignKey<Supplier>(x => x.AddressId);

            modelBuilder.Entity<Address>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Address>().Property(x => x.Created).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Customer>().Property(x => x.Created).IsRequired();
            modelBuilder.Entity<Employee>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Employee>().Property(x => x.Created).IsRequired();
            modelBuilder.Entity<Supplier>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Supplier>().Property(x => x.Created).IsRequired();

        }
    }
}