using api.Models;
using api.Services;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var stocks = await _stockService.GetAllAsync();
            return Ok(stocks.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var stock = await _stockService.GetByIdAsync(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

    }
}
