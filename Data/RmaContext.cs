using System.IO;
using Microsoft.Data.Entity;
using Microsoft.Extensions.PlatformAbstractions;
using RmaManager.Models;

namespace RmaManager.Data
{
	public class RmaContext : DbContext
	{
		public RmaContext()
		{			
		}
		protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.Entity<Rma>().HasKey(m => m.Id);
			builder.Entity<HardwareType>().HasKey(m => m.Id);
			
            base.OnModelCreating(builder); 
        } 
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var path = PlatformServices.Default.Application.ApplicationBasePath;
            optionsBuilder.UseSqlite("Filename=" + Path.Combine(path, "app.db"));
		}
		public DbSet<Rma> Rmas {get;set;}
		public DbSet<HardwareType> HardwareTypes { get; set; }
	}
}