using api.Data;
using api.Dtos.Stock;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public StockRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Stock> AddAsync(Stock stock)
        {
            await _dBContext.Stocks.AddAsync(stock);
            await _dBContext.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _dBContext.Stocks.ToListAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            var stock = await _dBContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                throw new KeyNotFoundException($"Stock with id {id} not found.");
            }
            return stock;
        }

        public async Task<Stock> UpdateAsync(int id, UpdateStockDto updateStockDto)
        {
            var stockToUpdate = await GetByIdAsync(id);

            stockToUpdate.Industry = updateStockDto.Industry;
            stockToUpdate.CompanyName = updateStockDto.CompanyName;
            stockToUpdate.MarketCap = updateStockDto.MarketCap;
            stockToUpdate.LastDiv = updateStockDto.LastDiv;
            stockToUpdate.Purchase = updateStockDto.Purchase;
            stockToUpdate.Symbol = updateStockDto.Symbol;


            await _dBContext.SaveChangesAsync();
            return stockToUpdate;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var stock = await GetByIdAsync(id);

            _dBContext.Stocks.Remove(stock);
            return await _dBContext.SaveChangesAsync();
        }
    }
}
