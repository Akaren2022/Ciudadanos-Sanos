using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.Account
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public User User { get; set; }
		public string Email = "", Password = "";
		public void OnGet()
		{
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid) return Page();

			string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CiudadanosSanosDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
			using (var connection = new SqlConnection(connectionString))
			using (var command = new SqlCommand())
			{
				connection.Open();
				command.Connection = connection;
				command.CommandText = @"SELECT Email,Password FROM CiudadanosSanosDB.dbo.Users WHERE Email = @email";
				command.Parameters.Add("@email", SqlDbType.NVarChar).Value = User.Email;
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Email = reader.GetString(0);
						Password = reader.GetString(1);
					}
				}
			}
			if (User.Email == Email && User.Password == Password)
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
