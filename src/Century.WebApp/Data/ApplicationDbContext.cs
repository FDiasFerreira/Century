using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Century.WebApp.Models;

namespace Century.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Century.WebApp.Models.AddressViewModel> AddressViewModel { get; set; }
        public DbSet<Century.WebApp.Models.EmailViewModel> EmailViewModel { get; set; }
        public DbSet<Century.WebApp.Models.PhoneViewModel> PhoneViewModel { get; set; }
        //public DbSet<Century.WebApp.Models.AddressViewModel> AddressViewModel { get; set; }
        
        
    }
}
