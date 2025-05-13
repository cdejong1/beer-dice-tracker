using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerDice.API.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}