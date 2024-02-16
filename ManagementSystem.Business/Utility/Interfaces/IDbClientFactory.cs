namespace ManagementSystem.Business.Utility.Interfaces
{
    public interface IDbClientFactory<T> where T : class
    {
        T Instance { get; }
    }
}
