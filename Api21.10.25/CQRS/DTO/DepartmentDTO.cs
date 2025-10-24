namespace Api21._10._25.CQRS.DTO
{
    /// <summary>
    /// Отдел
    /// </summary>
    public class DepartmentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;
    }
}
