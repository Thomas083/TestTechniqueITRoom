using System.ComponentModel.DataAnnotations;

namespace TestTechniqueITRoom.Models
{
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
