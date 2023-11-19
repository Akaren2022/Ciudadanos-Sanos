using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CiudadanosSanos.Models
{
	public class Patient
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "The Name is required")]
		public string Name { get; set; }
		public ICollection<MedicalAttention> MedicalAttentions { get; set; }
	}
}
