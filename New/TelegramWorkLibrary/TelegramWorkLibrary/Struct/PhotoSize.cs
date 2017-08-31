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
        public int _width { get; set; } 
        public int _height { get; set; }
        public int? _fileSize { get; set; }
    }
}
