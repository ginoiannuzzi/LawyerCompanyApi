using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afte.Models
{
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string DownloadUrl { get; set; }
        public string Name { get; set; }
        public long PostId { get; set; }
        public Post Post { get; set; }
    }
}
