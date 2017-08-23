using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct Document
    {
        public String _fileId { get; set; }
        public PhotoSize _thumb { get; set; } // Миниатюра
        public String _fileName { get; set; } 
        public String _mymeType { get; set; } 
        public long _fileSize { get; set; } 
    }
}
