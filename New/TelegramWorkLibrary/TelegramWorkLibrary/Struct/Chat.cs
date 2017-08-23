using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    public enum TypeChat { PRIVATE, GROUP, SUPERGROUP, CHANNEL } // Тип чата

    struct Chat
    {
        public long _id { get; set; } // ID чата    
        public TypeChat _type { get; set; } // Тип чата
        
        // Опционально
        public String _title { get; set; } // Название для каналов или групп
        public String _userName { get; set; } // Логин для чатов и каталов
        public String _FirstName { get; set; } // Имя собеседник в чате
        public String _LastName { get; set; } // Фамилия собеседника в чате
    }
}
