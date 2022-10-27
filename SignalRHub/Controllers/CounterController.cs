using Microsoft.AspNetCore.Mvc;
using SignalRHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : Controller
    {
        private BusTicketContext _ctx = null;
        public CounterController()
        {
            _ctx = new BusTicketContext();
        }

        [HttpGet("[action]")]
        public IEnumerable<Counter> getall()
        {
            return _ctx.Counter;
        }

        // POST: api/Counter/save
        [HttpPost("[action]")]
        public async Task<object> save()
        {
            object result = null; string message = string.Empty; bool resstate = false;
            try
            {
                //Save
                var model = new Counter()
                {
                    CounterId = Convert.ToInt32(Request.Form["CounterId"].ToString()),
                    CounterName = Request.Form["CounterName"].ToString(),
                };

                var obj = _ctx.Counter.Where(s => s.CounterId == model.CounterId).FirstOrDefault();
                if (obj == null)
                {
                    _ctx.Counter.Add(model);
                    message = "Added successfully.";
                }
                else
                {
                    obj.CounterName = model.CounterName;
                    message = "Update successfully.";
                }
                await _ctx.SaveChangesAsync();
                resstate = true;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            result = new
            {
                message,
                resstate
            };

            return result;
        }

        // DELETE api/Counter/deletebyid/1
        [HttpDelete("[action]/{id}")]
        public async Task<object> deletebyid(int id)
        {
            object result = null; string message = string.Empty; bool resstate = false;
            try
            {
                var obj = _ctx.Counter.Where(s => s.CounterId == id).FirstOrDefault();
                _ctx.Counter.Remove(obj);
                await _ctx.SaveChangesAsync();
                message = "Remove successfully.";
                resstate = true;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            result = new
            {
                message,
                resstate
            };

            return result;
        }


    }
}
