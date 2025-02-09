using api.Dtos.Comment;
using api.Mappers;
using api.Repository.Interfaces;
using api.Services.Interfaces;

namespace api.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        public CommentService(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        public async Task<CreateCommentDto> AddAsync(int id, CreateCommentDto createCommentDto)
        {
            var stock = await _stockRepository.GetByIdAsync(id); //check for existance

            await _commentRepository.AddAsync(createCommentDto.toCommentFromCreateCommentDto(id));

            return createCommentDto;
        }

        public async Task<List<CommentDto>> GetAllAsync()
        {
            var query = await _commentRepository.GetAllAsync();
            var comments = query.Select(c => c.toCommentDto());

            return comments.ToList();
        }

        public async Task<CommentDto> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            return comment.toCommentDto();
        }


    }
}
