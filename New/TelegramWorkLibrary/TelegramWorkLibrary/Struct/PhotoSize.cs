using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class PhotoSize
    {
        public String _fileId { get; set; } // Идентификатор файла
        public Int64 _width { get; set; } 
        public Int64 _height { get; set; }
        public Int64? _fileSize { get; set; }
    }
}
