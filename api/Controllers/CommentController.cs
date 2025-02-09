using api.Dtos.Comment;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var comments = await _commentService.GetAllAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
        {
            var comment = await _commentService.GetByIdAsync(id);

            return Ok(comment);
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> AddAsync([FromRoute] int stockId, CreateCommentDto createCommentDto)
        {
            var comment = await _commentService.AddAsync(stockId, createCommentDto);

            return Ok(comment);
        }
    }
}
