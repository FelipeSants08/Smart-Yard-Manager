using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Yard_Manager.Application.DTOs;
using Smart_Yard_Manager.Domain.Entity;
using Smart_Yard_Manager.Infrastructure.Context;

namespace Smart_Yard_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovimentController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimentResponseDto>>> GetAll()
        {
            var moviments = await _context.Moviments.Include(m => m.Sensor).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<MovimentResponseDto>>(moviments));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MovimentResponseDto>> GetById(Guid id)
        {
            var moviment = await _context.Moviments.Include(m => m.Sensor).FirstOrDefaultAsync(m => m.Id == id);
            if (moviment == null) return NotFound();

            return Ok(_mapper.Map<MovimentResponseDto>(moviment));
        }

        [HttpPost]
        public async Task<ActionResult> Create(MovimentRequestDto dto)
        {
            var sensor = await _context.Sensors.FindAsync(dto.SensorId);
            if (sensor == null) return BadRequest("Sensor não encontrado.");

            var moviment = _mapper.Map<Moviment>(dto);
            moviment.Id = Guid.NewGuid();
            moviment.Sensor = sensor;

            _context.Moviments.Add(moviment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = moviment.Id }, _mapper.Map<MovimentResponseDto>(moviment));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var moviment = await _context.Moviments.FindAsync(id);
            if (moviment == null) return NotFound();

            _context.Moviments.Remove(moviment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
