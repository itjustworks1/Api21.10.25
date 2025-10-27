namespace Api21._10._25.CQRS.DTO
{
    public class RApplicationDTO
    {
        public int IdApplicationType { get; set; }
        public int IdDepartment { get; set; }
        public DateTime Date { get; set; }
        public int IdStatus { get; set; }
        public string ReasonRefusal { get; set; }
    }
}
