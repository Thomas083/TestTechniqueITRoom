using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using TestTechniqueITRoom.Data;
using TestTechniqueITRoom.Models;

namespace TestTechniqueITRoom.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TableauAmortissementController : Controller
	{

		public TableauAmortissementController()
		{

		}

		// GET: TableauAmortissementController
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public JsonObject Index()
		{
			TableauAmortissement tableauAmortissement = new TableauAmortissement();
			JsonObject jsonObject = new JsonObject();
			JsonArray amortissementArray = new JsonArray();
			tableauAmortissement.echeance = 0;
			tableauAmortissement.capitalRestant = 100000;
			tableauAmortissement.interet = 0;
			tableauAmortissement.mensualite = 1000;
			tableauAmortissement.taux = 3;

			while (tableauAmortissement.capitalRestant > 0)
			{
				tableauAmortissement.echeance += 1;
				tableauAmortissement.interet = Math.Round((tableauAmortissement.capitalRestant * tableauAmortissement.taux / 100) / 12, 2);
				tableauAmortissement.capital = tableauAmortissement.mensualite - tableauAmortissement.interet;

				if (tableauAmortissement.capitalRestant < tableauAmortissement.capital)
				{
					tableauAmortissement.capital = tableauAmortissement.capitalRestant;
					tableauAmortissement.mensualite = tableauAmortissement.capital + tableauAmortissement.interet;
				}

				tableauAmortissement.capitalRestant -= tableauAmortissement.capital;

				JsonObject amortissementObject = new JsonObject()
				{
					{ "echeance", tableauAmortissement.echeance },
					{ "capitalRestant", tableauAmortissement.capitalRestant },
					{ "interet", tableauAmortissement.interet },
					{ "capital", tableauAmortissement.capital }
				};

				amortissementArray.Add(amortissementObject);
			}

			jsonObject.Add("tableauAmortissement", amortissementArray);
			jsonObject.Add("nombreEcheance", tableauAmortissement.echeance);

			return jsonObject;
		}
	}
}
