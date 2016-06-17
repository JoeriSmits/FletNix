using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FletNix.Models
{
    public class FletNixContextSeedData
    {
        private FletNixContext _context;
        private UserManager<FletNixUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public FletNixContextSeedData(FletNixContext context, RoleManager<IdentityRole> roleManager, UserManager<FletNixUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                IdentityRole newRole = new IdentityRole("Admin");

                await _roleManager.CreateAsync(newRole);
            }

            if (!await _roleManager.RoleExistsAsync("Customer"))
            {
                IdentityRole newRole = new IdentityRole("Customer");

                await _roleManager.CreateAsync(newRole);
            }

            if (await _userManager.FindByEmailAsync("joeri.smits@planet.nl") == null)
            {
                var newUser = new FletNixUser()
                {
                    UserName = "JoeriSmits",
                    Email = "joeri.smits@planet.nl"
                };

                await _userManager.CreateAsync(newUser, "!Joeri1");
                await _userManager.AddToRoleAsync(newUser, "Customer");
            }

            if (await _userManager.FindByEmailAsync("admin@fletnix.nl") == null)
            {
                var newUser = new FletNixUser()
                {
                    UserName = "Admin",
                    Email = "admin@fletnix.nl"
                };

                await _userManager.CreateAsync(newUser, "!Admin1");
                await _userManager.AddToRoleAsync(newUser, "Admin");
            }
        }
    }
}
