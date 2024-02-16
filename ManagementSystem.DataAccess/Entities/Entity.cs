using System.Runtime.Serialization;

namespace ManagementSystem.Data.Entities
{
    [DataContract]
    public abstract class Entity<TID> : IEntity<TID>
    {
        protected Entity() => CreatedAt = DateTime.Now;

        [DataMember(Name = "Id")]
        public virtual TID Id { get; set; }

        [DataMember(Name = "CreatedAt")]
        public virtual DateTime CreatedAt { get; set; }
    }
}
