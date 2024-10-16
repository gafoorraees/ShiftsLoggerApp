using ShiftsLogger.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShiftsLogger.Dtos
{
    public class CreateShiftDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime PunchIn { get; set; }
        [Required]
        [DateGreaterThan("PunchIn", ErrorMessage = "Punch out must be later than punch in.")]
        public DateTime PunchOut { get; set; }
    }
}
