using api.Dtos.Stock;
using api.Models;

namespace api.Repository.Interfaces
{
    public interface IStockRepository
    {

        Task<List<Stock>> GetAllAsync();

        Task<Stock> GetByIdAsync(int id);

        Task<Stock> AddAsync(Stock stock);

        Task<Stock> UpdateAsync(int id, UpdateStockDto updateStockDto);

        Task<int> DeleteAsync(int id);
    }
}
