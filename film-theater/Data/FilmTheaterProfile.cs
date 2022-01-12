using AutoMapper;
using film_theater.Data.Dtos.Theaters;
using film_theater.Data.Dtos.Rooms;
using film_theater.Data.Dtos.Sessions;
using film_theater.Data.Entities;
using film_theater.Data.Dtos.Auth;

namespace film_Theater.Data
{
    public class FilmTheaterProfile : Profile
    {
        public FilmTheaterProfile()
        {
            CreateMap<Theater, TheaterDto>();
            CreateMap<CreateTheaterDto, Theater>();
            CreateMap<UpdateTheaterDto, Theater>();

            CreateMap<Room, RoomDto>();
            CreateMap<CreateRoomDto, Room>();
            CreateMap<UpdateRoomDto, Room>();

            CreateMap<Session, SessionDto>();
            CreateMap<CreateSessionDto, Session>();
            CreateMap<UpdateSessionDto, Session>();

            CreateMap<User, UserDto>();
        }
    }
}
