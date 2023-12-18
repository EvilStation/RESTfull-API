namespace RESTfull.Domain.Model
{
    public class Audience
    {
        public Guid Id { get; set; }
        public int AudienceNumber { get; set; }
        public string AudienceType { get; set; } = string.Empty;
        public int WorkplaceNum { get; set; }

        public Guid? EmployeeId { get; set; } // внешний ключ
        public Employee Employee { get; set; }
    }
}
