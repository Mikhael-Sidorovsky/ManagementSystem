namespace ManagementSystem.Data.Entities
{
    public interface IEntity<TID>
    {
        TID Id { get; set; }

        DateTime CreatedAt { get; set; }
    }
}
