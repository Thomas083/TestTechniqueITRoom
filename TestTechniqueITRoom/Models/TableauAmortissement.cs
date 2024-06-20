using System.ComponentModel.DataAnnotations;

namespace TestTechniqueITRoom.Models
{
	//TODO: Need to be rounded to 2 decimal places so we need to change the type of the properties to double for the properties interet, capital, mensualite and capitalRestant
	public class TableauAmortissement
	{
		[Key]
		public int Id { get; set; }
		public int echeance { get; set; }
		public int capitalRestant { get; set; }
		public int interet { get; set; }
		public int capital { get; set; }
		public int mensualite { get; set; }
		public int taux { get; set; }
	}
}
