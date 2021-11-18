using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Data.Dtos.Auth
{
    public class User : IdentityUser
    {
        public string AdditionalInfo { get; set; }
    }
}
