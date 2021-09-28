using film_theater.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Data.Repositories
{
    public interface ISessionsRepository
    {
        Task<IEnumerable<Session>> GetAll(int roomId);
        Task<Session> Get(int roomId, int sessionId);
        Task<Session> Post(Session session);
        Task<Session> Put(Session session);
        Task Delete(Session session);
    }

    public class SessionsRepository : ISessionsRepository
    {
        private readonly FilmTheaterContext _filmTheaterContext;

        public SessionsRepository(FilmTheaterContext filmTheaterContext)
        {
            _filmTheaterContext = filmTheaterContext;
        }

        public async Task<IEnumerable<Session>> GetAll(int roomId)
        {
            return await _filmTheaterContext.Sessions.Where(o => o.RoomId == roomId).ToListAsync();
        }

        public async Task<Session> Get(int roomId, int sessionId)
        {
            return await _filmTheaterContext.Sessions.FirstOrDefaultAsync(o => o.RoomId == roomId && o.Id == sessionId);
        }

        public async Task<Session> Post(Session session)
        {
            _filmTheaterContext.Sessions.Add(session);
            await _filmTheaterContext.SaveChangesAsync();
            return session;
        }

        public async Task<Session> Put(Session session)
        {
            _filmTheaterContext.Sessions.Update(session);
            await _filmTheaterContext.SaveChangesAsync();
            return session;
        }

        public async Task Delete(Session session)
        {
            _filmTheaterContext.Sessions.Remove(session);
            await _filmTheaterContext.SaveChangesAsync();
        }
    }
}
