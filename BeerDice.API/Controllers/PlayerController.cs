using Microsoft.AspNetCore.Mvc;
using BeerDice.API.Data;
using BeerDice.API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using BeerDice.API.Models.DTOs;

namespace BeerDice.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly BeerDiceContext _context;

        public PlayerController(BeerDiceContext context)
        {
            _context = context;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers()
        {
            var players = await _context.Players
                .Include(p => p.Team)
                .ToListAsync();

            var playerDtos = players.Select(p => new PlayerDto
            {
                PlayerId = p.PlayerId,
                Name = p.Name,
                TeamId = p.TeamId ?? 0,
                TeamName = p.Team?.Name
            });

            return Ok(playerDtos);
        }

        // GET: api/player/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.PlayerId == id);

            if (player == null)
            {
                return NotFound();
            }

            var playerDto = new PlayerDto
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                TeamId = player.TeamId ?? 0,
                TeamName = player.Team?.Name
            };

            return Ok(playerDto);
        }

        // POST: api/player
        [HttpPost]
        public async Task<ActionResult<PlayerDto>> CreatePlayer(PlayerDto dto)
        {
            var player = new Player 
            {
                Name = dto.Name,
                TeamId = dto.TeamId
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            // Reload including Team 
            await _context.Entry(player).Reference(p => p.Team).LoadAsync();

            var result = new PlayerDto
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                TeamId = player.TeamId ?? 0,
                TeamName = player.Team?.Name
            };

            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, result);
        }

        // PUT: api/player/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlayer(int id, PlayerDto dto)
        {
            if (id != dto.PlayerId)
            {
                return BadRequest("Player ID mismatch");
            }
            
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            player.Name = dto.Name;
            player.TeamId = dto.TeamId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/player/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}    