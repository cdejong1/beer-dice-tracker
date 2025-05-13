using Microsoft.AspNetCore.Mvc;
using BeerDice.API.Data;
using BeerDice.API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

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
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.Include(p => p.Team).ToListAsync();
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

            return player;
        }

        // POST: api/player
        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, player);
        }

        // PUT: api/player/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlayer(int id, Player updatedPlayer)
        {
            if (id != updatedPlayer.PlayerId)
            {
                return BadRequest("Player ID mismatch");
            }
            
            var exisitngPlayer = await _context.Players.FindAsync(id);
            if (exisitngPlayer == null)
            {
                return NotFound();
            }
            exisitngPlayer.Name = updatedPlayer.Name;
            exisitngPlayer.TeamId = updatedPlayer.TeamId;

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