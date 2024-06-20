using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTechniqueITRoom.Data
{
	public class AppDbInitialize
	{
		public static void seed(IApplicationBuilder applicationBuilder)
		{

			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

				context.Database.EnsureCreated();

				if (!context.TableauAmortissements.Any())
				{
					context.TableauAmortissements.AddRange(new Models.TableauAmortissement()
					{
						echeance = 0,
						capitalRestant = 100000,
						interet = 0,
						capital = 0,
						taux = 3
					});
					context.SaveChanges();
				}
			}
		}
	}
}
