using Afte.Database;
using Afte.Models.ViewModels.Like;
using Afte.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Afte.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikesController : ControllerBase
    {
        private readonly AfteDbContext _context;

        public LikesController(AfteDbContext context)
        {
            _context = context;
        }

        [HttpPost("like")]
        public async Task<IActionResult> LikePost([FromBody] LikePostViewModel userLikeDto)
        {
            var likeService = new LikeService(_context);
            await likeService.LikePost(userLikeDto);

            return Ok();
        }

        [HttpPost("unlike")]
        public async Task<IActionResult> DislikePost([FromBody] UnlikePostViewModel userLikeDto)
        {
            var likeService = new LikeService(_context);
            await likeService.UnlikePost(userLikeDto);

            return Ok();
        }
    }
}
