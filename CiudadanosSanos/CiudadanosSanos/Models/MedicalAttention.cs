using System.ComponentModel.DataAnnotations;
using System;

namespace CiudadanosSanos.Models
{
	public class MedicalAttention
	{
		public int Id { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Creation Date")]
		public DateTime? Fecha { get; set; }

		[Display(Name = "Medic Name")]
		[Required(ErrorMessage = "The Medic Name is required")]
		public string MedicName { get; set; }

		public int PatientId { get; set; }
		public Patient Patient { get; set; }
	}
}
