using Afte.Database;
using Afte.Models;
using Afte.Models.ViewModels.Attachment;
using Afte.Models.ViewModels.Comment;
using Afte.Models.ViewModels.Post;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Afte.Services
{
    public class PostService
    {
        private readonly AfteDbContext _context;

        public PostService(AfteDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetPostsOrdered()
        {
            return await _context.Posts.OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<Post> GetPostById(long id)
        {
            return await _context.Posts.SingleAsync(x => x.Id == id);
        }

        public async Task CreatePost(CreatePostViewModel postDto)
        {
            var post = new Post()
            {
                Title = postDto.Title,
                AuthorId = postDto.AuthorId,
                Content = postDto.Content,
                CreatedAt = DateTime.Now
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePost(long postId, UpdatePostViewModel post)
        {
            var postEntity = await GetPostById(postId);

            postEntity.Title = post.Title;
            postEntity.Content = post.Content;
            postEntity.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetCommentsByPostId(long postId)
        {
            var post = await _context.Posts.Include(x => x.Comments).SingleAsync(x => x.Id == postId);
            return post.Comments;
        }

        public async Task CreateComment(CreateCommentViewModel commentDto, long postId)
        {
            var comment = new Comment()
            {
                Content = commentDto.Content,
                PostId = commentDto.PostId,
                UsuarioId = commentDto.UsuarioId,
                CreatedAt = DateTime.Now
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveComment(long commentId)
        {
            var comment = _context.Comments.Single(x => x.Id == commentId);

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetPostsByDate(DateTime datetime)
        {
            var initialDate = new DateTime(datetime.Day, datetime.Month, datetime.Year, 0, 0, 0);
            var endDate = new DateTime(datetime.Day, datetime.Month, datetime.Year, 23, 59, 59);

            return await _context.Posts.Where(x => x.CreatedAt >= initialDate && x.CreatedAt <= endDate).ToListAsync();
        }

        public async Task<List<Post>> GetPostsByWord(string word)
        {
            return await _context.Posts.Where(x => x.Content.Contains(word)).ToListAsync();
        }

        public async Task DeletePost(long postId)
        {
            var post = await GetPostById(postId);

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public List<Attachment> GetAttachments(long postId)
        {
            return _context.Attachments.Where(x => x.PostId == postId).ToList();
        }

        public async Task AddAttachment(CreateAttachmentViewModel attachmentDto)
        {
            var attachment = new Attachment()
            {
                Name = attachmentDto.Name,
                DownloadUrl = attachmentDto.DownloadUrl,
                PostId = attachmentDto.Id
            };

            await _context.Attachments.AddAsync(attachment);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAttachment(long postId)
        {
            var attachments = _context.Attachments.Where(x => x.PostId == postId).ToList();

            foreach(var attachment in attachments)
            {
                _context.Attachments.Remove(attachment);
            }

            await _context.SaveChangesAsync();
        }
    }
}
