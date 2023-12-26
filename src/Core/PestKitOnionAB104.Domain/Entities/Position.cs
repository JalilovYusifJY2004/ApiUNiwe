namespace PestKitOnionAB104.Domain.Entities
{
    public class Position:BaseNameableEntity
    {
        public ICollection<Employee>? Employees { get; set; }
    }
}
