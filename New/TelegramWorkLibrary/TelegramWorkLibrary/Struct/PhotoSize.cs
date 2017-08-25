using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет изображение определённого размера или превью файла / стикера.
    public struct PhotoSize
    {
        public String _fileId { get; set; } // Уникальный идентификатор файла
        public long _width { get; set; } // 	Photo width
        public long _height { get; set; } // Photo height

        public long _fileSize { get; set; } // Опционально. Размер файла
    }
}
