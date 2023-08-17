using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager,
                                   RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                ApplicationUser user = new();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Zaira#2023").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationUser admin = new();
                admin.UserName = "admin@localhost";
                admin.Email = "admin@localhost";
                admin.NormalizedUserName = "ADMIN@LOCALHOST";
                admin.NormalizedEmail = "ADMIN@LOCALHOST";
                admin.EmailConfirmed = true;
                admin.LockoutEnabled = false;
                admin.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(admin, "Zaira#2023").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new()
                {
                    Name = "User",
                    NormalizedName = "USER"
                };

                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

    }
}
