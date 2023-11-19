using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.Account
{
    public class CreateUserModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public CreateUserModel(CiudadanosSanosContext context)
		{
			_context = context;
		}
		public IActionResult OnGet()
		{
			return Page();
		}
		[BindProperty]
		public User User { get; set; } = default!;
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Users == null || User == null)
			{
				return Page();
			}
			_context.Users.Add(User);
			await _context.SaveChangesAsync();

			return RedirectToPage("/Account/Login");
		}
	}
}
