using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly ValuesHolder _holder;
        public CRUDController(ValuesHolder holder)
        {
            _holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] string input)
        {
            _holder.ADD(DateTime.Now, input);
            return Ok();
        }
        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(_holder.Get());
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime time, [FromQuery] string newValue)
        {
            try
            {
                return Ok(_holder.Values[time] = newValue);
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime from, DateTime to)
        {
            Dictionary<DateTime, string> newdic = new Dictionary<DateTime, string>();
            foreach (var item in _holder.Values)
            {
                if (item.Key<from||item.Key>to)
                {
                    newdic.Add(item.Key, item.Value);
                }
            }

                 return Ok();
        }

    }

}
