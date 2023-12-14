namespace RESTfull.Domain.Model
{
    public class Employee
    {
        public Guid Id { get; set; } // первичный ключ
        public string Name { get; set; } = string.Empty;
        
    }
}