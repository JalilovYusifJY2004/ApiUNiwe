namespace PestKitOnionAB104.Domain.Entities
{
    public class Employee:BaseNameableEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;
    }
}
