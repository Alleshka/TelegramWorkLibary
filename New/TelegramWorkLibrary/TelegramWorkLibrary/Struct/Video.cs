using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет видеозапись.
    public struct Video
    {
        public String _fileId { get; set; } // 	Уникальный идентификатор файла
        public long _width { get; set; } // 	Ширина видео, заданная отправителем
        public long _height { get; set; } // Высота видео, заданная отправителем
        public long _duration { get; set; } // Продолжительность
        public PhotoSize _thumb { get; set; } // Превью
        public String _mimeType { get; set; } // Опционально. MIME файла, заданный отправителем
        public long _fileSize { get; set; } // Опционально. Размер файла
    }
}
