using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LeagueSpaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        private readonly LeagueAbilitiesContext _context;

        public AbilitiesController(LeagueAbilitiesContext context)
        {
            _context = context;
        }

        // GET: api/Abilities
        [HttpGet]
        [Authorize(Roles = "RegisteredUser")]
        public ActionResult<IEnumerable<Ability>> GetAbilities()
        {
            return _context.Abilities.ToList();
        }

        // GET: api/Abilities/5
        [HttpGet("{id}")]

        public ActionResult<Ability> GetAbility(int id)
        {
            var ability = _context.Abilities.Find(id);

            if (ability == null)
            {
                return NotFound();
            }

            return ability;
        }
    }
}