using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotLibary
{

    public class Result
    {
        public int _update_id { get; set; }
        public Message _message { get; set; }
    }

    // Этот объект представляет собой сообщение.
    public class Message
    {
        public int _message_id { get; set; } // Уникальный идентификатор сообщения
        public User _from { get; set; } // Отправитель
        public int _date { get; set; } // Дата UnixTime

        public Chat _chat { get; set; } // Диалог, в котором отправлено сообщение

        public String _text { get; set; } // Опционально. Для текстовых сообщений: текст сообщения, 0-4096 символов
    }

    // Этот объект представляет бота или пользователя Telegram.
    public class User
    {
        public int _id { get; set; } // Уникальный идентификатор пользователя или бота
        public String _first_name { get; set; } // Имя бота или пользователя
        public String _last_name { get; set; } // Опционально. Фамилия бота или пользователя
        public String _username { get; set; } // Опционально. Username пользователя или бота

        public User(int id, String first, String last, String username)
        {
            _id = id;
            _first_name = first;
            _last_name = last;
            _username = username;
        }
    }

    // Этот объект представляет собой чат.
    public class Chat
    {
        public int _id { get; set; } // Уникальный идентификатор чата. Абсолютное значение не превышает 1e13
        public String _type { get; set; } // Тип чата: “private”, “group”, “supergroup” или “channel”

        public String _title { get; set; } // Опционально. Название, для каналов или групп

        public String _username { get; set; } // 	Опционально. Username, для чатов и некоторых каналов

        public String _first_name { get; set; } // Опционально. Имя собеседника в чате

        public String _last_name { get; set; } // Опционально. Фамилия собеседника в чате

        public bool all_members_are_administrators { get; set; } // Опционально.True, если все участники чата являются администраторами

        public Chat(int id, String type, String title, String name, String first, String last)
        {
            _id = id;
            _type = type;
            _title = _title;
            _username = name;
            _first_name = first;
            _last_name = last;
        }
    }
}
