using ManagementSystem.Business.Utility.Interfaces;

namespace ManagementSystem.Business.Utility
{
    public class DbClientFactory<T> : IDbClientFactory<T> where T : class
    {
        private Lazy<T> _factoryLazy = new Lazy<T>(
            () => (T)Activator.CreateInstance(typeof(T)),
            LazyThreadSafetyMode.ExecutionAndPublication);

        public T Instance
        {
            get
            {
                return _factoryLazy.Value;
            }
        }
    }
}
