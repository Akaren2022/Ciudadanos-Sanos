using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.MedicalAttention
{
	[Authorize]
	public class IndexModel : PageModel
    {
		private readonly CiudadanosSanosContext _context;
		public IndexModel(CiudadanosSanosContext context)
		{
			_context = context;
		}
		public IEnumerable<Models.MedicalAttention> MedicalAttentions { get; set; }
		public async Task OnGet()
		{
			MedicalAttentions = await _context.MedicalAttentions.Include(c => c.Patient).ToListAsync();
		}
	}
}
