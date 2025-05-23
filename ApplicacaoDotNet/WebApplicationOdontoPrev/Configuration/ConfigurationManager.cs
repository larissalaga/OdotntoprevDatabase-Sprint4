using Microsoft.Extensions.Configuration;

namespace WebApplicationOdontoPrev.Configuration
{
    public class ConfigManager
    {
        private static readonly Lazy<ConfigManager> instance = new Lazy<ConfigManager>(() => new ConfigManager());

        private IConfiguration configuration = default!;

        private ConfigManager() { }

        public static ConfigManager Instance => instance.Value;

        public void Initialize(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString()
        {
            return configuration.GetConnectionString("OracleConnection") ?? string.Empty;
        }

        public T GetValue<T>(string key)
        {
            return configuration.GetValue<T>(key)!;
        }
    }
}
