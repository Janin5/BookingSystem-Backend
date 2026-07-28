using BookingSystem.Dtos;
using BookingSystem.InterfacesRepositories;
using BookingSystem.Mappers;
using BookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StylistController : ControllerBase
{
    private readonly IStylistRepository _stylistRepository;
    public StylistController(IStylistRepository stylistRepository)
    {
        _stylistRepository = stylistRepository;
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateStylistDto dto)
    {
        var newStylist = StylistMapper.ToCreateModel(dto);
        _stylistRepository.Create(newStylist);
        await _stylistRepository.SaveChangesAsync();

        var getStylist = await _stylistRepository.GetByIdwithSalon(newStylist.Id);

        var readDto = StylistMapper.ToReadDto(getStylist);

        return CreatedAtAction(nameof(GetById), new { id = newStylist.Id }, readDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var stylist = await _stylistRepository.GetByIdwithSalon(id);
        if (stylist is null)
        {
            return NotFound();
        }

        var dto = StylistMapper.ToReadDto(stylist);
        return Ok(dto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _stylistRepository.GetAllwithSalon();

        var dtos = list.Select(l => StylistMapper.ToReadDto(l)).ToList();
        return Ok(dtos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateStylistDto dto)
    {
        var stylist = await _stylistRepository.GetByIdwithSalon(id);
        if (stylist is null)
        {
            return NotFound();
        }

        StylistMapper.ToUpdateModel(dto, stylist);
        _stylistRepository.Update(stylist);
        await _stylistRepository.SaveChangesAsync();

        var updatedDto = StylistMapper.ToReadDto(stylist);
        return Ok(updatedDto);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var stylist = await _stylistRepository.GetById(id);
        if (stylist is null)
        {
            return NotFound();
        }

        _stylistRepository.Delete(stylist);
        await _stylistRepository.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("BySalon/{salonId}")]
    public async Task<IActionResult> GetBySalonId(Guid salonId)
    {

        var stylists = await _stylistRepository.GetBySalonId(salonId);

        var dtos = stylists.Select(s => StylistMapper.ToReadDto(s)).ToList();

        return Ok(dtos);

    }

    [HttpGet("{stylistId}/with-procedures")]
    public async Task <IActionResult> GetStylistwithProcedures(Guid stylistId)
    {

       var stylist = await _stylistRepository.GetStylistwithProcedures(stylistId);
        if (stylist == null) return NotFound();

        var dto = StylistMapper.MapStylistwithProceduresToDto(stylist);
        return Ok(dto);
    }

    [HttpPost("{stylistId}/assign-procedure/{procedureId}")]
    public async Task<IActionResult> AssignProcedure(Guid stylistId, Guid procedureId)
    {
        await _stylistRepository.AddProcedureToStylist(stylistId, procedureId);
        return Ok(new { message = "Procedura a fost asociată cu succes!" });
    }


}
