using System.Collections.Generic;

namespace CiudadanosSanos.Models
{
	public class CreateMedicAttention
	{
		public List<Patient> PatientList { get; set; }
		public MedicalAttention MedicalAttention { get; set; }
	}
}
