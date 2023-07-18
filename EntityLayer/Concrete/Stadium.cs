using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Stadium
    {
        public int StadiumID { get; set; }
        public string? City { get; set; }
        public string Name { get; set; }
        public string Capacity { get; set; }
        public string? ImageURL { get; set; }
    }
}
