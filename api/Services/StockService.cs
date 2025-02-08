using api.Models;
using api.Repository;
using api.Repository.Interfaces;
using api.Services.Interfaces;

namespace api.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            var stocks = await _stockRepository.GetAllAsync();
            return stocks;
        }

        public async Task<Stock> GetByIdAsync(int id) 
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            return stock;
        }
    }
}
