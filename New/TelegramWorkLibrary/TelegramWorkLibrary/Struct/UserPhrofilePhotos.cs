using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct UserPhrofilePhotos
    {
        public long _totalCount { get; set; } // Число фотографий профиля
        public PhotoSize[] _photos { get; set; }
    }
}
