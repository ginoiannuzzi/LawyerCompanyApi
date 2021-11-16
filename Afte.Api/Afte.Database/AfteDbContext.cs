using Afte.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afte.Database
{
    public class AfteDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes{ get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public AfteDbContext(DbContextOptions<AfteDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Post>().ToTable("Post").HasOne(p => p.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Comment>().HasOne(p => p.Post).WithMany(p => p.Comments).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Like>().ToTable("Like").HasOne(p => p.Post).WithMany(x => x.Likes).HasForeignKey(x => x.PostId);
            modelBuilder.Entity<Like>().ToTable("Like").HasOne(p => p.Usuario).WithMany(x => x.Likes).HasForeignKey(x => x.UsuarioId);
            modelBuilder.Entity<Attachment>().ToTable("Attachment").HasOne(p => p.Post).WithMany(x => x.Attachments).HasForeignKey(x => x.PostId);
        }
    }
}
