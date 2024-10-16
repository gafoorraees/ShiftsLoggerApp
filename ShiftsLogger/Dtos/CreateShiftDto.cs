namespace ShiftsLogger.Dtos
{
    public class CreateShiftDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
    }
}
