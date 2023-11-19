using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.Account
{
    public class LogoutModel : PageModel
    {
		public async Task<IActionResult> OnPostAsync()
		{
			await HttpContext.SignOutAsync("MyCookieAuth");
			return RedirectToAction("/Index");
		}
	}
}
