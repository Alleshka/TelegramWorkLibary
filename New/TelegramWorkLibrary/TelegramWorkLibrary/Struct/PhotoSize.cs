using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct PhotoSize
    {
        public String _fileId { get; set; }
        public long _width { get; set; } 
        public long _height { get; set; }

        public long _fileSize { get; set; } // Optionla
    }
}
