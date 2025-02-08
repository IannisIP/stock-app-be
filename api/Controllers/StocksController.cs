using api.Dtos.Stock;
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
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var stock = await _stockService.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

        [HttpPost]
        public async Task<StockDto> AddAsync([FromBody] CreateStockDto dto)
        {
            var stock = await _stockService.AddAsync(dto);
            return stock;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateStockDto updateStockDto)
        {
            var stock = await _stockService.UpdateAsync(id, updateStockDto);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _stockService.DeleteAsync(id);

            return NoContent();
        }
    }
}
