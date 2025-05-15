using Microsoft.AspNetCore.Mvc;
using BeerDice.API.Data;
using BeerDice.API.Models;
using BeerDice.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BeerDice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly BeerDiceContext _context;

        public TeamController(BeerDiceContext context)
        {
            _context = context;
        }

        // GET: api/team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            var teams = await _context.Teams
                .Include(t => t.Players)
                .ToListAsync();

            var teamDtos = teams.Select(t => new TeamDto
            {
                TeamId = t.TeamId,
                Name = t.Name,
                Players = t.Players.Select(p => new PlayerDto
                {
                    PlayerId = p.PlayerId,
                    Name = p.Name,
                    TeamId = t.TeamId,
                    TeamName = t.Name
                }).ToList()
            });

            return Ok(teamDtos);
        }


        // GET: api/team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.Include(t => t.Players)
                                           .FirstOrDefaultAsync(t => t.TeamId == id);
            if (team == null)
                return NotFound();

            return team;
        }

        // POST: api/team
        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, team);
        }

        // PUT: api/team/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, Team updatedTeam)
        {
            if (id != updatedTeam.TeamId)
                return BadRequest("Team ID mismatch");

            var existingTeam = await _context.Teams.FindAsync(id);
            if (existingTeam == null)
                return NotFound();

            existingTeam.Name = updatedTeam.Name;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/team/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}