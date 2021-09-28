using film_theater.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Data.Repositories
{
    public interface IRoomsRepository
    {
        Task<IEnumerable<Room>> GetAll(int theaterId);
        Task<Room> Get(int theaterId, int roomId);
        Task<Room> Post(Room room);
        Task<Room> Put(Room room);
        Task Delete(Room room);
    }

    public class RoomsRepository : IRoomsRepository
    {
        private readonly FilmTheaterContext _filmTheaterContext;

        public RoomsRepository(FilmTheaterContext filmTheaterContext)
        {
            _filmTheaterContext = filmTheaterContext;
        }

        public async Task<IEnumerable<Room>> GetAll(int theaterId)
        {
            return await _filmTheaterContext.Rooms.Where(o => o.TheaterId == theaterId).ToListAsync();
        }

        public async Task<Room> Get(int theaterId, int roomId)
        {
            return await _filmTheaterContext.Rooms.FirstOrDefaultAsync(o => o.TheaterId == theaterId && o.Id == roomId);
        }

        public async Task<Room> Post(Room room)
        {
            _filmTheaterContext.Rooms.Add(room);
            await _filmTheaterContext.SaveChangesAsync();
            return room;
        }

        public async Task<Room> Put(Room room)
        {
            _filmTheaterContext.Rooms.Update(room);
            await _filmTheaterContext.SaveChangesAsync();
            return room;
        }

        public async Task Delete(Room room)
        {
            _filmTheaterContext.Rooms.Remove(room);
            await _filmTheaterContext.SaveChangesAsync();
        }
    }
}
