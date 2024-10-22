using System.ComponentModel.DataAnnotations;

namespace StackspotAI.Options
{
    public class StackspotAIOptions
    {
        [Required]
        public string BaseUrl { get; set; } = "https://api.stackspot.com";

        [Required]
        public string AuthUrl { get; set; } = "https://auth.stackspot.com/oauth/token";

        [Required]
        public string ClientId { get; set; } = string.Empty;

        [Required]
        public string ClientSecret { get; set; } = string.Empty;
    }
}
