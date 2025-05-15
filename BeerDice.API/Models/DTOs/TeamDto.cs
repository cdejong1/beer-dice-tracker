namespace BeerDice.API.Models.DTOs
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<PlayerDto> Players { get; set; } = new();
    }
}
