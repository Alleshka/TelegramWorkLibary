using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет голосовое сообщение.
    public struct Voice
    {
        public String _fileId { get; set; } // Уникальный идентификатор файла
        public long _duration { get; set; } // Продолжительность аудиофайла, заданная отправителем
        public String _mimeType { get; set; } // Опционально. MIME-тип файла, заданный отправителем
        public long _fileSize { get; set; } //	Опционально. Размер файла
    }
}
