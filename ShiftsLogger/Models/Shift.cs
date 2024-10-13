namespace ShiftsLogger.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public DateTime Date { get; set; }
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
