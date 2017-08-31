using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class Video
    {
        public String _fileId { get; set; } // 	Уникальный идентификатор файла
        public int _width { get; set; } // Ширина видео, заданная отправителем
        public int _height { get; set; } // Высота видео, заданная отправителем
        public int _duration { get; set; } // Продолжительность

        public PhotoSize _thumb { get; set; } // Превью
        public String _mimeType { get; set; } // Опционально. MIME файла, заданный отправителем
        public int? _fileSize { get; set; } // 	Опционально. Размер файла
    }
}
