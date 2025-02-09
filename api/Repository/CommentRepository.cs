using api.Data;
using api.Models;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CommentRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> AddAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
            {
                throw new Exception($"Comment with id {id} not found");
            }

            return comment;
        }
    }
}
