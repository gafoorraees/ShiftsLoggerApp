namespace ShiftsLogger.Dtos
{
    public class UpdateShiftDto
    {
        public DateTime Date { get; set; }
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
    }
}
