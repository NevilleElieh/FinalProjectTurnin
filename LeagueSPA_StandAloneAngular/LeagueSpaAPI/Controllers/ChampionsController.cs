using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace LeagueSpaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private readonly LeagueAbilitiesContext _context;

        public ChampionsController(LeagueAbilitiesContext context)
        {
            _context = context;
        }
        // GET: api/Champions
        [HttpGet]
        [Authorize(Roles = "RegisteredUser")]
        public ActionResult<IEnumerable<Champion>> GetChampions()
        {
            return _context.Champions.ToList();
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Champion>> GetChampion(int id)
        {
            var champion = await _context.Champions
                .Include(c => c.Abilities)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (champion == null)
            {
                return NotFound();
            }

            return champion;
        }

    }
}