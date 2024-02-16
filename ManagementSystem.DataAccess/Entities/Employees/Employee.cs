using ManagementSystem.Data.Entities.ApplicationUser;
using System.Runtime.Serialization;

namespace ManagementSystem.Data.Entities.Employees
{
    public class Employee : AppUser
    {
        [DataMember(Name = "ManagerId")]
        public int ManagerId { get; set; }

        [DataMember(Name = "Enabled")]
        public bool Enabled { get; set; }
    }
}
