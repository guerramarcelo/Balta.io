namespace Blog
{
    public static class Configuration
    {
        public static string JwtKey = "a3e258aa97bc406d872c306251ff91d2";
        public static string ApiKeyName = "api_key";
        public static string ApiKey = "curso_api_IlTevUM/z0ey3NwCV/unWg=";
        public static SmtpConfiguration Smtp = new();

        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
