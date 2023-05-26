namespace Redis_Cache_using_.NET_Core_API;

static class ConfigurationManager
{
    public static IConfiguration AppSetting
    {
        get;
    }
    static ConfigurationManager()
    {
        AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
    }
}
