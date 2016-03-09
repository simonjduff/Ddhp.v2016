using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public IEnumerable<Player> GetAll()
        {
            return _context.Players;
        }
    }
}