using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTechniqueITRoom.Data;


namespace TestTechniqueITRoom.Migrations
{
	[DbContext(typeof(AppDbContext))]
	partial class AppDbContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
			#region Generated Code
			modelBuilder.Entity("TestTechniqueITRoom.Models.TableauAmortissement", b =>
			{
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<int>("capital");

				b.Property<int>("capitalRestant");

				b.Property<int>("echeance");

				b.Property<int>("interet");

				b.Property<int>("taux");

				b.HasKey("Id");

				b.ToTable("TableauAmortissements");
			});
			#endregion
		}
	}

}
