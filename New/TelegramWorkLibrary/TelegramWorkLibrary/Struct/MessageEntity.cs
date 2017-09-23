using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public enum TypeEntity { mention, hashtag, bot_command, url, email, bold, italic, code, pre, text_link } // Тип сущности
    public class MessageEntity
    {
        public TypeEntity _type { get; set; } // Тип сущности 
        public Int64 _offset { get; set; } // Смещение элементов кода utf-16 в начале сущности
        public Int64 _length { get; set; } // Длина объекта в utf-16 единиц код 
        public String _url { get; set; } // Опционально. Для “text_link” только URL-адрес, который будет открыт после того, как пользователь нажимает на текст
    }
}
