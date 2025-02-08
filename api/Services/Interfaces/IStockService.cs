using api.Models;

namespace api.Services.Interfaces
{
    public interface IStockService
    {
        public Task<List<Stock>> GetAllAsync();
        public Task<Stock> GetByIdAsync(int id);
    }
}
