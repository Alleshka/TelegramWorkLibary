using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Добавить сюда структуру для пересланных сообений 
//Добавить сюда entities
//Добавить сюда audio
//Добавить сюда документ
//Добавить сюда фото
//Добавить сюда стикер
//Добавить сюда видео
//Добавить сюда голосовое сообщение
//Добавить сюда подпись к файлу
//Добавить сюда информацию о конакте
//Добавить сюда информацию о местоположении
//Добавить сюда информацию о месте на карте
//Добавить сюда информация о пользователе, добавленном в группу
//Добавить сюда информацию о пользователе, удалённом из группы
//Добавить информацию о новом названии группы
//Добавить информацию о новом фото группы
//Всё что ниже в документации https://tlgrm.ru/docs/bots/api#message
namespace TelegramWorkLibrary.Struct
{
    struct Message
    {
        public long _messageId { get; set; } // ID message

        public long _date { get; set; } // TimeMessage (unix-time)

        public Char _chat { get; set; } // Dialog

        // Optional
        public User _from { get; set; } // Sender (Optional)
        public String _text { get; set; } // TextMessage

        public MessageEntity[] _entitise { get; set; } // Особые сущности в тексте
    }
}
