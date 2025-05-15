namespace BeerDice.API.Models.DTOs
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
    }
}
