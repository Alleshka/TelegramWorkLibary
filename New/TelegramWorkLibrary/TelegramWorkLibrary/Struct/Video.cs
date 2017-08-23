using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct Video
    {
        public String _fileId { get; set; } // fileId
        public long _width { get; set; }
        public long _height { get; set; }
        public long _duration { get; set; } // Продолжительность

        public PhotoSize _thumb { get; set; } // Превью
        public String _mimeType { get; set; } 
        public long _fileSize { get; set; } 
    }
}
