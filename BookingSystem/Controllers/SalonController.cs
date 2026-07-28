using BookingSystem.Dtos;
using BookingSystem.InterfacesRepositories;
using BookingSystem.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalonController: ControllerBase
{
    private readonly ISalonRepository _salonRepository;
    public SalonController( ISalonRepository salonRepository)
    {
        _salonRepository = salonRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSalonDto dto)
    {
        var newSalon = SalonMapper.ToCreateModel(dto);
        _salonRepository.Create(newSalon);
        await _salonRepository.SaveChangesAsync();

        var readDto = SalonMapper.ToReadDto(newSalon);
        return CreatedAtAction(nameof(GetById), new { id = newSalon.Id }, readDto) ;
    }
    [ProducesResponseType(200, Type = typeof(ReadSalonDto))]
    [HttpGet("{id}")]
    public async Task <IActionResult> GetById(Guid id)
    {
         var salon = await _salonRepository.GetById(id);
         if(salon == null)
         {
            return NotFound();
         }

         var dto = SalonMapper.ToReadDto(salon);
         return Ok(dto);
    }

    [HttpGet("SalonsList")]
    public async Task <IActionResult> GetAll()
    {
        var list = await _salonRepository.GetAllwithProcedures();

        
        return Ok(list);
    }

    [HttpPut("{id}")]
    public async Task <IActionResult> Update(Guid id, [FromBody] UpdateSalonDto dto)
    {
        var salon = await _salonRepository.GetById(id);
        if(salon is null)
        {
            return NotFound();
        }

        SalonMapper.ToUpdateModel(dto, salon);
        _salonRepository.Update(salon);
        await _salonRepository.SaveChangesAsync();

        var updatedDto = SalonMapper.ToReadDto(salon);
        return Ok(updatedDto);

    }

    [HttpDelete("{id}")]
    public async Task <IActionResult> Delete(Guid id)
    {
        var salon = await _salonRepository.GetById(id);
        if(salon is null)
        {
            return NotFound();
        }

        _salonRepository.Delete(salon);
        await _salonRepository.SaveChangesAsync();

        return NoContent();
    }


}
