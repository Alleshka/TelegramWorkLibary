using System;

namespace TelegramWorkLibrary.Struct
{

    // Этот объект представляет аудиозапись, которую клиенты Telegram воспинимают как музыкальный трек.
    public struct Audio
    {
        public String _fileId { get; set; } // Уникальный идентификатор файла
        public long _duration { get; set; } // Продолжительность файла
        public String _performer { get; set; } // Исполнитель аудио как определено отправителем или аудио теги
        public String _title { get; set; } // Название аудио как определено отправителем или аудио теги
        public String _mimeType { get; set; } //Опционально. MIME файла, заданный отправителем
        public long _fileSize { get; set; } //  Размер файла
    }
}
