using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace Ddhp.v2016.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new[] {"First", "Second"};
        }
    }
}