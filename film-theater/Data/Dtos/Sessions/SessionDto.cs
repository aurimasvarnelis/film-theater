using film_theater.Data.Entities;
using System;

namespace film_theater.Data.Dtos.Sessions
{
    public record SessionDto(int Id, string FilmName, string StartTime);
}
