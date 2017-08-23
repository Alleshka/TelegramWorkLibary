using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct User
    {
        public long _userID { get; set; } // ID пользователя
        public String _FirstName { get; set; } // Имя пользователя

        // Опционально
        public String _LastName { get; set; } // Фамилия пользователя
        public String _UserName { get; set; } // Логин пользователя
    }
}
