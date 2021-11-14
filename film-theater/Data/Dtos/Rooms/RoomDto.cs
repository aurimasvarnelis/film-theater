using System;

namespace film_theater.Data.Dtos.Rooms
{
    public record RoomDto(int Id, string Name, int Capacity,
        string RoomType);
}
