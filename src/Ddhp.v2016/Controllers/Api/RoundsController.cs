using System.Linq;
using System.Threading.Tasks;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Microsoft.AspNet.Mvc;

namespace Ddhp.v2016.Controllers.Api
{
    [Route("api/[controller]")]
    public class RoundsController : Controller
    {
        private readonly DdhpContext _context;

        public RoundsController(DdhpContext context)
        {
            _context = context;    
        }

        [Route("incomplete")]
        public async Task<Round> NextIncompleteRound()
        {
            return await Task.Run(() => _context.Rounds.FirstOrDefault(q => !q.RoundComplete));
        }
    }
}
