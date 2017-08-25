using System;

namespace TelegramWorkLibrary.Struct
{
    public struct Result
    {
        public int _updateId { get; set; } // id ответа
        public Message _message { get; set; } // Входящее сообщение
    }
}
