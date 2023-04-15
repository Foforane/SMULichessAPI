using Microsoft.AspNetCore.Mvc;

namespace LichessAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SMULichessAPIController : Controller
    {
        private static List<SMUChessPlayers> chessPlayers = new List<SMUChessPlayers>
            {
              new SMUChessPlayers
              {
                  username = "Cyber",
                  surname = "Foforane",
                  name = "Thakgalang",
                  gender = "Male",
                  phoneNumber = "1234567890",
              }
            };
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
        [HttpPut]
        public async Task<ActionResult<SMUChessPlayers>> updatePlayer(SMUChessPlayers chessPlayer)
        {
            var player = chessPlayers.Find(player => player.username == chessPlayer.username);
            if(player == null)
            {
                return BadRequest("User Not Found");
            }
            player.name = chessPlayer.name;
            player.phoneNumber = chessPlayer.phoneNumber;
            player.surname = chessPlayer.surname;
            player.gender = chessPlayer.gender; 
            
            return Ok(chessPlayers);
        }
    }
}
