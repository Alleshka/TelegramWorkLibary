using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет встроенную клавиатуру, которая появляется под соответствующим сообщением.
    public struct InlineKeyboardMarkup
    {
        // Массив строк, каждая из которых является массивом объектов InlineKeyboardButton.
        public InlineKeyboardMarkup[] _inlineKeyboard { get; set; }
    }
}
