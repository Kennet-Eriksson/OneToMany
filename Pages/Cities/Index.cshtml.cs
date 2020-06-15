using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EgetTest05.Data;
using EgetTest05.Models;

namespace EgetTest05.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly EgetTest05.Data.EgetTest05Context _context;

        public IndexModel(EgetTest05.Data.EgetTest05Context context)
        {
            _context = context;
        }

        public IList<City> City { get;set; }

        public async Task OnGetAsync()
        {
            City = await _context.City
                .Include(c => c.Country).ToListAsync();
        }
    }
}
