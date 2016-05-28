using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace FletNix.Models
{
    public class FletNixContextSeedData
    {
        private FletNixContext _context;
        private UserManager<FletNixUser> _userManager;

        public FletNixContextSeedData(FletNixContext context, UserManager<FletNixUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("joeri.smits@planet.nl") == null)
            {
                var newUser = new FletNixUser()
                {
                    UserName = "JoeriSmits",
                    Email = "joeri.smits@planet.nl",
                };

                await _userManager.CreateAsync(newUser, "!Joeri1");
            }
        }
    }
}
