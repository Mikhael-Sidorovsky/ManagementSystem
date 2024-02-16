using ManagementSystem.Data.Entities.ApplicationUser;
using System.Runtime.Serialization;

namespace ManagementSystem.Data.Entities.Managers
{
    public class Manager : AppUser
    {
        [DataMember(Name = "Departament")]
        public string Departament {  get; set; }
    }
}
