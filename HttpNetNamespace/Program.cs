namespace HttpNetNamespace
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string userName = "haraonline";
            List<GitHubRepo> repos = await GithubApiClient.ListRepos(userName);

            foreach (GitHubRepo repo in repos)
            {
                Console.WriteLine($"{repo.Id}, {repo.Name}, {repo.HtmlUrl}");
            }
        }
    }
}