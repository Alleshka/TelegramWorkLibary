﻿using System;

namespace TelegramWorkLibrary.Struct
{

    // После получения сообщения с этим объектом, 
    // приложение Telegram свернёт клавиатуру бота и отобразит стандартную клавиатуру устройства (с буквами). 
    // По умолчанию клавиатуры бота отображаются до тех пор, пока не будет принудительно отправлена новая 
    // или скрыта старая клавиатура. Исключение составляют одноразовые клавиатуры, 
    // которые скрываются сразу после нажатия на какую-либо кнопку (см. ReplyKeyboardMarkup).
    public struct ReplyKeyboardHide
    {
        public bool _hideKeyboard { get; set; } // указание клиенты скрыть клавиатуру бота 
        public bool _selective { get; set; } // Скрыть клавиатуру для определённых пользователей
    }
}
