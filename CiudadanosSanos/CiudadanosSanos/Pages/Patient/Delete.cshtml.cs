using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.Patient
{
    public class DeleteModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public DeleteModel(CiudadanosSanosContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Models.Patient Patients { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Patients == null)
			{
				return NotFound();
			}
			var patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);

			if (patient == null)
			{
				return NotFound();
			}
			else
			{
				Patients = patient;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Patients == null)
			{
				return NotFound();
			}
			var patient = await _context.Patients.FindAsync(id);
			if (patient != null)
			{
				Patients = patient;
				_context.Patients.Remove(Patients);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
	}
}
