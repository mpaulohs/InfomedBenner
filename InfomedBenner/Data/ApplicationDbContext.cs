using System;
using System.Collections.Generic;
using System.Text;
using InfomedBenner.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfomedBenner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RedeUnimed> RedeUnimed { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
    }
}
