using System.Runtime.Serialization;

namespace ManagementSystem.Data.Entities.ApplicationUser
{
    public class AppUser : Entity<long>
    {
        [DataMember(Name = "Name")]
        public string? Name { get; set; }
    }
}
