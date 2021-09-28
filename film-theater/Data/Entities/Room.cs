using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string RoomType { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }
    }   
}
