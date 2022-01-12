using film_theater.Data.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using film_theater.Auth.Model;

namespace film_theater.Data.Entities
{
    public class Room : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string RoomType { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }

        public string UserId { get; set; }
        //public User User { get; set; }
    }   
}
