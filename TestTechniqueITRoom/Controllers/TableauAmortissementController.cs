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
				//TODO: Need to be rounded to 2 decimal places
				tableauAmortissement.interet = (tableauAmortissement.capitalRestant * tableauAmortissement.taux / 100) / 12;
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
					//TODO: Need to be rounded to 2 decimal places
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
