using film_theater.Data.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using film_theater.Auth.Model;

namespace film_theater.Data.Entities
{
    public class Session : IUserOwnedResource
    {
        public int Id { get; set; }
        public string FilmName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public string UserId { get; set; }
        //public User User { get; set; }
    }
}
