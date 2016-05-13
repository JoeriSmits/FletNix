using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FletNix.Models
{
    public class FletNixUser : IdentityUser
    {
        public DateTime LastOnline { get; set; }
    }
}