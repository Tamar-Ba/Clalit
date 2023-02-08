using Logic.LogicServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Clalit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IRates _rates;

        public RatesController(IRates rates)
        {
            _rates = rates;
        }

        [HttpGet("GetExchangeRates")]
        public async Task<IActionResult> GetExchangeRates()
        {
            try
            {
                var response = await _rates.GetExchangeRateAsync();
                return Ok(response);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
