using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTR_DRS.Models
{
    public class Ranking
    {
        public Rider Rider { get; set; }
        public int? TotalKM { get; set; }
        public int? TotalRides { get; set; }
    }
}
