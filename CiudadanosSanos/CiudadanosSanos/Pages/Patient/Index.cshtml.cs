using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.Patient
{
	[Authorize]
	public class IndexModel : PageModel
    {
        private readonly CiudadanosSanosContext _context;

        public IndexModel(CiudadanosSanosContext context)
		{
			_context = context;
		}
        public IList<Models.Patient> Patient { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.Patients != null)
			{
				Patient = await _context.Patients.ToListAsync();
			}
		}
	}
}
