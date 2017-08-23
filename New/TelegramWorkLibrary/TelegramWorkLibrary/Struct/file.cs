using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    public struct File
    {
        public String _fileId { get; set; }
        public long _fileSize { get; set; }
        public String _filePath { get; set; }
    }
}
