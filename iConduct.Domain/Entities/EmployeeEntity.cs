namespace iConduct.Domain.Entities
{
    public class EmployeeEntity
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public int? ManagerID { get; set; }
        public bool Enable { get; set; }
    }
}
