using film_theater.Data.Entities;
using System;

namespace film_theater.Data.Dtos.Sessions
{
    public record CreateSessionDto(string FilmName, string StartTime);
}
