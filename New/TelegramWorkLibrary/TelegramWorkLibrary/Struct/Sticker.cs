using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет стикер.
    public struct Sticker
    {
        public String _fileId { get; set; } // 	Уникальный идентификатор файла
        public long _width { get; set; } // Ширина стикера
        public long _height { get; set; } // Высота стикера
        public PhotoSize _thumb { get; set; } // Опционально. Превью стикера в формате .webp или .jpg
        public long _fileSize { get; set; } // Опционально. Размер файла
    }
}
