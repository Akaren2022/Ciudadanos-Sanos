using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.MedicalAttention
{
    public class DeleteModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public DeleteModel(CiudadanosSanosContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Models.MedicalAttention MedicalAttention { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.MedicalAttentions == null)
			{
				return NotFound();
			}
			var medic = await _context.MedicalAttentions.FirstOrDefaultAsync(m => m.Id == id);

			if (medic == null)
			{
				return NotFound();
			}
			else
			{
				MedicalAttention = medic;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.MedicalAttentions == null)
			{
				return NotFound();
			}
			var medic = await _context.MedicalAttentions.FindAsync(id);
			if (medic != null)
			{
				MedicalAttention = medic;
				_context.MedicalAttentions.Remove(MedicalAttention);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
	}
}
