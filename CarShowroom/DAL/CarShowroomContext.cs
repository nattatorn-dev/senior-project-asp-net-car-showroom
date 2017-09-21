using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using CarShowroom.Models;

namespace CarShowroom.DAL
{
	public class CarShowroomContext : DbContext
	{
		public CarShowroomContext() : base("CarShowroomContext")
		{
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<Worker> Workers { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<Purchase> Purchases { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}