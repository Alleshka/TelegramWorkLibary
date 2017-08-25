using System;

namespace TelegramWorkLibrary.Struct
{

    // Этот объект представляет контакт с номером телефона.
    public struct Contact
    {
        public String _phoneNumber { get; set; } // Номер телефона 
        public String _FirstName { get; set; } // Имя
        public String _LastName { get; set; } // Фамилия
        public long _userID { get; set; } // ID в телеграме
    }
}
