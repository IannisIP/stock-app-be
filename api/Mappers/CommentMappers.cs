using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto toCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
            };
        }

        public static Comment toCommentFromCreateCommentDto(this CreateCommentDto createCommentDto, int stockId)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                StockId = stockId
            };
        }
    }
}
