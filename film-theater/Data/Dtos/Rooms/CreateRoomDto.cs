using System;
using System.ComponentModel.DataAnnotations;

namespace film_theater.Data.Dtos.Rooms
{
    public record CreateRoomDto(string Name, int Capacity,
        string RoomType);
}
