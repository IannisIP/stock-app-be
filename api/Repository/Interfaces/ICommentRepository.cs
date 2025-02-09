using api.Models;

namespace api.Repository.Interfaces
{
    public interface ICommentRepository
    {

        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
        Task<Comment> AddAsync(Comment comment);
        Task<Comment> DeleteAsync(int id);
     }
}
