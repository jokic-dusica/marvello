using Marvello.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Marvello.Repository
{
    public class MarvelloDBContext : DbContext
    {

        public MarvelloDBContext(DbContextOptions<MarvelloDBContext> options)
            :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile( @"C:\Users\Dusica\marvello\marvello-ws\Marvello\Marvello\appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("DefaultMySqlConnection");
            optionsBuilder.UseMySql(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>().HasKey(sc => new { sc.ProjectId, sc.UserId });
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectsType { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
