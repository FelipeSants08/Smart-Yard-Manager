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
    public class SensorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SensorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorResponseDto>>> GetAll()
        {
            var sensors = await _context.Sensors.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<SensorResponseDto>>(sensors));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SensorResponseDto>> GetById(Guid id)
        {
            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor == null) return NotFound();

            return Ok(_mapper.Map<SensorResponseDto>(sensor));
        }

        [HttpPost]
        public async Task<ActionResult> Create(SensorRequestDto dto)
        {
            var sensor = _mapper.Map<Sensor>(dto);
            sensor.Id = Guid.NewGuid();

            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sensor.Id }, _mapper.Map<SensorResponseDto>(sensor));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, SensorRequestDto dto)
        {
            var existing = await _context.Sensors.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            _context.Sensors.Update(existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor == null) return NotFound();

            _context.Sensors.Remove(sensor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
