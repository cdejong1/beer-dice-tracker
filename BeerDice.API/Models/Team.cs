using System.ComponentModel.DataAnnotations;

namespace BeerDice.API.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}