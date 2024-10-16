using ShiftsLogger.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShiftsLogger.Dtos
{
    public class UpdateShiftDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime PunchIn { get; set; }
        [Required]
        [DateGreaterThan("PunchIn", ErrorMessage = "Punch out must be later than punch in.")]
        public DateTime PunchOut { get; set; }
    }
}
