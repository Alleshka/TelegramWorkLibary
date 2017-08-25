using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет собой сообщение.
    public struct Message
    {
        public long _messageId { get; set; } // Уникальный идентификатор сообщения
        public User _from { get; set; } // Опционально. Отправитель. Может быть пустым в каналах.
        public long _date { get; set; } // Дата отправки сообщения (Unix time)
        public Chat _chat { get; set; } // Диалог, в котором было отправлено сообщение
        public User _forwardFrom { get; set; } // Опционально. Для пересланных сообщений: отправитель оригинального сообщения
        public long _forwardDate { get; set; } // 	Опционально. Для пересланных сообщений: дата отправки оригинального сообщения
        // public Message _replyTeMessage { get; set; }
        public String _text { get; set; } // Опционально. Для текстовых сообщений: текст сообщения, 0-4096 символов
        public MessageEntity[] _entities { get; set; }  // Опционально. Для текстовых сообщений: особые сущности в тексте сообщения.
        public Audio _audio { get; set; } // Опционально. Информация об аудиофайле
        public Document _document { get; set; } // Опционально. Информация о файле
        public PhotoSize[] _photo { get; set; } // Опционально. Доступные размеры фото
        public Sticker _sticker { get; set; } // Опционально. Информация о стикере
        public Video _video { get; set; } // Опционально. Информация о видеозаписи
        public Voice _voice { get; set; } // Опционально. Информация о голосовом сообщении
        public String _caption { get; set; } // Опционально. Подпись к файлу, фото или видео, 0-200 символов
        public Contact _contact { get; set; } // Опционально. Информация об отправленном контакте
        public Location _location { get; set; } // Опционально. Информация о местоположении
        public Venue _venue { get; set; } // Опционально. Информация о месте на карте
        public User _newChatMember { get; set; } // Опционально. Информация о пользователе, добавленном в группу
        public User _leftChatMember { get; set; } // Опционально. Информация о пользователе, удалённом из группы
        public String _newChatTitle { get; set; } // Опционально. Название группы было изменено на это поле
        public PhotoSize[] _newChatPhoto { get; set; } // Опционально. Фото группы было изменено на это поле
        public bool _deleteChatPhoto { get; set; } // Опционально. Сервисное сообщение: фото группы было удалено
        public bool _groupChatCreated { get; set; } // 	Опционально. Сервисное сообщение: группа создана
        public bool _supergroupChatCreated { get; set; } // Опционально. Сервисное сообщение: супергруппа создана
        public bool _channelChatCreated { get; set; } // Опционально. Сервисное сообщение: канал создан
        public long _migrateToChatId { get; set; } // Опционально. Группа была преобразована в супергруппу с указанным идентификатором. Не превышает 1e13
        public long _migrateFromChatId { get; set; } //	Опционально. Cупергруппа была создана из группы с указанным идентификатором. Не превышает 1e13
        // public Message _pinnedMessage { get; set; }
    }
}
