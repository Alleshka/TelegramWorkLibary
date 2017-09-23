using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class Contact
    {
        public String _phoneNumber { get; set; } // Номер телефона
        public String _firstName { get; set; } // Имя 

        public String _lastName { get; set; } // Опционально. Фамилия 
        public Int64? _userId { get; set; } // Опционально. Идентификатор пользователя в Telegram
    }
}
