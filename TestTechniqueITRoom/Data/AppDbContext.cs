using Microsoft.EntityFrameworkCore;
using TestTechniqueITRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TestTechniqueITRoom.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<TableauAmortissement> TableauAmortissements { get; set; }
	}
}
