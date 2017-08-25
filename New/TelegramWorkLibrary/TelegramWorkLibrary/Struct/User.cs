using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет бота или пользователя Telegram.
    public struct User
    {
        public long _userID { get; set; } // ID пользователя
        public String _FirstName { get; set; } // Имя пользователя

        // Опционально
        public String _LastName { get; set; } // Фамилия пользователя
        public String _UserName { get; set; } // Логин пользователя
    }
}
