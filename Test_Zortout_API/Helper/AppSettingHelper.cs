using System.Reflection;
using System.IO;
using System.Reflection;
using Test_Zortout_API.Helper.Interface;
namespace Test_Zortout_API.Helper
{
    public class AppSettingHelper : IAppSettingHelper
    {
        public static IConfigurationRoot Configuration { get; set; }

        public AppSettingHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public string GetValue(string KeyPath)
        {
            try
            {
                return Configuration.GetValue<string>($"{KeyPath}");
            }
            catch
            {
                return string.Empty;
            }
        }

        public T GetValue<T>(string keyPath)
        {
            try
            {
                return Configuration.GetSection(keyPath).Get<T>();
            }
            catch
            {
                return default;
            }
        }
    }
}
