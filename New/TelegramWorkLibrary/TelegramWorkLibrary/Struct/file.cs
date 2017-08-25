using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет файл, готовый к загрузке. 
    // Он может быть скачан по ссылке вида https://api.telegram.org/file/bot<token>/<file_path>. 
    // Ссылка будет действительна как минимум в течение 1 часа. 
    // По истечении этого срока она может быть запрошена заново с помощью метода getFile.
    public struct File
    {
        public String _fileId { get; set; } // Уникальный идентификатор файла
        public long _fileSize { get; set; } // Размер файла, если известен

        // Опционально. Расположение файла. 
        // Для скачивания воспользуйтейсь ссылкой вида https://api.telegram.org/file/bot<token>/<file_path>
        public String _filePath { get; set; } 
    }
}
