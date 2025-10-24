namespace Api21._10._25.CQRS.DTO
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public int DepartmentId { get; set; }
    }
}
