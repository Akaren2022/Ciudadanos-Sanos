using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.MedicalAttention
{
    public class EditModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public EditModel(CiudadanosSanosContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Models.CreateMedicAttention MedicAttention { get; set; }
		public async Task<IActionResult> OnGet(int id)
		{
			MedicAttention = new CreateMedicAttention()
			{
				PatientList = await _context.Patients.ToListAsync(),
				MedicalAttention = await _context.MedicalAttentions.FindAsync(id)
			};
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(MedicAttention.MedicalAttention).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MedicAttentionExists(MedicAttention.MedicalAttention.Id))
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
		private bool MedicAttentionExists(int id)
		{
			return (_context.MedicalAttentions?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
