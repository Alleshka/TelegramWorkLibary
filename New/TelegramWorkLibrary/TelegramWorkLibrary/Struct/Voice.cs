using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct Voice
    {
        public String _fileId { get; set; }
        public long _duration { get; set; }
        public String _mimeType { get; set; }
        public long _fileSize { get; set; }
    }
}
