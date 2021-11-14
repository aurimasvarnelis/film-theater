using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Data.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public string FilmName { get; set; }
        public string StartTime { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
