using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class Sticker
    {
        public String _fileId { get; set; } // ID стикера 
        public int _width { get; set; } // Ширина стикера 
        public int _height { get; set; } // Высота стикера 

        public PhotoSize _thumb { get; set; } // превью стикера 
        public int? _fileSize { get; set; } // Размер файла
    }
}
