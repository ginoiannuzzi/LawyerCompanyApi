using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afte.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Content { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario{ get; set; }
        public long UsuarioId { get; set; }
        public long PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
