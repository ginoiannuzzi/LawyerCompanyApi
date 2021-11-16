using Afte.Database;
using Afte.Models;
using Afte.Models.ViewModels.Like;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Afte.Services
{
    public class LikeService
    {
        private readonly AfteDbContext _context;

        public LikeService(AfteDbContext context)
        {
            _context = context;
        }

        public async Task LikePost(LikePostViewModel userLikeDto)
        {
            var like = new Like()
            {
                UsuarioId = userLikeDto.UsuarioId,
                PostId = userLikeDto.PostId
            };

            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task UnlikePost(UnlikePostViewModel userUnlikeDto)
        {
            var like = await _context.Likes.SingleAsync(x => x.PostId == userUnlikeDto.PostId && x.UsuarioId == userUnlikeDto.UsuarioId);

            _context.Likes.Remove(like);
            _context.SaveChanges();
        }
    }
}
