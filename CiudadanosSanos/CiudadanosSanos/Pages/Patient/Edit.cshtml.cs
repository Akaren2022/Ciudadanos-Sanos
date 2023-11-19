using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.Patient
{
    public class EditModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public EditModel(CiudadanosSanosContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Models.Patient Patient { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Patients == null)
			{
				return NotFound();
			}
			var cliente = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);

			if (cliente == null)
			{
				return NotFound();
			}
			Patient = cliente;
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(Patient).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PatientExists(Patient.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToPage("./Index");
		}
		private bool PatientExists(int id)
		{
			return (_context.Patients?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
