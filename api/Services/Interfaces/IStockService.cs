using api.Dtos.Stock;
using api.Models;

namespace api.Services.Interfaces
{
    public interface IStockService
    {
        public Task<List<StockDto>> GetAllAsync();
        public Task<StockDto> GetByIdAsync(int id);
        public Task<StockDto> AddAsync(CreateStockDto dto);
        public Task<StockDto> UpdateAsync(int id, UpdateStockDto updateStockDto);
        public Task<int> DeleteAsync(int id);
    }
}
