using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary
{
    public class TelegramBot
    {
        private Queue<Result> _results; // Очередь результатов 
        private String _token; // Секретный ключ
        private int _lastUpdateId; // Последнее обновление

        /// <summary>
        /// Инициализирует бота
        /// </summary>
        /// <param name="token">Секретный ключ</param>
        public TelegramBot(string token)
        {
            this._token = token;
            _results = new Queue<Result>();
            _lastUpdateId = 0;
        }
        /// <summary>
        /// Возвращает количетсво результатов
        /// </summary>
        /// <returns>Количество результатов в очереди</returns>
        public int GetCountResult()
        {
            return _results.Count; 
        }
        /// <summary>
        /// Получаем следующийр езультат и удаляем его из очереди
        /// </summary>
        /// <returns>Первый в очереди результат</returns>
        public Result GetNextResult()
        {
            return _results.Dequeue();
        }

        /// <summary>
        /// При желании можно установить последнее обновление
        /// </summary>
        /// <param name="id"></param>
        public void SetLastUpdate(int id)
        {
            _lastUpdateId = id;
        }

        /// <summary>
        /// Получить обновления
        /// </summary>
        public void GetUpdates()
        {
            string responce = "";

            using (WebClient client = new WebClient())
            {
                responce = client.DownloadString("https://api.telegram.org/bot" + _token + "/getUpdates" + "?offset = " + (_lastUpdateId+1)); // Получаем обновления 
            }

            ParseResponce(ref responce); // Сохраняем все ответы
        }

        private void ParseResponce(ref string responce)
        {
            JObject oneObject = JObject.Parse(responce); // Спарсили

            JArray respondItem = (JArray)oneObject["result"]; // Достали ответы

            if (respondItem.Count > 0)
            {
                foreach (JObject t in respondItem)
                {
                    Result tmpRes = new Result();
                    tmpRes._updateId = (int)t["update_id"]; // Получаем updateId

                    // Если новое сообщение
                    if (tmpRes._updateId > _lastUpdateId)
                    {
                        tmpRes._message = GetMessage((JObject)t["message"]); // Получаем сообщение
                        _results.Enqueue(tmpRes); // Добавляем в очередь
                        _lastUpdateId = tmpRes._updateId; // Запоминаем
                    }
                }
            }
        }
        private Message GetMessage(JObject tempObject)
        {
            Message tmpMes = new Message();

            tmpMes._messageId = (int)tempObject["message_id"]; // Получаем ID сообщения
            tmpMes._date = (int)tempObject["date"]; // Получаем дату сообщения       
            tmpMes._chat = GetChat((JObject)tempObject["chat"]); // Получаем чат          

            // Необязательные параметры
            tmpMes._from = GetUser((JObject)tempObject["from"]); // Получаем отправителя сообщения
            tmpMes._text = (String)tempObject["text"]; // Получаем текст сообщения

            return tmpMes;
        }

        private User GetUser(JObject tempObject)
        {
            User tmpUs = new User();

            tmpUs._id = (int)tempObject["id"]; // Получаем id пользователя
            tmpUs._firstName = (String)tempObject["first_name"]; // Получаем имя пользователя
            tmpUs._lastName = (String)tempObject["last_name "]; // Получаем фамилию пользователя
            tmpUs._userName = (String)tempObject["username"]; // Получаем логин пользователя

            return tmpUs;
        }
        private Chat GetChat(JObject tempObject)
        {
            Chat tmpChat = new Chat();

            tmpChat._id = (int)tempObject["id"];
            tmpChat._title = (String)tempObject["title"];
            tmpChat._firstName = (String)tempObject["first_name"];
            tmpChat._lastName = (String)tempObject["last_name"];
            tmpChat._userName = (String)tempObject["username"];
            tmpChat._type = GetTypeChat((JObject)tempObject);

            return tmpChat;
        }

        private TypeChat GetTypeChat(JObject tempobject)
        {
            switch ((String)tempobject["type"])
            {
                case "private": return TypeChat.PRIVATE;
                case "group": return TypeChat.GROUP;
                case "supergroup": return TypeChat.SUPERGROUP;
                case "channel": return TypeChat.CHANNEL;
                default: return TypeChat.PRIVATE; // Пусть дефолт будет
            }
        }
    }
}
