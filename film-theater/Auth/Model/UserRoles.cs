using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Auth.Model
{
    public static class UserRoles
    {
        public const string Admin = nameof(Admin);
        public const string Moderator = nameof(Moderator);

        public static readonly IReadOnlyCollection<string> All = new[] { Admin, Moderator };
    }
}
