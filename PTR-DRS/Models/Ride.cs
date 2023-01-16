using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTR_DRS.Models
{
    public class Ride
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int KM { get; set; }
        public string Group { get; set; }
    }
}
