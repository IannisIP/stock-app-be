using api.Models;

namespace api.Repository.Interfaces
{
    public interface IStockRepository
    {

        Task<List<Stock>> GetAllAsync();

        Task<Stock> GetByIdAsync(int id);
    }
}
