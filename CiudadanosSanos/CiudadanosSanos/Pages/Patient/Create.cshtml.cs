using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.Patient
{
    public class CreateModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public CreateModel(CiudadanosSanosContext context)
		{
			_context = context;
		}
		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Models.Patient Patients { get; set; } = default!;
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Patients == null || Patients == null)
			{
				return Page();
			}
			_context.Patients.Add(Patients);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
