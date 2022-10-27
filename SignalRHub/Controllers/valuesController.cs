using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRHub.Models;

namespace SignalRHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class valuesController : ControllerBase
    {
        private BusTicketContext _ctx = null;

        public valuesController()
        {
            _ctx = new BusTicketContext();
        }

        [HttpGet("[action]")]
        public object index()
        {
            object result = null; string message = string.Empty;
            message = "API running...";

            result = new
            {
                message
            };
            return result;
        }

        [HttpGet("[action]")]
        public IEnumerable<Divisions> GetDivisions()
        {
            return _ctx.Divisions.OrderBy(o => o.Name);
        }

        [HttpGet("[action]")]
        public IEnumerable<Districts> GetDistrictsByDivision(int divisionId)
        {
            return _ctx.Districts.Where(w => w.DivisionId == divisionId).OrderBy(o => o.Name);
        }
    }
}