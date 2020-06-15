using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgetTest05.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<City> City { get; set; }
    }
}
