using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afte.Models.ViewModels.Attachment
{
    public class CreateAttachmentViewModel
    {
        public string DownloadUrl { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
