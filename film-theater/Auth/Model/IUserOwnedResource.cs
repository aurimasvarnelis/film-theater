using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Auth.Model
{
    public interface IUserOwnedResource
    {
        string UserId { get; }
    }
}
