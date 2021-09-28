using film_theater.Data.Entities;
using System;

namespace film_theater.Data.Dtos.Sessions
{
    public record UpdateSessionDto(Film Film, TimeSpan TimeSpan);
}
