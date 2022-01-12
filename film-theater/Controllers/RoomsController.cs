using AutoMapper;
using film_theater.Data.Repositories;
using film_theater.Data.Entities;
using film_theater.Data.Dtos.Rooms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using film_theater.Auth.Model;
using Microsoft.AspNetCore.Identity;
using film_theater.Data.Dtos.Auth;

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
    [Authorize(Roles = UserRoles.Moderator + "," + UserRoles.Admin)]
    [Route("api/theaters/{theaterId}/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly ITheatersRepository _theatersRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public RoomsController(ITheatersRepository theatersRepository,
            IRoomsRepository roomsRepository, IMapper mapper,
            IAuthorizationService authorizationService)
        {
            _theatersRepository = theatersRepository;
            _roomsRepository = roomsRepository;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAll(int theaterId)
        {
            var theaters = await _roomsRepository.GetAll(theaterId);

            // 200
            return Ok(theaters.Select(o => _mapper.Map<RoomDto>(o)));
        }

        // /api/theaters/1/Rooms/2
        [HttpGet("{roomId}")]
        public async Task<ActionResult<RoomDto>> Get(int theaterId, int roomId)
        {
            var room = await _roomsRepository.Get(theaterId, roomId);
            if (room == null) return NotFound();

            // 200
            return Ok(_mapper.Map<RoomDto>(room));
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> Post(int theaterId, CreateRoomDto roomDto)
        {
            var theater = await _theatersRepository.Get(theaterId);
            if (theater == null) return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, theater, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            var room = _mapper.Map<Room>(roomDto);
            room.TheaterId = theaterId;
            room.UserId = User.FindFirst(CustomClaims.UserId).Value;

            await _roomsRepository.Post(room);

            // 201
            return Created($"/api/theaters/{theaterId}/rooms/{room.Id}", _mapper.Map<RoomDto>(room));
        }

        [HttpPut("{roomId}")]
        public async Task<ActionResult<RoomDto>> Put(int theaterId, int roomId, UpdateRoomDto roomDto)
        {
            var room = await _roomsRepository.Get(theaterId, roomId);
            if (room == null) return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, room, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            _mapper.Map(roomDto, room);

            await _roomsRepository.Put(room);

            // 200
            return Ok(_mapper.Map<RoomDto>(room));
        }

        [HttpDelete("{roomId}")]
        public async Task<ActionResult> Delete(int theaterId, int roomId)
        {
            var room = await _roomsRepository.Get(theaterId, roomId);
            if (room == null) return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, room, PolicyNames.SameUser);
            if (!authorizationResult.Succeeded)
                return Forbid();

            await _roomsRepository.Delete(room);

            // 204
            return NoContent();
        }
    }
}
