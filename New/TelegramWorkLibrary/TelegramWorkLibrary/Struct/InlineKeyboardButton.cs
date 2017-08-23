using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{

    // Добавить callback_game

    struct InlineKeyboardButton
    {
        public String _text { get; set; } // Текст на кнопке
        public String _url { get; set; } // URL, который откроется при нажатии на кнопку
        public String _callbackData { get; set; } // Данные, которые будут отправлены в callback_query при нажатии на кнопку

        //Опционально. Если этот параметр задан, то при нажатии на кнопку приложение предложит пользователю выбрать любой чат, 
        //откроет его и вставит в поле ввода сообщения юзернейм бота и определённый запрос для встроенного режима.
        //Если отправлять пустое поле, то будет вставлен только юзернейм бота.
        //Примечание: это нужно для того, чтобы быстро переключаться между диалогом с ботом 
        //и встроенным режимом с этим же ботом.Особенно полезно в сочетаниями с действиями 
        //switch_pm… – в этом случае пользователь вернётся в исходный чат автоматически, без ручного выбора из списка.
        public String _switchInlineQuery { get; set; }

        //Опционально.If set, pressing the button will insert the bot‘s username and the specified inline query in the current chat's 
        //input field. Can be empty, in which case only the bot’s username will be inserted.
        public String _switchInlineQueryCurrentChat { get; set; }
    }
}
