using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Data.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Authors { get; set; }
        public string Distributor { get; set; }
        public string AgeCensus { get; set; }
        public DateTime RepertoireStart { get; set; }
        public string Description { get; set; }
        public DateTime CreationTimeUtc { get; set; }
    }
}
