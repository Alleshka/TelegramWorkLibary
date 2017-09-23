using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class Message
    {
        public Int64 _messageId { get; set; } // Идентификатор сообщения
        public Int64 _date { get; set; } // Дата отправки сообщения (unix time)
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
        public Location _locationg { get; set; } // Опционально. Информация о местоположении
        public Venue _venue { get; set; } // Опционально. Информация о месте на карте
        public User _newChatMember { get; set; } // Опционально. Информация о пользователе, добавленном в группу
        public User _leftChatMember { get; set; } // Опционально. Информация о пользователе, удалённом из группы
        public String _newChatTitle { get; set; } // Опционально. Название группы было изменено на это поле 
        public PhotoSize[] _newChatPhoto { get; set; } // Опционально. Фото группы было изменено на это поле 
        public bool? _deleteChatPhoto { get; set; } // 	Опционально. Сервисное сообщение: фото группы было удалено
        public bool? _groupChatCreated { get; set; } // Опционально. Сервисное сообщение: группа создана 
        public bool? _supergroupChatCreated { get; set; } // Опционально. Сервисное сообщение: супергруппа создана 
        public bool? _channelChatCreated { get; set; } // Опционально. Сервисное сообщение: канал создан
        public Int64? _migrateToChatId { get; set; } // Опционально. Группа была преобразована в супергруппу с указанным идентификатором. Не превышает 1e13 
        public Int64? _migrateFromChatId { get; set; } // Опционально. Cупергруппа была создана из группы с указанным идентификатором. Не превышает 1e13 

        public User _forwardFrom { get; set; } // Опционально. Для пересланных сообщений: отправитель оригинального сообщения 
        public Int64? _forwardDate { get; set; } // Опционально. Для пересланных сообщений: дата отправки оригинального сообщения
        public Message _replyToMessage { get; set; } // Опционально. Для ответов: оригинальное сообщение.
        public Message _pinnedMessage { get; set; } // Опционально. Указанное сообщение было прикреплено.

    }
}
