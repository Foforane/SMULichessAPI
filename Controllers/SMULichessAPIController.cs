using Microsoft.AspNetCore.Mvc;

namespace LichessAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SMULichessAPIController : Controller
    {
        private readonly DataContext _context;

        public SMULichessAPIController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SMUChessPlayers>>> Get()
        {
           
            return Ok(await _context.SMULichessPlayers.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<SMUChessPlayers>>> addPlayer(SMUChessPlayers chessPlayer)
        {
            var userName = await _context.SMULichessPlayers.FindAsync(chessPlayer.username);
            if (userName != null)
            {
                return BadRequest("User Already Exists");
            }
            
            _context.SMULichessPlayers.Add(chessPlayer);
            await _context.SaveChangesAsync();
            return Ok(await _context.SMULichessPlayers.ToListAsync());
        }
        [HttpGet("{userName}")]
        public async Task<ActionResult<SMUChessPlayers>> Get(string userName)
        {
            var player = await _context.SMULichessPlayers.FindAsync(userName);

            if(player == null)
            {
                return BadRequest("User not found");
            }
            return Ok(player);
        }
       
    }
}
