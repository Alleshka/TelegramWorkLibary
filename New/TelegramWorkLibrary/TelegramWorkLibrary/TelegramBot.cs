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

        /// <summary>
        /// Разбираем сообщение по "полочкам"
        /// </summary>
        /// <param name="tempObject"></param>
        /// <returns>Собранное сообщение</returns>
        private Message GetMessage(JObject tempObject)
        {
            Message tmpMes = new Message();

            tmpMes._messageId = (int)tempObject["message_id"]; // Получаем ID сообщения
            tmpMes._date = (int)tempObject["date"]; // Получаем дату сообщения       
            tmpMes._chat = GetChat((JObject)tempObject["chat"]); // Получаем чат          

            // Необязательные параметры
            tmpMes._from = GetUser((JObject)tempObject["from"]); // Получаем отправителя сообщения
            tmpMes._text = (String)tempObject["text"]; // Получаем текст сообщения
            tmpMes._entities = GetEntities((JArray)tempObject["entities"]); // Получаем "особые сущности"
            tmpMes._audio = GetAudio((JObject)tempObject["audio"]); // Получаем информацию об аудио
            tmpMes._document = GetDocument((JObject)tempObject["document"]); // Получаем информацию о документе
            tmpMes._photo = GetPhoto((JArray)tempObject["photo"]); // Получаем фото
            tmpMes._sticker = GetSticker((JObject)tempObject["sticker"]); // Получаем информацию о стикере
            tmpMes._video = GetVideo((JObject)tempObject["video"]); // Опционально. Информация о видеозаписи 
            tmpMes._voice = GetVoice((JObject)tempObject["voice"]); // Опционально.Информация о голосовом сообщении 
            tmpMes._caption = (String)tempObject["caption"]; // Получаем описание к файлу 
            tmpMes._contact = GetContact((JObject)tempObject["contact"]); // Достаём информацию об отправленном контакте
            tmpMes._locationg = GetLocation((JObject)tempObject["location"]); // Получаем информацию о местоположении
            tmpMes._venue = GetVenue((JObject)tempObject["venue"]); // Достаём инфу о месте на карте 
            tmpMes._newChatMember = GetUser((JObject)tempObject["new_chat_member"]); // Достаём информацию о новом пользователе
            tmpMes._leftChatMember = GetUser((JObject)tempObject["left_chat_member"]); // Достаём информацию о вышедшем пользователе
            tmpMes._newChatTitle = (String)tempObject["new_chat_title"]; // Получаем инфу о новом заголовке
            tmpMes._newChatPhoto = GetPhoto((JArray)tempObject["new_chat_photo"]); // Получаем новые фотки чата 

            tmpMes._deleteChatPhoto = (bool?)tempObject["delete_chat_photo"];
            tmpMes._groupChatCreated = (bool?)tempObject["group_chat_created"];
            tmpMes._supergroupChatCreated = (bool?)tempObject["supergroup_chat_created"];
            tmpMes._channelChatCreated = (bool?)tempObject["channel_chat_created"];
            tmpMes._migrateToChatId = (int?)tempObject["migrate_to_chat_id"];
            tmpMes._migrateFromChatId = (int?)tempObject["migrate_from_chat_id"];

            return tmpMes;
        }

        /// <summary>
        /// Получаем информацию о пользователе
        /// </summary>
        /// <param name="tempObject"></param>
        /// <returns></returns>
        private User GetUser(JObject tempObject)
        {
            User tmpUs = new User();

            tmpUs._id = (int)tempObject["id"]; // Получаем id пользователя
            tmpUs._firstName = (String)tempObject["first_name"]; // Получаем имя пользователя
            tmpUs._lastName = (String)tempObject["last_name "]; // Получаем фамилию пользователя
            tmpUs._userName = (String)tempObject["username"]; // Получаем логин пользователя

            return tmpUs;
        }
        /// <summary>
        /// Получае информацию о чате
        /// </summary>
        /// <param name="tempObject"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Получаем информацию о сущностях
        /// </summary>
        /// <param name="tempObject"></param>
        /// <returns></returns>
        private MessageEntity[] GetEntities(JArray tempObject)
        {
            if (tempObject != null)
            {
                List<MessageEntity> tempEnt = new List<MessageEntity>(); // Тут будет хранится

                foreach (JObject temp in tempObject)
                {
                    MessageEntity entity = new MessageEntity();

                    entity._length = (int)temp["length"]; // Сохраняем размер
                    entity._offset = (int)temp["offset"]; // Сохраняем смещение
                    entity._type = GetTypeEntity((String)temp["type"]); // Получаем тип

                    if (entity._type == TypeEntity.text_link) entity._url = (String)temp["url"]; // Если есть, получаем ссылку

                    tempEnt.Add(entity);
                }

                return tempEnt.ToArray();
            }
            else return null;
        }
        /// <summary>
        /// Получаем информацию об аудиофайле
        /// </summary>
        /// <param name="tempObject"></param>
        /// <returns></returns>
        private Audio GetAudio(JObject tempObject)
        {
            if (tempObject != null)
            {
                Audio tmpAudio = new Audio();

                tmpAudio._duration = (int)tempObject["duration"]; // Получаем продолжительность
                tmpAudio._fileId = (String)tempObject["file_id"]; // Получаем ID файла 
                tmpAudio._fileSize = (int?)tempObject["file_size"]; // Получем рзмер файла (может быть null)
                tmpAudio._mimeType = (String)tempObject["mime_type"]; // Получаем MIME файла
                tmpAudio._performer = (String)tempObject["performer"]; // Информация об исполнителе
                tmpAudio._title = (String)tempObject["title"]; // Заголовок есни

                return tmpAudio;
            }
            else return null;
        }
        private Document GetDocument(JObject tempObject)
        {
            if (tempObject != null)
            {
                Document _doc = new Document();

                _doc._fileId = (String)tempObject["file_id"]; // Получаем id файла 
                _doc._thumb = GetPhotoSize((JObject)tempObject["thumb"]); // Получаем миниатюру
                _doc._fileName = (String)tempObject["file_name"]; // Получаем имя файла
                _doc._mimeType = (String)tempObject["mime_type"]; // Получаем MIME
                _doc._fileSize = (int?)tempObject["file_size"]; // Получаем размер файла

                return _doc;
            }
            else return null;
        }
        private PhotoSize[] GetPhoto(JArray tempObject)
        {
            if (tempObject != null)
            {
                List<PhotoSize> tmpPh = new List<PhotoSize>();

                foreach (var t in tempObject)
                {
                    PhotoSize tmp = GetPhotoSize((JObject)t);
                    tmpPh.Add(tmp);
                }

                return tmpPh.ToArray();
            }
            else return null;
        }
        private Sticker GetSticker(JObject tempObject)
        {
            if (tempObject != null)
            {
                Sticker _stiker = new Sticker();

                _stiker._fileId = (String)tempObject["file_id"]; // Получаем id стикера 
                _stiker._fileSize = (int?)tempObject["width"]; // Получаем размер файла 
                _stiker._height = (int)tempObject[""]; // Получить высоту стикера 
                _stiker._thumb = GetPhotoSize((JObject)tempObject[""]); // Получаем превью
                _stiker._width = (int)tempObject[""]; // Получем ширину стикера

                return _stiker;
            }
            else return null;
        }
        private Video GetVideo(JObject tempObject)
        {
            if (tempObject != null)
            {
                Video _video = new Video();

                _video._duration = (int)tempObject["duration"]; // Получаем продолжительность 
                _video._fileId = (String)tempObject["file_id"]; // Получаем id файла 
                _video._fileSize = (int?)tempObject["file_size"]; // Получаем размер файла 
                _video._height = (int)tempObject["height"]; // Получаем высоту заданную отправителем 
                _video._mimeType = (String)tempObject["mime_type"]; // Получаем MIME 
                _video._thumb = GetPhotoSize((JObject)tempObject["thumb"]); // Получаем миниатюру 
                _video._width = (int)tempObject["width"]; // Получаем ширину

                return _video;
            }
            else return null;
        }
        private Voice GetVoice(JObject tempObject)
        {
            if (tempObject != null)
            {
                Voice _voice = new Voice();

                _voice._duration = (int)tempObject["duration"]; // Получаем продолжительность 
                _voice._fileId = (String)tempObject["file_id"]; // Получаем id файла 
                _voice._fileSize = (int?)tempObject["file_size"]; // Получаем размер файла 
                _voice._mimeType = (String)tempObject["mime_type"]; // Получаем MIME файла 

                return _voice;
            }
            else return null;
        }
        private Contact GetContact(JObject tempObject)
        {
            if (tempObject != null)
            {
                Contact _contact = new Contact();

                _contact._firstName = (String)tempObject["first_name"]; // Получаем имя 
                _contact._lastName = (String)tempObject["last_name"]; // Получаем фамилию
                _contact._phoneNumber = (String)tempObject["phone_number"]; // Получаем номер телефона 
                _contact._userId = (int?)tempObject["user_id"]; // Получаем номер пользователя 

                return _contact;
            }
            else return null;
        }
        private Location GetLocation(JObject tempObject)
        {
            if (tempObject != null)
            {
                Location _location = new Location();

                _location._latitude = (float)tempObject["longitude"];
                _location._longitude = (float)tempObject["latitude"]; 

                return _location;
            }
            else return null;
        }
        private Venue GetVenue(JObject tempObject)
        {
            if (tempObject != null)
            {
                Venue _venue = new Venue();

                _venue._address = (String)tempObject["address"]; // Достаём адрес 
                _venue._fourSquareId = (String)tempObject["foursquare_id"]; // Достаём id в FourSquare
                _venue._location = GetLocation((JObject)tempObject["location"]); // Достём инфу о локации
                _venue._title = (String)tempObject["title"]; // Достаём заголовок

                return _venue;
            }
            else return null;
        }
        


        /// <summary>
        /// Получаем тип чата
        /// </summary>
        /// <param name="tempobject"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Получаем тип сущности
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private TypeEntity GetTypeEntity(String type)
        {
            switch (type)
            {
                case "mention": return TypeEntity.mention;
                case "hashtag": return TypeEntity.hashtag;
                case "bot_command": return TypeEntity.bot_command;
                case "url": return TypeEntity.url;
                case "email": return TypeEntity.email;
                case "bold": return TypeEntity.bold;
                case "italic": return TypeEntity.italic;
                case "code": return TypeEntity.code;
                case "pre": return TypeEntity.pre;
                case "text_link": return TypeEntity.text_link;
                default: return default(TypeEntity);
            }
        }
        private PhotoSize GetPhotoSize(JObject tempObject)
        {
            if (tempObject != null)
            {
                PhotoSize temp = new PhotoSize();

                temp._fileId = (String)tempObject["file_id"];
                temp._fileSize = (int?)tempObject["file_size"];
                temp._height = (int)tempObject["height"];
                temp._width = (int)tempObject["width"];

                return temp;
            }
            else return null;
        }
    }
}
