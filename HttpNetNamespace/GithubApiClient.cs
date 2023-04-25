namespace HttpNetNamespace
{
    internal class GithubApiClient
    {
        public async Task<string> ListRepos(string userName)
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
                return content;
            }

            else
            {
                return $"Error: Request failed with status code: {response.StatusCode}";
            }            
        }
    }
}
