using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EgetTest05.Data;
using EgetTest05.Models;

namespace EgetTest05.Pages.Cities
{
    public class CreateModel : PageModel
    {
        private readonly EgetTest05.Data.EgetTest05Context _context;

        public CreateModel(EgetTest05.Data.EgetTest05Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CountryID"] = new SelectList(_context.Country, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public City City { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.City.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
