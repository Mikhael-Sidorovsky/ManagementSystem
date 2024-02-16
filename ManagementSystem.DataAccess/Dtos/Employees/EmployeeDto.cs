namespace ManagementSystem.Data.Dtos.Employees
{
    public class EmployeeDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long? ManagerId { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
