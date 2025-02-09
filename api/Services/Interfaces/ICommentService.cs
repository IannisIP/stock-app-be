using api.Dtos.Comment;

namespace api.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<List<CommentDto>> GetAllAsync();
        public Task<CommentDto> GetByIdAsync(int id);
        public Task<CreateCommentDto> AddAsync(int id, CreateCommentDto createCommentDto);
    }
}
