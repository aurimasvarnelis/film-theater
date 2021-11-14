using AutoMapper;
using film_theater.Data.Dtos.Sessions;
using film_theater.Data.Dtos.Theaters;
using film_theater.Data.Entities;
using film_theater.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Controllers
{
    /*
       sessions
       /api/theaters/{theaterId}/rooms/{roomId}/sessions GET ALL 200
       /api/theaters/{theaterId}/rooms/{roomId}/sessions/{sessionId} GET 200
       /api/theaters/{theaterId}/rooms/{roomId}/sessions POST 201
       /api/theaters/{theaterId}/rooms/{roomId}/sessions/{sessionId} PUT 200
       /api/theaters/{theaterId}/rooms/{roomId}/sessions/{sessionId} DELETE 200/204     
    */
    [ApiController]
    [Route("api/theaters/{theaterId}/rooms/{roomId}/sessions")]
    public class SessionsController : ControllerBase
    {
        private readonly ITheatersRepository _theatersRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly ISessionsRepository _sessionsRepository;
        private readonly IMapper _mapper;

        public SessionsController(ITheatersRepository theatersRepository, IRoomsRepository roomsRepository,
            ISessionsRepository sessionsRepository, IMapper mapper)
        {
            _theatersRepository = theatersRepository;
            _roomsRepository = roomsRepository;
            _sessionsRepository = sessionsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SessionDto>> GetAll(int roomId)
        {
            var rooms = await _sessionsRepository.GetAll(roomId);

            // 200
            return rooms.Select(o => _mapper.Map<SessionDto>(o));
        }

        [HttpGet("{sessionId}")]
        public async Task<ActionResult<SessionDto>> Get(int roomId, int sessionId)
        {
            var room = await _sessionsRepository.Get(roomId, sessionId);
            if (room == null) return NotFound();

            // 200
            return Ok(_mapper.Map<SessionDto>(room));
        }

        [HttpPost]
        public async Task<ActionResult<SessionDto>> Post(int theaterId, int roomId, int sessionId, CreateSessionDto sessionDto)
        {
            var theater = await _theatersRepository.Get(theaterId);
            if (theater == null) return NotFound();

            var room = await _roomsRepository.Get(theaterId, roomId);
            if (room == null) return NotFound();

            var session = _mapper.Map<Session>(sessionDto);
            session.RoomId = roomId;

            await _sessionsRepository.Put(session);

            // 201
            return Created($"/api/theaters/{theaterId}/rooms/{roomId}/sessions/{session.Id}", _mapper.Map<SessionDto>(session));
        }

        [HttpPut("{sessionId}")]
        public async Task<ActionResult<SessionDto>> Put(int theaterId, int roomId, int sessionId, UpdateSessionDto sessionDto)
        {
            var theater = await _theatersRepository.Get(theaterId);
            if (theater == null) return NotFound();

            var room = await _roomsRepository.Get(theaterId, roomId);
            if (room == null) return NotFound();

            var oldSession = await _sessionsRepository.Get(roomId, sessionId);
            if (oldSession == null) return NotFound();

            //oldRoom.Body = RoomDto.Body;
            _mapper.Map(sessionDto, oldSession);

            await _sessionsRepository.Put(oldSession);

            // 200
            return Ok(_mapper.Map<SessionDto>(oldSession));
        }

        [HttpDelete("{sessionId}")]
        public async Task<ActionResult> Delete(int theaterId, int roomId, int sessionId)
        {
            var theater = await _theatersRepository.Get(theaterId);
            if (theater == null) return NotFound();

            var room = await _roomsRepository.Get(theaterId, roomId);
            if (room == null) return NotFound();

            var session = await _sessionsRepository.Get(roomId, sessionId);
            if (session == null) return NotFound();

            await _sessionsRepository.Delete(session);

            // 204
            return NoContent();
        }
    }
}
