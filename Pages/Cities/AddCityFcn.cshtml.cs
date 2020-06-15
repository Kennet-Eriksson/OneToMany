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
    public class AddCityFcnModel : PageModel
    {
        private readonly EgetTest05Context _context;

        public AddCityFcnModel(EgetTest05Context context)
        {
            _context = context;
        }

        public IList<City> Cities { get; set; }
        public IList<City> CitiesInCountry { get; set; }
        public IList<int> CitiesId { get; set; }
        public Country Country { get; set; }

        public int CountryId { get; set; }
        public async Task OnGetAsync(int CId)
        {
            Cities = await _context.City.ToListAsync().ConfigureAwait(true);                                            // All Cities
            Country = await _context.Country.Where(c => c.Id == CId).FirstOrDefaultAsync().ConfigureAwait(true);        // Chosen Country
            CitiesInCountry = await _context.City.Where(c => c.CountryID == CId).ToListAsync().ConfigureAwait(true);    // Cities already added to the chosen Country
            CountryId = CId;                                                                                            // Id of the chosen Country 
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------


        [BindProperty]
        public City City { get; set; }

        [BindProperty]
        public int CId { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Country = await _context.Country.Where(c => c.Id == CId).FirstOrDefaultAsync().ConfigureAwait(true);
            City.CountryID = CId;
            City.Country = Country;

            _context.City.Add(City);
            await _context.SaveChangesAsync().ConfigureAwait(true);

            return RedirectToPage("AddCityFcn", new { CId });
        }
    }
}