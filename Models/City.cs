using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgetTest05.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryID { get; set; }

        public Country Country { get; set; }
    }
}
