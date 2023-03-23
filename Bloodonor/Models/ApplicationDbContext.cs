using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloodonor.Models
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUsers(builder);
            SeedRoles(builder);
            SeedUserRoles(builder);
            SeedBlood(builder);
            SeedLocation(builder);
            SeedBranch(builder);
            base.OnModelCreating(builder);
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public void SeedUsers(ModelBuilder builder)
        {
            User admin = new()
            {
                Id = 1,
                FullName = "Super Admin",
                City = "Enugu",
                Address = "Enugu street",
                BloodGroup = "A+",
                Gender = "Male",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                PhoneNumber = "1234567890",
            };
            PasswordHasher<User> passwordHasher = new();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin*1234");
            builder.Entity<User>().HasData(admin);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "Admin", ConcurrencyStamp = new Guid().ToString(), NormalizedName = "ADMIN" },
                new Role() { Id = 2, Name = "Donor", ConcurrencyStamp = new Guid().ToString(), NormalizedName = "DONOR" });
        }

        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<int>>().HasData
                (
                    new IdentityUserRole<int>() { RoleId = 1, UserId = 1 }
                );
        }

        private static void SeedBlood(ModelBuilder builder)
        {
            builder.Entity<BloodGroup>().HasData(
                new BloodGroup
                {
                    BloodGroupId = 1,
                    Name = "B+",
                    Status = "Enable",
                    LastUpdated = DateTime.Now,
                    Avaialable_amount = 23
                },
                 new BloodGroup
                 {
                     BloodGroupId = 2,
                     Name = "A+",
                     Status = "Enable",
                     LastUpdated = DateTime.Now,
                     Avaialable_amount = 15
                 },
                new BloodGroup
                {
                    BloodGroupId = 3,
                    Name = "AB+",
                    Status = "Enable",
                    LastUpdated = DateTime.Now,
                    Avaialable_amount = 13


                },
                new BloodGroup
                {
                    BloodGroupId = 4,
                    Name = "O+",
                    Status = "Enable",
                    LastUpdated = DateTime.Now,
                    Avaialable_amount = 17


                },
                new BloodGroup
                {
                    BloodGroupId = 5,
                    Name = "A-",
                    Status = "Enable",
                    LastUpdated = DateTime.Now,
                    Avaialable_amount = 12

                },
                 new BloodGroup
                 {
                     BloodGroupId = 6,
                     Name = "B-",
                     Status = "Enable",
                     LastUpdated = DateTime.Now,
                     Avaialable_amount = 5

                 },
                  new BloodGroup
                  {
                      BloodGroupId = 7,
                      Name = "AB-",
                      Status = "Enable",
                      LastUpdated = DateTime.Now,
                      Avaialable_amount = 8

                  },
                   new BloodGroup
                   {
                       BloodGroupId = 8,
                       Name = "O-",
                       Status = "Enable",
                       LastUpdated = DateTime.Now,
                       Avaialable_amount = 10

                   });
        }

        private static void SeedLocation(ModelBuilder builder)
        {
            builder.Entity<Location>().HasData(
                new Location
                {
                    LocationId = 1,
                    Name = "Imo",
                },
                 new Location
                 {
                     LocationId = 2,
                     Name = "Ibadan",
                 }, new Location
                 {
                     LocationId = 3,
                     Name = "Plateau",
                 }, new Location
                 {
                     LocationId = 4,
                     Name = "Kaduna",
                 }, new Location
                 {
                     LocationId = 5,
                     Name = "Benin-City",
                 }, new Location
                 {
                     LocationId = 6,
                     Name = "Maiduguri",
                 }, new Location
                 {
                     LocationId = 7,
                     Name = "Port-Harcourt",
                 }, new Location
                 {
                     LocationId = 8,
                     Name = "Ogun State",
                 }, new Location
                 {
                     LocationId = 9,
                     Name = "Lokoja",
                 }, new Location
                 {
                     LocationId = 10,
                     Name = "Yobe State",
                 },
                  new Location
                  {
                      LocationId = 11,
                      Name = "Katsina. ",
                  }, new Location
                  {
                      LocationId = 12,
                      Name = "Ado-Ekiti ",
                  }, new Location
                  {
                      LocationId = 13,
                      Name = "Enugu State",
                  }, new Location
                  {
                      LocationId = 14,
                      Name = "Taraba State",
                  }, new Location
                  {
                      LocationId = 15,
                      Name = "Cross-River State ",
                  }, new Location
                  {
                      LocationId = 16,
                      Name = "Sokoto.",
                  });
        }


        private static void SeedBranch(ModelBuilder builder)
        {
            builder.Entity<Branch>().HasData(
                new Branch
                {
                    BranchId = 1,
                    Zonal_Director = "Dr. Malachy Iheanacho",
                    Emaail = "nbtsowerri@gmail.com",
                    LocationId = 1
                },
                 new Branch
                 {
                     BranchId = 2,
                     Zonal_Director = "Dr. Oladapo W. Aworanti",
                     Emaail = "nbts_swzib@yahoo.co.uk",
                     LocationId = 2
                 });
        }
    }

}