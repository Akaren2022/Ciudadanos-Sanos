using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.Account
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public User User { get; set; }
		public void OnGet()
		{
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid) return Page();

			if (User.Email == "correo@gmail.com" && User.Password == "12345")
			{
				var claims = new List<Claim> {
						new Claim(ClaimTypes.Name, "admin"),
						new Claim(ClaimTypes.Email, User.Email),
					};
				var identity = new ClaimsIdentity(claims, "MyCookieAuth");
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
				await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
				return RedirectToPage("/index");
			}
			return Page();
		}
	}
}