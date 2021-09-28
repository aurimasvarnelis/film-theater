using System;

namespace film_theater.Data.Dtos.Rooms
{
    public record RoomDto(int Id, string Name, string Authors,
        string Distributor, string AgeCensus, DateTime RepertoireStart,
        string Description);
}
