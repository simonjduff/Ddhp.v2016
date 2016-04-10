using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ddhp.v2016.Models;
using Microsoft.AspNet.Mvc;

namespace Ddhp.v2016.Controllers.Api
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IDdhpContext _context;

        public PlayersController(IDdhpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> GetAll()
        {
            return await Task.Run(() => _context.Players.OrderBy(q => q.Id));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Player> Get(int id)
        {
            return await Task.Run(() => _context.Players.SingleOrDefault(q => q.Id.Equals(id)));
        }
    }
}