using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Ddhp.v2016.Controllers.Api
{
    [Route("api/[controller]")]
    public class ContractsController : Controller
    {
        private readonly IDdhpContext _context;

        public ContractsController(IDdhpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{roundId:int}/{clubName}")]
        public IEnumerable<Contract> Get(int roundId, string clubName)
        {
            return (from contract in _context.Contracts
                where
                    contract.FromRoundId <= roundId && contract.ToRoundId >= roundId &&
                    contract.Club.Name.Equals(clubName, StringComparison.CurrentCultureIgnoreCase)
                select contract).Include(q => q.Player);
        }
    }
}