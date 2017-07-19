using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace TelegramBotLibary
{
    public class TelegramBot
    {
        protected string _Token; // Секретный ключ
        protected int _LastUpdateID; // Последнее обновление

        protected List<Result> _results; // Список входящих сообщений

        public TelegramBot(string Token, int UpdateID)
        {
            this._Token = Token;
            this._LastUpdateID = UpdateID;

            _results = new List<Result>();
        }

        // Получаем обновления через API
        public string GetUpdates()
        {
            string response = "";

            using (var webClient = new WebClient())
            {
                // Получили неотвеченые сообщения в формате JSON
                response = webClient.DownloadString("https://api.telegram.org/bot" + _Token + "/getUpdates" + "?offset=" + (_LastUpdateID + 1));

                // Достаём ответы и помещаем в список
                ParseResponce(ref response);
            }

            return response;
        }

        private void ParseResponce(ref string response)
        {
            // Поехали парсить
            JObject oneObject = JObject.Parse(response); // Спарсили

            JArray respondItem = (JArray)oneObject["result"]; // Достали ответы

            // Пробегаем по полученным результатам
            foreach (JObject t in respondItem)
            {
                try
                {
                    JObject message = (JObject)t["message"]; // Достали сообщение

                    // Достаём id сообщния 
                    int msgid = (int)message["message_id"];

                    User fromUs = GetInfoFrom(ref message); // Достали инфу о юзере
                    Chat ChatUs = GetInfoChat(ref message); // Достали инфу о чате

                    // Достаём дату
                    int date = (int)message["date"];

                    // Достаём текст
                    String text = (String)message["text"];

                    Message msg = new Message();
                    msg._message_id = msgid;
                    msg._from = fromUs;
                    msg._chat = ChatUs;
                    msg._date = date;
                    msg._text = text;

                    _results.Add(new Result { _update_id = (int)t["update_id"], _message = msg });
                    _LastUpdateID = (int)t["update_id"];
                }
                catch (Exception ex)
                {

                }
            }
        }

        // Достаём информацию об отправителе
        private User GetInfoFrom(ref JObject message)
        {
            JObject from = (JObject)message["from"]; // Информация об отправителе
            User fromUs = new User((int)from["id"], (string)from["first_name"], (string)from["last_name"], (string)from["username"]);
            return fromUs;
        }
        private Chat GetInfoChat(ref JObject message)
        {
            JObject chat = (JObject)message["chat"]; // Информация о чате

            int chatId = (int)chat["id"];
            string title = (string)chat["title"]; // Опционально
            String username = (String)chat["username"];
            String first = (String)chat["first_name"];
            String last = (String)chat["last_name"];

            return new Chat(chatId, "private", title, username, first, last);
        }

        public List<Result> GetResult()
        {
            return _results;
        }
    }
}