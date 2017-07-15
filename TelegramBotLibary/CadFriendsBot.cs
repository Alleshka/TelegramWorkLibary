using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;

namespace TelegramBotLibary
{
    public class CadFriendsBot
    {
        protected string _Token; // Секретный ключ
        protected int _LastUpdateID; // Последнее обновление

        public CadFriendsBot(string Token, int UpdateID)
        {
            this._Token = Token;
            this._LastUpdateID = UpdateID;
        }

        // Получаем обновления через API
        protected string GetUpdates()
        {
            string response = "";

            using (var webClient = new WebClient())
            {
                // Получили неотвеченые сообщения в формате JSON
                response = webClient.DownloadString("https://api.telegram.org/bot" + _Token + "/getUpdates" + "?offset=" + (_LastUpdateID + 1));

                // Парсить, наверное, буду всё таки тут, а выдавать готовые пакеты (информация о сообщении, информация о чате и т.п.)
            }

            return response;
        }

        /// <summary>
        /// Отправляет сообщение в указанный чат
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="message"></param>
        protected void SendMessage(int chatId, string message)
        {
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();

                pars.Add("text", message);
                pars.Add("chat_id", chatId.ToString());

                webClient.UploadValues("https://api.telegram.org/bot" + _Token + "/sendMessage", pars);
            }
        }

        /// <summary>
        /// Отправляет стикер в указанный чат
        /// </summary>
        /// <param name="path"></param>
        /// <param name="chatid"></param>
        protected void SendSticker(int chatId, string path)
        {
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();

                pars.Add("sticker", path);
                pars.Add("chat_id", chatId.ToString());

                webClient.UploadValues("https://api.telegram.org/bot" + _Token + "/sendMessage", pars);
            }
        }

        /// <summary>
        /// Тут будет описываться действие (переопределяется)
        /// </summary>
        /// <param name="response"></param>
        public virtual void ActionParse(string response)
        {

        }

        /// <summary>
        /// Можно по ссылке
        /// </summary>
        /// <param name="response"></param>
        public virtual void ActionParse(ref string response)
        {

        }
    }
}