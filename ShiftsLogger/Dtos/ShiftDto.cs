using ShiftsLogger.Models;

namespace ShiftsLogger.Dtos;

public class ShiftDto
{
    public int EmployeeId { get; set; }
    public string EmployeeFullName { get; set; }
    public int ShiftId { get; set; }
    public DateTime Date { get; set; }
    public DateTime PunchIn { get; set; }
    public DateTime PunchOut { get; set; }
}
