using System;
using System.ComponentModel.DataAnnotations;

namespace film_theater.Data.Dtos.Rooms
{
    public record CreateRoomDto(string Name, string Authors,
        string Distributor, string AgeCensus, DateTime RepertoireStart,
        string Description);
}
