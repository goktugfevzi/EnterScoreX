using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Number { get; set; }
        public string? Nationality { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }


        [NotMapped]
        public IFormFile? Photo { get; set; }
        public string? SavedUrl { get; set; }

        [NotMapped]
        public string? SignedUrl { get; set; }
        public string? SavedFileName { get; set; }


        public int? TeamID { get; set; }
        public Team Team { get; set; }

        public int PositionID { get; set; }
        public Position Position { get; set; }

    }
}
