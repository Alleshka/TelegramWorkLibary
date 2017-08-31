using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class Document
    {
        public String _fileId { get; set; } // ID файла 
        public PhotoSize _thumb { get; set; } // Миниатюра 
        public String _fileName { get; set; } // Имя файла 
        public String _mimeType { get; set; } // MIME файла 
        public int? _fileSize { get; set; } // Размер файла
    }
}
