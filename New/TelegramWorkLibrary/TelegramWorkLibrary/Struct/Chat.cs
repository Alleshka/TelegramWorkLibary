using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public enum TypeChat { PRIVATE, GROUP, SUPERGROUP, CHANNEL }

    public class Chat
    {
        public int _id { get; set; } // id чата
        public TypeChat _type { get; set; } // Тип чата

        public String _title { get; set; } // Заголовок чата
        public String _userName { get; set; } // Логин для некотрых чатов
        public String _firstName { get; set; } // Имя собеседника в чате
        public String _lastName { get; set; } // Фамилия собеседника в чате
    }
}
