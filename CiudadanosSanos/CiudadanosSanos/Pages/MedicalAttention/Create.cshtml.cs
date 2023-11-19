using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.MedicalAttention
{
    public class CreateModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public CreateModel(CiudadanosSanosContext context)
		{
			_context = context;
		}

		[BindProperty]
		public CreateMedicAttention MedicAttention { get; set; }
		public async Task<IActionResult> OnGet()
		{
			MedicAttention = new CreateMedicAttention()
			{
				PatientList = await _context.Patients.ToListAsync(),
				MedicalAttention = new Models.MedicalAttention()
			};
			return Page();
		}
		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				await _context.MedicalAttentions.AddAsync(MedicAttention.MedicalAttention);
				await _context.SaveChangesAsync();
				return RedirectToPage("./Index");
			}
			else
			{
				return Page();
			}
		}
	}
}
