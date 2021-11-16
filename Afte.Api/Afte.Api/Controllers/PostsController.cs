using Afte.Database;
using Afte.Models.ViewModels.Attachment;
using Afte.Models.ViewModels.Comment;
using Afte.Models.ViewModels.Post;
using Afte.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Afte.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly AfteDbContext _context;

        public PostsController(AfteDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetPosts()
        {
            var postService = new PostService(_context);
            var posts = await postService.GetPostsOrdered();

            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(long postId)
        {
            var postService = new PostService(_context);
            var post = await postService.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpGet("{postId}/comments")]
        public async Task<IActionResult> GetCommentsByPostId(long postId)
        {
            var postService = new PostService(_context);
            var comments = await postService.GetCommentsByPostId(postId);

            return Ok(comments);
        }

        [HttpPost("{postId}/comments")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentViewModel comment, long postId)
        {
            var postService = new PostService(_context);
            await postService.CreateComment(comment, postId);

            return Ok();
        }

        //[HttpDelete("{commentId}")]
        //public async Task<IActionResult> RemoveComment([FromRoute] long commentId)
        //{
        //    var commentService = new CommentService(_context);
        //    await commentService.RemoveComment(commentId);

        //    return Ok();
        //}

        [HttpGet("{postId}/attachments")]
        public async Task<IActionResult> GetAttachments([FromRoute] long postId)
        {
            var postService = new PostService(_context);
            var attachments = postService.GetAttachments(postId);

            return Ok(attachments);
        }

        [HttpPost("{postId}/attachments")]
        public async Task<IActionResult> AddAttachment([FromBody] CreateAttachmentViewModel attachment)
        {
            var postService = new PostService(_context);
            await postService.AddAttachment(attachment);

            return Ok();
        }

        [HttpDelete("{postId}/attachments")]
        public async Task<IActionResult> RemoveAttachment([FromRoute] long postId)
        {
            var postService = new PostService(_context);
            await postService.RemoveAttachment(postId);

            return Ok();
        }

        [HttpGet("GetByDate/{date}")]
        public async Task<IActionResult> GetPostsByDate(DateTime datetime)
        {
            var postService = new PostService(_context);
            var posts = await postService.GetPostsByDate(datetime);

            return Ok(posts);
        }

        [HttpGet("GetByWord/{word}")]
        public async Task<IActionResult> GetPostsByWord(string word)
        {
            var postService = new PostService(_context);
            var posts = await postService.GetPostsByWord(word);

            return Ok(posts);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostViewModel post)
        {
            var userService = new PostService(_context);
            await userService.CreatePost(post);

            return Ok();
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost([FromRoute] long postId, [FromBody] UpdatePostViewModel post)
        {
            var postService = new PostService(_context);
            await postService.UpdatePost(postId, post);

            return Ok();
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost([FromRoute] int postId)
        {
            var userService = new PostService(_context);
            await userService.DeletePost(postId);

            return Ok();
        }
    }
}
