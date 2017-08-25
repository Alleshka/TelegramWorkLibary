﻿using System;
namespace TelegramWorkLibrary.Struct
{
    public enum TypeMessageEntity
    {
        mention,
        hashtag,
        bot_command,
        url,
        email,
        bold,
        italic,
        code,
        pre,
        text_link
    }

    // Этот объект представляет одну из особых сущностей в текстовом сообщении. 
    // Например: хештеги, имена пользователей, ссылки итд.
    public struct MessageEntity
    {
        public TypeMessageEntity _type { get; set; } // Тип 
        public long _offset { get; set; } // Смещение в начале сущности
        public long lengh { get; set; } // Длина сущности
        public String _url { get; set; } // Ссылка для text_link
    }
}
