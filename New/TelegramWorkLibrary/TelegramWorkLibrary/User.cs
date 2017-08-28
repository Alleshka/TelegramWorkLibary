using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class User
    {
        public int _id { get; set; } // идентификатор бота 
        public String _firstName { get; set; } // Имя пользователя 
        public String _lastName { get; set; } // Фамилия пользователя
        public String _userName { get; set; } // Логин пользователя
    }
}
