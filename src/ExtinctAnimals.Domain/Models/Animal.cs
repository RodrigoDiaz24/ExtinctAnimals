using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctAnimals.Domain.Models
{
    public class Animal
    {
        public string BinomialName { get; set; }
        public string CommonName { get; set; }
        public string Location { get; set; }
        public string WikiLink { get; set; }
        public string LastRecord { get; set; }
        public string ImageSrc { get; set; }
        public string ShortDescription { get; set; }
    }
}
