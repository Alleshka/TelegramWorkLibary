using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct ReplyKeyboardHide
    {
        public bool _hideKeyboard { get; set; } // указание клиенты скрыть клавиатуру бота 
        public bool _selective { get; set; } // Скрыть клавиатуру для определённых пользователей
    }
}
