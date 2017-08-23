using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct Sticker
    {
        public String _fileId { get; set; } // Id File
        public long _width { get; set; } 
        public long _height { get; set; } 
        public PhotoSize _thumb { get; set; } // превью
        public long _fileSize { get; set; } 
    }
}
