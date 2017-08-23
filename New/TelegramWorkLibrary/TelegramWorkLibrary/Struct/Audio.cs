using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct Audio
    {
        public String _fileId { get; set; } // Id file
        public long _duration { get; set; } // Продолжительность файла
        public String _performer { get; set; } // Исполнитель
        public String _title { get; set; }
        public String _mimeType { get; set; } //Опционально. MIME файла, заданный отправителем
        public long _fileSize { get; set; }
    }
}
