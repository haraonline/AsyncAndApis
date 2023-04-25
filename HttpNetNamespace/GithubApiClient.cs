using Newtonsoft.Json;

namespace HttpNetNamespace
{
    internal class GithubApiClient
    {
        public static async Task<List<GitHubRepo>> ListRepos(string userName)
        {
            //PREPARE THE REQUEST
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com/");
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AsyncProjectHara", "1.0"));

            //FOR MORE CONTROL, YOU CAN USE THE FOLLOWING
            //using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"users/{username}/repos");

            //SEND THE REQUEST AND GET THE RESPONSE
            HttpResponseMessage response = await client.GetAsync($"users/{userName}/repos");

            //READ THE RESPONSE CONTENT
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<GitHubRepo> repos = JsonConvert.DeserializeObject<List<GitHubRepo>>(content);
                return repos;
            }

            else
            {
                throw new Exception($"The call failed with status code: {response.StatusCode}");
            }
        }
    }
}
