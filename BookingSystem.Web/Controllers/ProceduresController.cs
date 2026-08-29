using BookingSystem.Shared.Dtos;
using BookingSystem.Data.InterfacesRepositories;
using BookingSystem.Data.Mappers;
using Microsoft.AspNetCore.Mvc;
using BookingSystem.Shared.Filters;

namespace BookingSystem.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProceduresController : ControllerBase
{
    private readonly IProcedureRepository _procedureRepository;
    public ProceduresController(IProcedureRepository procedureRepository)
    {
        _procedureRepository = procedureRepository;

    }

    [HttpPost]

    public async Task<ActionResult<ReadProcedureDto>> Create(CreateProcedureDto dto)
    {
        var newProcedure = ProcedureMapper.ToCreateModel(dto);
        _procedureRepository.Create(newProcedure);
        await _procedureRepository.SaveChangesAsync();

        var readDto = ProcedureMapper.ToReadDto(newProcedure);
        return CreatedAtAction(nameof(GetById), new { id = newProcedure.Id }, readDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetProcedures([FromQuery] ProcedureFilter filter)
    {
        var procedures = await _procedureRepository.GetProceduresAsync(filter);
        return Ok(procedures.Select(p => ProcedureMapper.ToReadDto(p)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var procedure = await _procedureRepository.GetByIdAsync(id);
        if (procedure is null)
        {
            return NotFound();
        }

        var dto = ProcedureMapper.ToReadDto(procedure);
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProcedureDto dto)
    {
        var procedure = await _procedureRepository.GetById(id);
        if (procedure is null)
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
        if (procedure is null)
        {
            return NotFound();
        }

        _procedureRepository.Delete(procedure);
        await _procedureRepository.SaveChangesAsync();
        return NoContent();
    }
}
