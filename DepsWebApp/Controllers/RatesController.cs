﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using DepsWebApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace DepsWebApp.Controllers
{
    /// <summary>
    /// Rates controller that exchanging currency.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class RatesController : ControllerBase
    {
        private readonly ILogger<RatesController> _logger;
        private readonly IRatesService _rates;

        public RatesController(
            IRatesService rates,
            ILogger<RatesController> logger)
        {
            _rates = rates;
            _logger = logger;
        }

        /// <summary>
        /// Get amount in exchanged currency.
        /// </summary>
        /// <param name="srcCurrency"></param>
        /// <param name="dstCurrency"></param>
        /// <param name="amount"></param>
        /// <returns>Decimal amount of currency.</returns>
        [HttpGet("{srcCurrency}/{dstCurrency}")]
        public async Task<ActionResult<decimal>> Get(string srcCurrency, string dstCurrency, decimal? amount)
        {
            var exchange =  await _rates.ExchangeAsync(srcCurrency, dstCurrency, amount ?? decimal.One);
            if (!exchange.HasValue)
            {
                _logger.LogDebug($"Can't exchange from '{srcCurrency}' to '{dstCurrency}'");
                return BadRequest("Invalid currency code");
            }
            return exchange.Value.DestinationAmount;
        }
    }
}
