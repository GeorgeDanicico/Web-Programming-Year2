using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }

        public string Country { get; set; }

        public string TouristTarget { get; set; }

        public int EstimatedCost { get; set; }

    }
}
