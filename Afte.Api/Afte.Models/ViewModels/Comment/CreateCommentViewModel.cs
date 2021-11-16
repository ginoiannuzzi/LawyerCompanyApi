using System;

namespace Afte.Models.ViewModels.Comment
{
    public class CreateCommentViewModel
    {
        public long UsuarioId { get; set; }
        public long PostId { get; set; }
        public string Content { get; set; }
    }
}
