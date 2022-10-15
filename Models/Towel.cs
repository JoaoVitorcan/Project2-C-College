using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TOWELS.Models
{
    public class Towel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Color { get; set; }

        public string size { get; set; }

        public string tissue { get; set; }

        public int review { get; set; }
    }
}
