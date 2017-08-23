using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct Contact
    {
        public String _phoneNumber { get; set; } // Номер телефона 
        public String _FirstName { get; set; } // Имя
        public String _LastName { get; set; } // Фамилия
        public long _userID { get; set; } // ID в телеграме
    }
}
