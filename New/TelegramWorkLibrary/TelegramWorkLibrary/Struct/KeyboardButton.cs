using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct KeyboardButton
    {
        public String _text { get; set; } // Текст кнопки

        //Опционально. Если значение True, 
        //то при нажатии на кнопку боту отправится контакт пользователя с его номером телефона.
        //Доступно только в диалогах с ботом.
        public bool _requestContact { get; set; }

        //Опционально.Если значение True, 
        //то при нажатии на кнопку боту отправится местоположение пользователя.
        //Доступно только в диалогах с ботом.
        public bool _requestLocation { get; set; } 
    }
}
