using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Dtos;
using ShiftsLogger.Models;

namespace ShiftsLogger.Services;

public class ShiftService
{
    private readonly ShiftsContext _context;

    public ShiftService(ShiftsContext context)
    {
        _context = context;
    }

    public async Task<List<ShiftDto>> GetAllShiftsAsync()
    {
        return await _context.Shifts
            .Include(s => s.Employee)
            .Select(s => new ShiftDto
            {
                ShiftId = s.ShiftId,
                Date = s.Date,
                PunchIn = s.PunchIn,
                PunchOut = s.PunchOut,
                EmployeeId = s.EmployeeId,
                EmployeeFullName = s.Employee.FirstName + " " + s.Employee.LastName,
            })
            .ToListAsync();
    }

    public async Task<ShiftDto> GetShiftByIdAsync(int id)
    {
        var shift = await _context.Shifts
            .Include(s => s.Employee)
            .Where(S => S.ShiftId == id)
            .Select(s => new ShiftDto
            {
                ShiftId = s.ShiftId,
                Date = s.Date,
                PunchIn = s.PunchIn,
                PunchOut = s.PunchOut,
                EmployeeId = s.EmployeeId,
                EmployeeFullName = s.Employee.FirstName + " " + s.Employee.LastName,
            })
            .FirstOrDefaultAsync();

        return shift;
    }

    public async Task<Shift> CreateShiftAsync(CreateShiftDto createShiftDto)
    {
        var employee = new Employee
        {
            FirstName = createShiftDto.FirstName,
            LastName = createShiftDto.LastName,
        };

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        var shift = new Shift
        {
            Date = createShiftDto.Date,
            PunchIn = createShiftDto.PunchIn,
            PunchOut = createShiftDto.PunchOut,
            EmployeeId = employee.EmployeeId,
        };

        await _context.Shifts.AddAsync(shift);
        await _context.SaveChangesAsync();

        return shift;
    }

    public async Task<Shift> UpdateShiftAsync(int id, UpdateShiftDto updateDto)
    {
        var shift = await _context.Shifts.FirstOrDefaultAsync(s => s.ShiftId == id);

        if (shift == null)
        {
            return null;
        }
        
        shift.Date = updateDto.Date;
        shift.PunchIn = updateDto.PunchIn;
        shift.PunchOut = updateDto.PunchOut;

        await _context.SaveChangesAsync();

        return shift;
    }

    public async Task<Shift> DeleteShiftAsync(int id)
    {
        var shift = await _context.Shifts.FirstOrDefaultAsync(s => s.ShiftId == id);

        if(shift == null)
        {
            return null;
        }

        _context.Shifts.Remove(shift);

        await _context.SaveChangesAsync();

        return shift;
    }
}
