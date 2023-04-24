using Octokit;
using System.Threading.Tasks;

namespace OctoPussy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = "haraonline";
            IReadOnlyList<Repository> repos = ListRepos(userName).GetAwaiter().GetResult();
            Console.WriteLine("Repositories for {0}:", userName);
            Console.WriteLine("---------------------");
            foreach (var repo in repos)
            {
                Console.WriteLine(repo.Name);
            }
        }

        private static async Task<IReadOnlyList<Repository>> ListRepos(string userName)
        {            
            var client = new GitHubClient(new ProductHeaderValue("TheOctopusProject"));
            var repos = await client.Repository.GetAllForUser(userName);
            return repos;
        }
    }
}