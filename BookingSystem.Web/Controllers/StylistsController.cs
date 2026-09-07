using BookingSystem.Business;
using BookingSystem.Shared.Dtos;
using BookingSystem.Data.InterfacesRepositories;
using BookingSystem.Data.Mappers;
using BookingSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StylistsController : ControllerBase
{
    private readonly IStylistRepository _stylistRepository;
    private readonly AvailabilityService _availabilityService;
    public StylistsController(IStylistRepository stylistRepository, AvailabilityService availabilityService)
    {
        _stylistRepository = stylistRepository;
        _availabilityService = availabilityService;
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

    [HttpGet("{stylistId}/free-slots")]
    public async Task<IActionResult> GetFreeSlots(Guid stylistId, [FromQuery] DateOnly date, [FromQuery] Guid procedureId)
    {
        var slots = await _availabilityService.GetFreeSlots(stylistId, date, procedureId);
        return Ok(slots);
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


}
