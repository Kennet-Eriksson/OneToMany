using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgetTest05.Data;
using EgetTest05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EgetTest05.Pages.Cities
{
    public class AddCityModel : PageModel
    {
        private readonly EgetTest05Context _context;

        public AddCityModel(EgetTest05Context context)
        {
            _context = context;
        }

        public IList<Country> Countries { get; set; }

        public async Task OnGetAsync()
        {
            Countries = await _context.Country.ToListAsync().ConfigureAwait(true);
        }

        // -----------------------------------------------------------------------------------------------------------------------

        [BindProperty]
        public int CId { get; set; }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("AddCityFcn", new { CId});
        }
    }
}