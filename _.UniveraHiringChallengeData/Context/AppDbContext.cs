using _.UniveraHiringChallengeEntity.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeData.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

        //public DbSet<ShoppingListProduct> ShoppingListProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity("_.UniveraHiringChallengeEntity.Entities.ShoppingListProduct", b =>
            {
                b.Property<Guid>("ShoppingListId")
                    .HasColumnType("uniqueidentifier")
                    .HasColumnName("ShoppingListId");

                b.Property<Guid>("ProductId")
                    .HasColumnType("uniqueidentifier")
                    .HasColumnName("ProductId");

                b.HasKey("ShoppingListId", "ProductId");
            });

        }
    }
}
