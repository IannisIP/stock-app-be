using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c => c.toCommentDto()).ToList()
            };
        }

        public static Stock toStockFromCreateDto(this CreateStockDto creatStockDto)
        {
            return new Stock
            {
                Symbol = creatStockDto.Symbol,
                CompanyName = creatStockDto.CompanyName,
                Purchase = creatStockDto.Purchase,
                LastDiv = creatStockDto.LastDiv,
                Industry = creatStockDto.Industry,
                MarketCap = creatStockDto.MarketCap
            };
        }
    }
}
