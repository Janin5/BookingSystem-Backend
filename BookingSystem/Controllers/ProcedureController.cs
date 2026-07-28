using BookingSystem.Dtos;
using BookingSystem.InterfacesRepositories;
using BookingSystem.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProcedureController : ControllerBase
{
    private readonly IProcedureRepository _procedureRepository;
    public ProcedureController( IProcedureRepository procedureRepository) 
    {
        _procedureRepository = procedureRepository;
  
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task <ActionResult<ReadProcedureDto>> Create(CreateProcedureDto dto)
    {
        var newProcedure = ProcedureMapper.ToCreateModel(dto); 
        _procedureRepository.Create(newProcedure);
        await _procedureRepository.SaveChangesAsync();

        var getWithSalon = await _procedureRepository.GetByIdwithSalon(newProcedure.Id);
        var readDto = ProcedureMapper.ToReadDto(getWithSalon);

        return CreatedAtAction(nameof(GetById), new { id = newProcedure.Id }, readDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var procedure = await _procedureRepository.GetByIdwithSalon(id);
        if(procedure is null)
        {
            return NotFound();
        }

        var dto = ProcedureMapper.ToReadDto(procedure);
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task <IActionResult> Update(Guid id, [FromBody] UpdateProcedureDto dto)
    {
        var procedure = await _procedureRepository.GetById(id);
        if(procedure is null)
        {
            return NotFound();
        }

        ProcedureMapper.ToUpdateModel(dto, procedure);
        await _procedureRepository.SaveChangesAsync();

        var updatedDto = ProcedureMapper.ToReadDto(procedure);
        return Ok(updatedDto);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var procedure = await _procedureRepository.GetById(id);
        if(procedure is null)
        {
            return NotFound();
        }

        _procedureRepository.Delete(procedure);
        await _procedureRepository.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("BySalon/{salonId}")]

    public async Task <IActionResult> GetBySalonId(Guid salonId)
    {
        var procedures = await _procedureRepository.GetBySalonId(salonId);

        var dtos = procedures.Select(p => ProcedureMapper.ToReadDto(p)).ToList();

        return Ok(dtos);
    }

    [HttpGet("{procedureId}/with-stylists")]

    public async Task<IActionResult> GetProcedurewithStylists(Guid procedureId)
    {
        var procedure = await _procedureRepository.GetProcedurewithStylists(procedureId);
        if(procedure is null)
        {
            return NotFound();
        }

        var dto =ProcedureMapper.MapProcedurewithStyliststoDt0(procedure);
        return Ok(dto);
        
    }





}
