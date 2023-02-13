using HardTrain.DAL.Entities.UserResultScope;
using HardTrain.DAL.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HardTrain.DAL.DataSeeds
{
    internal static partial class TestDataSeed
    {
        private static readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        #region Roles Settings
        private static readonly Guid admin_roleId = new Guid("b13c0935-3467-4fa9-ae84-267197263f25");
        private static readonly Guid client_roleId = new Guid("6f8450e1-82bf-4df0-8540-d8d85f6e409a");
        private static readonly Guid manager_roleId = new Guid("b025bb01-2eb4-4d45-bb28-e3fc4c139d80");
        #endregion Roles Settings

        #region Users Settings
        private static readonly Guid adminId = new Guid("6fa67588-40fb-4cc2-a574-deca54a5b811");
        private static readonly string admin_securityStamp = new Guid("1CF5E64D-1C2F-466E-9978-636A70A10347").ToString();
        private static readonly Guid user1Id = new Guid("a0a28231-c733-4acf-aa5b-46a26e1a11ed");
        private static readonly string user1_securityStamp = new Guid("654F6985-3739-4457-8C20-439D50C1F0FF").ToString();
        private static readonly Guid user2Id = new Guid("1bdd1192-19fa-47ad-8ee4-705e02f226b7");
        private static readonly string user2_securityStamp = new Guid("BF9922E8-3C69-4DEE-9961-65C70E29072C").ToString();
        private static readonly Guid user3Id = new Guid("1ef65a80-45e1-4efa-8070-96ea00898357");
        private static readonly string user3_securityStamp = new Guid("EDD31D71-3BCC-475C-8B38-B50B731BAAAA").ToString();
        private static readonly Guid user4Id = new Guid("e9b9bf1f-b24f-4c96-90b5-413d21943f18");
        private static readonly string user4_securityStamp = new Guid("2E28282B-B3EE-4E6F-BD2A-76AB43A3638C").ToString();
        #endregion Users Settings


        private static void AddTestUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = admin_roleId,
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin".ToUpper(),
                },
                new Role()
                {
                    Id = client_roleId,
                    Name = "Client",
                    ConcurrencyStamp = "2",
                    NormalizedName = "Client".ToUpper(),
                },
                new Role()
                {
                    Id = manager_roleId,
                    Name = "Manager",
                    ConcurrencyStamp = "3",
                    NormalizedName = "Manager".ToUpper(),
                });
        }

        private static void AddAdmin(this ModelBuilder modelBuilder, DefaultAdminSettings defaultAdminSettings)
        {
            User admin = new User()
            {
                Id = adminId,
                UserName = defaultAdminSettings.Username,
                NormalizedUserName = defaultAdminSettings.Username.ToUpper(),
                FirstName = defaultAdminSettings.FirstName,
                LastName = defaultAdminSettings.LastName,
                Email = defaultAdminSettings.Email,
                NormalizedEmail = defaultAdminSettings.Email.ToUpper(),
                SecurityStamp = admin_securityStamp,
            };

            admin.PasswordHash = _passwordHasher.HashPassword(admin, defaultAdminSettings.Password);

            modelBuilder.Entity<User>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
            new IdentityUserRole<Guid>()
            {
                RoleId = admin_roleId,
                UserId = adminId
            });
        }

        private static void AddUsers(this ModelBuilder modelBuilder)
        {
            #region Users

            User user1 = new User()
            {
                Id = user1Id,
                UserName = "user1@gmail.com",
                NormalizedUserName = "user1@gmail.com".ToUpper(),
                FirstName = "Oleksandr",
                LastName = "Bendujik",
                Email = "user1@gmail.com",
                NormalizedEmail = "user1@gmail.com".ToUpper(),
                SecurityStamp = user1_securityStamp,
            };
            user1.PasswordHash = _passwordHasher.HashPassword(user1, "asdASD123!");

            User user2 = new User()
            {
                Id = user2Id,
                UserName = "user2@gmail.com",
                NormalizedUserName = "user2@gmail.com".ToUpper(),
                FirstName = "Harry",
                LastName = "Evans",
                Email = "user2@gmail.com",
                NormalizedEmail = "user2@gmail.com".ToUpper(),
                SecurityStamp = user2_securityStamp,
            };
            user2.PasswordHash = _passwordHasher.HashPassword(user2, "asdASD124!");

            User user3 = new User()
            {
                Id = user3Id,
                UserName = "user3@gmail.com",
                NormalizedUserName = "user3@gmail.com".ToUpper(),
                FirstName = "Olga",
                LastName = "Strange",
                Email = "user3@gmail.com",
                NormalizedEmail = "user3@gmail.com".ToUpper(),
                SecurityStamp = user3_securityStamp,
            };
            user3.PasswordHash = _passwordHasher.HashPassword(user3, "asdASD125!");

            User user4 = new User()
            {
                Id = user4Id,
                UserName = "manager@gmail.com",
                NormalizedUserName = "manager@gmail.com".ToUpper(),
                FirstName = "Hloya",
                LastName = "Abrams",
                Email = "manager@gmail.com",
                NormalizedEmail = "manager@gmail.com".ToUpper(),
                SecurityStamp = user4_securityStamp,
            };
            user4.PasswordHash = _passwordHasher.HashPassword(user4, "asdASD126!");

            modelBuilder.Entity<User>().HasData(user1, user2, user3, user4);

            #endregion Users

            #region Role Assignment

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
            new IdentityUserRole<Guid>()
            {
                RoleId = client_roleId,
                UserId = user1Id,
            },
            new IdentityUserRole<Guid>()
            {
                RoleId = client_roleId,
                UserId = user2Id,
            },
            new IdentityUserRole<Guid>()
            {
                RoleId = client_roleId,
                UserId = user3Id,
            },
            new IdentityUserRole<Guid>()
            {
                RoleId = manager_roleId,
                UserId = user4Id,
            });

            #endregion Role Assignment
        }
    }
}
