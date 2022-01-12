using film_theater.Auth.Model;
using film_theater.Data.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Data.Entities
{
    public class Theater : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime CreationTimeUtc { get; set; }

        public string UserId { get; set; }
        //public User User { get; set; }
    }
}
