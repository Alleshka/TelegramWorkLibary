using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class Voice
    {
        public String _fileId { get; set; } // Уникальный идентификатор файла 
        public Int64 _duration { get; set; } // Продолжительность аудиофайла, заданная отправителем

        public String _mimeType { get; set; } // Опционально. MIME-тип файла, заданный отправителем
        public Int64? _fileSize { get; set; } // Опционально. Размер файла
    }
}
