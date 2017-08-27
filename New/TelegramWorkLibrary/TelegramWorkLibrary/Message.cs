using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class Message
    {
        public int _messageId { get; set; } // Идентификатор сообщения
        public int _date { get; set; } // Дата отправки сообщения (unix time)
        public String _text { get; set; } // Текст сообщения
        // User _from {get; set;} // Отправитель (Может быть пустым)

        // Chat _chat {get; set;} // Диалог, в котором отправлено сообщение
    }
}
