using DataAccess.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class SchoolDbContext : IdentityDbContext<IdentityUser>
    {
        IConfiguration _configuration;

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options, IConfiguration configuration)
       : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<LaboratoryEntity> LaboratoryEntities { get; set; }
        public DbSet<AssignmentEntity> AssignmentEntities { get; set; }
        public DbSet<StudentEntity> StudentEntities { get; set; }
        public DbSet<GradingEntity> GradingEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("connectionString"), b => b.MigrationsAssembly("LayersOnWeb"));
        }
    }
}
