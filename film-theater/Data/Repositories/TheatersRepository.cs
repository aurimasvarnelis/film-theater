using film_theater.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Data.Repositories
{
    public interface ITheatersRepository
    {
        Task<IEnumerable<Theater>> GetAll();
        Task<Theater> Get(int theaterId);
        Task<Theater> Post(Theater theater);
        Task<Theater> Put(Theater theater);
        Task Delete(Theater theater);
    }

    public class TheatersRepository : ITheatersRepository
    {
        private readonly FilmTheaterContext _filmTheaterContext;

        public TheatersRepository(FilmTheaterContext filmTheaterContext)
        {
            _filmTheaterContext = filmTheaterContext;
        }

        public async Task<IEnumerable<Theater>> GetAll()
        {
            return await _filmTheaterContext.Theaters.ToListAsync();
        }

        public async Task<Theater> Get(int theaterId)
        {
            return await _filmTheaterContext.Theaters.FirstOrDefaultAsync(o => o.Id == theaterId);
        }

        public async Task<Theater> Post(Theater theater)
        {
            _filmTheaterContext.Theaters.Add(theater);
            await _filmTheaterContext.SaveChangesAsync();
            return theater;
        }

        public async Task<Theater> Put(Theater theater)
        {
            _filmTheaterContext.Theaters.Update(theater);
            await _filmTheaterContext.SaveChangesAsync();
            return theater;
        }

        public async Task Delete(Theater theater)
        {
            _filmTheaterContext.Theaters.Remove(theater);
            await _filmTheaterContext.SaveChangesAsync();
        }

    }
}
