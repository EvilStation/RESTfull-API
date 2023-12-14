namespace RESTfull.Domain.Model
{
    public class Audience
    {
        public Guid AudienceId { get; set; }
        public int AudienceNumber { get; set; }
        public Guid EmployeeId { get; set; } // внешний ключ
        public string AudienceType { get; set; } = string.Empty;
        public int WorkplaceNum { get; set; }
    }
}
