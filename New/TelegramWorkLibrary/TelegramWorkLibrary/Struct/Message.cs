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

        public User _from {get; set;} // Отправитель (Может быть пустым)
        public Chat _chat {get; set;} // Диалог, в котором отправлено сообщение

        public MessageEntity[] _entities { get; set; } // Опционально.Для текстовых сообщений: особые сущности в тексте сообщения. 
        public Audio _audio { get; set; } // Опционально. Информация об аудиофайле
        public Document _document { get; set; } // Информация о документе 
        public PhotoSize[] _photo { get; set; } // Опционально. Доступные размеры фото
        public Sticker _sticker { get; set; } // Опционально. Информация о стикере
        public Video _video { get; set; } // Опционально. Информация о видеозаписи 
        public Voice _voice { get; set; } // Опционально. Информация о голосовом сообщении
        public String _caption { get; set; } // Опционально. Подпись к файлу, фото или видео, 0-200 символов
        public Contact _contact { get; set; } // Опционально. Информация об отправленном контакте
    }
}
