using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgetTest05.Data;
using EgetTest05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EgetTest05.Pages.Countries
{
    public class ShowCitiesFcnModel : PageModel
    {
        private readonly EgetTest05Context _context;

        public ShowCitiesFcnModel(EgetTest05Context context)
        {
            _context = context;
        }

        public Country Country { get; set; }
        public string CountryName { get; set; }
        public IList<City> Cities { get; set; }
        public async Task OnGetAsync(int CId)
        {
            Country = await _context.Country.Where(c => c.Id == CId).FirstOrDefaultAsync().ConfigureAwait(true);
            CountryName = Country.Name;
            Cities = await _context.City.Where(c => c.CountryID == CId).ToListAsync().ConfigureAwait(true);
        }
    }
}