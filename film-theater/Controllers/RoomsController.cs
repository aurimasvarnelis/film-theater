using AutoMapper;
using film_theater.Data.Repositories;
using film_theater.Data.Entities;
using film_theater.Data.Dtos.Rooms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Controllers
{
    /*
       rooms
       /api/theaters/{theaterId}/rooms GET ALL 200
       /api/theaters/{theaterId}/rooms/{roomId} GET 200
       /api/theaters/{theaterId}/rooms POST 201
       /api/theaters/{theaterId}/rooms/{roomId} PUT 200
       /api/theaters/{theaterId}/rooms/{roomId} DELETE 200/204     
    */
    [ApiController]
    [Route("api/theaters/{theaterId}/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly ITheatersRepository _theatersRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly IMapper _mapper;

        public RoomsController(ITheatersRepository theatersRepository, IRoomsRepository roomsRepository, IMapper mapper)
        {
            _theatersRepository = theatersRepository;
            _roomsRepository = roomsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomDto>> GetAll(int theaterId)
        {
            var theaters = await _roomsRepository.GetAll(theaterId);

            // 200
            return theaters.Select(o => _mapper.Map<RoomDto>(o));
        }

        // /api/theaters/1/Rooms/2
        [HttpGet("{roomId}")]
        public async Task<ActionResult<RoomDto>> Get(int theaterId, int roomId)
        {
            var theater = await _roomsRepository.Get(theaterId, roomId);
            if (theater == null) return NotFound();

            // 200
            return Ok(_mapper.Map<RoomDto>(theater));
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> Post(int theaterId, CreateRoomDto roomDto)
        {
            var theater = await _theatersRepository.Get(theaterId);
            if (theater == null) return NotFound();

            var room = _mapper.Map<Room>(roomDto);
            room.TheaterId = theaterId;

            await _roomsRepository.Post(room);

            // 201
            return Created($"/api/theaters/{theaterId}/rooms/{room.Id}", _mapper.Map<RoomDto>(room));
        }

        [HttpPut("{roomId}")]
        public async Task<ActionResult<RoomDto>> Put(int theaterId, int roomId, UpdateRoomDto roomDto)
        {
            var theater = await _theatersRepository.Get(theaterId);
            if (theater == null) return NotFound();

            var oldRoom = await _roomsRepository.Get(theaterId, roomId);
            if (oldRoom == null) return NotFound();

            _mapper.Map(roomDto, oldRoom);

            await _roomsRepository.Put(oldRoom);

            // 200
            return Ok(_mapper.Map<RoomDto>(oldRoom));
        }

        [HttpDelete("{roomId}")]
        public async Task<ActionResult> Delete(int theaterId, int roomId)
        {
            var room = await _roomsRepository.Get(theaterId, roomId);
            if (room == null) return NotFound();

            await _roomsRepository.Delete(room);

            // 204
            return NoContent();
        }
    }
}
