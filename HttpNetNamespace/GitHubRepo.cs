using Newtonsoft.Json;

namespace HttpNetNamespace
{
    internal class GitHubRepo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
    }
}
