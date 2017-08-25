using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет файл, не являющийся фотографией, голосовым сообщением или аудиозаписью.
    public struct Document
    {
        public String _fileId { get; set; } // Уникальный идентификатор файла
        public PhotoSize _thumb { get; set; } // Миниатюра
        public String _fileName { get; set; } // Исходное Имя файла в качестве определенного отправителя
        public String _mymeType { get; set; } // MIME файла, заданный отправителем
        public long _fileSize { get; set; } // Размер файла
    }
}
