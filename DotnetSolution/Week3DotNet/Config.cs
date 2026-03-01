namespace Week3DotNet
{
    internal class Config
    {
        static void Main(string[] args)
        {
            ApplicationConfig.Initialize("BoostUp", "dev");
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
        }

    }
    internal class ApplicationConfig
    {
        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
        public static int AccessCount { get; set; }
        public static bool IsInitialized { get; set; }
        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
            Console.WriteLine("Static constructor executed");
        }
        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }
        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"Application Name: {ApplicationName}  Environment: {Environment}  Access Count: {AccessCount}  Initialization Status: {IsInitialized}";
        }
        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
        }
    }
}
