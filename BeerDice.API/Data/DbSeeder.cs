using BeerDice.API.Models;

namespace BeerDice.API.Data
{
    public static class DbSeeder
    {
        public static void Seed(BeerDiceContext context)
        {
            if (context.Teams.Any() || context.Players.Any())
                return; // DB has been seeded
            
            var teamAlpha = new Team { Name = "Team Alpha" };
            var teamBeta = new Team { Name = "Team Beta" };

            var players = new List<Player>
            {
                new Player { Name = "Alice", Team = teamAlpha },
                new Player { Name = "Bob", Team = teamAlpha },
                new Player { Name = "Charlie", Team = teamBeta },
                new Player { Name = "Dana", Team = teamBeta }
            };

            context.Teams.AddRange(teamAlpha, teamBeta);
            context.Players.AddRange(players);
            context.SaveChanges();
        }
    }
}