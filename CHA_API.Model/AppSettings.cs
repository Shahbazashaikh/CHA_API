
namespace CHA_API.Model
{
    public class AppSettings
    {
        public string DbConnectionString { get; set; }

        public string Email { get; set; }

        public JwtTokenSettings JwtTokenSettings { get; set; }
    }
}
