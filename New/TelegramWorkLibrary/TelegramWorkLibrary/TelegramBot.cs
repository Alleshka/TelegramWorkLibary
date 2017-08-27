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

        /// <summary>
        /// Инициализирует бота
        /// </summary>
        /// <param name="token">Секретный ключ</param>
        public TelegramBot(string token)
        {
            this._token = token;
            _results = new Queue<Result>();
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
        /// Получить обновления
        /// </summary>
        public void GetUpdates()
        {
            string responce = "";

            using (WebClient client = new WebClient())
            {
                responce = client.DownloadString("https://api.telegram.org/bot" + _token + "/getUpdates"); // Получаем обновления
            }

            ParseResponce(ref responce); // Сохраняем все ответы
        }

        private void ParseResponce(ref string responce)
        {

        }
    }
}
