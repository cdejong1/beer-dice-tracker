using Microsoft.EntityFrameworkCore;
using BeerDice.API.Models;

namespace BeerDice.API.Data
{
    public class BeerDiceContext : DbContext
    {
        public BeerDiceContext(DbContextOptions<BeerDiceContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}