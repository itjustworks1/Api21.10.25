using Api21._10._25.DB;

namespace Api21._10._25.CQRS.DTO
{
    /// <summary>
    /// Заявка
    /// </summary>
    public class ApplicationDTO
    {
        public int Id { get; set; }

        public int ApplicationTypeId { get; set; }

        public int StatusId { get; set; }

        public string? RejectionReason { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string Purpose { get; set; } = null!;

        public int DepartmentId { get; set; }

        public int EmployeeId { get; set; }

        public string ApplicantEmail { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
