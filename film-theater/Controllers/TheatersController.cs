using AutoMapper;
using film_theater.Data.Dtos.Theaters;
using film_theater.Data.Entities;
using film_theater.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace film_theater.Controllers
{
    /*
       theaters
       /api/theaters GET ALL 200
       /api/theaters/{theaterId} GET 200
       /api/theaters POST 201
       /api/theaters/{theaterId} PUT 200
       /api/theaters/{theaterId} DELETE 200/204     
    */
    [ApiController]
    [Route("api/theaters")]
    public class TheatersController : ControllerBase
    {
        private readonly ITheatersRepository _theatersRepository;
        private readonly IMapper _mapper;

        public TheatersController(ITheatersRepository theatersRepository, IMapper mapper)
        {
            _theatersRepository = theatersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TheaterDto>> GetAll()
        {
            return (await _theatersRepository.GetAll()).Select(o => _mapper.Map<TheaterDto>(o));
        }

        [HttpGet("{theaterId}")]
        public async Task<ActionResult<TheaterDto>> Get(int theaterId)
        {
            var theater = await _theatersRepository.Get(theaterId);
            if (theater == null) return NotFound();

            // 200
            return Ok(_mapper.Map<TheaterDto>(theater));
        }

        [HttpPost]
        public async Task<ActionResult<TheaterDto>> Post(CreateTheaterDto theaterDto)
        {
            var theater = _mapper.Map<Theater>(theaterDto);

            await _theatersRepository.Post(theater);

            // 201
            return Created($"/api/theaters/{theater.Id}", _mapper.Map<TheaterDto>(theater));
        }

        [HttpPut("{theaterId}")]
        public async Task<ActionResult<TheaterDto>> Put(int theaterId, UpdateTheaterDto theaterDto)
        {
            var theater = await _theatersRepository.Get(theaterId);
            if (theater == null) return NotFound();

            _mapper.Map(theaterDto, theater);

            await _theatersRepository.Put(theater);

            // 200
            return Ok(_mapper.Map<TheaterDto>(theater));
        }

        [HttpDelete("{theaterId}")]
        public async Task<ActionResult<TheaterDto>> Delete(int theaterId)
        {
            var theater = await _theatersRepository.Get(theaterId);
            if (theater == null) return NotFound();

            await _theatersRepository.Delete(theater);

            // 204
            return NoContent();
        }
    }
}
