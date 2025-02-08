using api.Dtos.Stock;
using api.Mappers;
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

        public async Task<List<StockDto>> GetAllAsync()
        {
            var query = await _stockRepository.GetAllAsync();

            var stocks = query.Select(s => s.ToStockDto()).ToList();

            return stocks;
        }

        public async Task<StockDto> GetByIdAsync(int id) 
        {
            var query = await _stockRepository.GetByIdAsync(id);
            var stock = query.ToStockDto();

            return stock;
        }

        public async Task<StockDto> AddAsync(CreateStockDto dto)
        {
            
            var stock = await _stockRepository.AddAsync(dto.toStockFromCreateDto());
            return stock.ToStockDto();
        }

        public async Task<StockDto> UpdateAsync(int id, UpdateStockDto updateStockDto)
        {
            var stock = await _stockRepository.UpdateAsync(id, updateStockDto);

            return stock.ToStockDto();
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _stockRepository.DeleteAsync(id);
        }
    }
}
