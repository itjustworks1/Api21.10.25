namespace Api21._10._25.CQRS.DTO
{
    /// <summary>
    /// один из контактов группового посещения
    /// </summary>
    public class GroupApplicationContactDTO
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public string ContactName { get; set; } = null!;

        public string ContactEmail { get; set; } = null!;

        public string? ContactPhone { get; set; }

        public string? Organization { get; set; }

    }
}
