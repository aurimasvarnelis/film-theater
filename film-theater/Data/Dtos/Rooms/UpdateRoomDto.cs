using System;
using System.ComponentModel.DataAnnotations;

namespace film_theater.Data.Dtos.Rooms
{
    public record UpdateRoomDto(string Name, int Capacity,
        string RoomType);
}
