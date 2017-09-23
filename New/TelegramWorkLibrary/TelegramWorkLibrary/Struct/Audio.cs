using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class Audio
    {
        public String _fileId { get; set; } // ID файла
        public Int64 _duration { get; set; } // Продолжительность файл 

        // Необязательные параметры 
        public String _performer { get; set; } // Исполнитель 
        public String _title { get; set; } // Заголовок файла 
        public String _mimeType { get; set; } // MIME файла
        public Int64? _fileSize { get; set; } // Размер файла
    }
}

