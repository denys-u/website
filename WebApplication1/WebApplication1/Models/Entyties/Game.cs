using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entyties
{
    public class Game
    {
        public string Id { get; set; }

        public int Name { get; set; }

        public double Price { get; set; }

        public string Rating { get; set; }

        public string Genre { get; set; }

        public string Developer { get; set; }

        public DateTime Release { get; set; }

    }
}
