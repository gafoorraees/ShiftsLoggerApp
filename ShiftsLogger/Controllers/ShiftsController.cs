using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.Dtos;
using ShiftsLogger.Services;

namespace ShiftsLogger.Controllers;

[Route("api/shift")]
[ApiController]

public class ShiftsController : ControllerBase
{
    private readonly ShiftService _shiftService;

    public ShiftsController(ShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllShifts()
    {
        var shifts = await _shiftService.GetAllShiftsAsync();

        return Ok(shifts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetShiftById([FromRoute] int id)
    {
        var shift = await _shiftService.GetShiftByIdAsync(id);

        if (shift == null)
        {
            return NotFound();
        }

        return Ok(shift);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShift([FromBody] CreateShiftDto createShiftDto)
    {
        var shift = await _shiftService.CreateShiftAsync(createShiftDto);

        return CreatedAtAction(nameof(GetShiftById), new { id = shift.ShiftId }, shift);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShiftDto updateDto)
    {
        var updatedShift = await _shiftService.UpdateShiftAsync(id, updateDto);

        if (updatedShift == null)
        {
            return NotFound();
        }

        return Ok(updatedShift);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deletedShift = await _shiftService.DeleteShiftAsync(id);

        if (deletedShift == null)
        {
            return NotFound();
        }

        return NoContent();
    }

}

