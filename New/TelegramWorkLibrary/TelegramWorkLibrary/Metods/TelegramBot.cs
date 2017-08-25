using System;
using System.Collections.Generic;
using TelegramWorkLibrary.Struct;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TelegramWorkLibrary.Metods
{
    // Реализуем метод
    public class TelegramBot
    {
        // Доступны во всей программе
        public static String _token { get; set; } // Секретный ключ бота
        public static Queue<Result> _results { get; set; } // Очередь ответов

        public TelegramBot()
        {

        }
        public TelegramBot(String token)
        {
            _token = token;
            _results = new Queue<Result>();
        }

        // Получить обновления
        public async void GetUpdates()
        {
            string responce = ""; // Сюда сохраняем ответ

            using (var client = new WebClient())
            {
                responce = client.DownloadString("https://api.telegram.org/bot" + _token + "/getUpdates"); // Получаем обновления
                AddResult(ref responce);
            }
        }


        private void AddResult(ref string t)
        {
            string temp = t;
            JObject obj = JObject.Parse(t); // Считали строку
            // t = t.Replace(temp, ""); // -_-

            JArray respondItem = (JArray)obj["result"]; // Достал все ответы
            obj = null;

            // Проходим по всем результатам
            foreach (JObject tempObject in respondItem)
            {
                Result _res = GetResult(tempObject); // Достаём результат
                _results.Enqueue(_res); // Добавляем в конец очереди
            }
        }

        private Result GetResult(JObject tempObject)
        {
            Result tmp = new Result()
            {
                _updateId = (int)tempObject["update_id"], // Сохряняем 
                _message = GetMessage((JObject)tempObject["message"]) // Получаем сообщение
            };
            return tmp; // Возвращаем результат
        }

        /// <summary>
        /// Тут надо будет посмотреть, что не может отправиться вместе и поставить условия
        /// Парсим входящее сообщение
        /// </summary>
        /// <param name="tempObject"></param>
        /// <returns></returns>
        private Message GetMessage(JObject tempObject)
        {
            Message tmp = new Message()
            {
                _messageId = (long)tempObject["message_id"], // Получили id сообщения 
                _from = GetUser((JObject)tempObject["from"]), // Получаем отправителя
                _date = (long)tempObject["date"], // Получаем дату
                _chat = GetChat((JObject)tempObject["chat"]), // Получаем информацию о чате
                _forwardFrom = GetUser((JObject)tempObject["forward_from"]), // Получаем инфу об отправителе пересланного сообщения 
                _forwardDate = (long)tempObject["forward_date"], // Получаем дату отправки оригинального сообщения
                                                                 // Тут над получать оригинал сообщения или хотя бы ID
                _text = (String)tempObject["text"], // Получаем текст сообщения
                                                    // Пока не знаю, как они выглядят // tmp._entities = GetEntities((JObject)tempObject["entities"]); // Получаем особые сущности
                _audio = GetAudio((JObject)tempObject["audio"]), // Получаем аудио
                _document = GetDocument((JObject)tempObject["document"]), // Получаем документ
                                                                          // Пока не знаю, как выглядит tmp._photo = GetPhoto((JObject)tempObject["photo"]); // Получаем фото
                _sticker = GetSticker((JObject)tempObject["sticker"]), // Получаем стикер
                _video = GetVideo((JObject)tempObject["video"]), // Получаем видео
                _voice = GetVoice((JObject)tempObject["voice"]), // Получаем голосовое сообщение
                _caption = (String)tempObject["caption"], // Получем подпись к файлу, фото или видео
                _contact = GetContact((JObject)tempObject["contact"]), // Получаем информацию о контакте
                _location = GetLocation((JObject)tempObject["location"]), // Получем информацию о местоположении
                _venue = GetVenue((JObject)tempObject["venue"]), // Получаем информацию о месте на карте
                _newChatMember = GetUser((JObject)tempObject["new_chat_member"]), // Информация о новом пользователе, добавленном в группу
                _leftChatMember = GetUser((JObject)tempObject["left_chat_member"]), // Информация о пользователе, далённом из группы 
                _newChatTitle = (String)tempObject["new_chat_title"], // Новое название группы 
                                                                      // tmp._newChatPhoto = GetPhoto((JObject)tempObject["new_chat_photo"]); // Новое фото группы
                _deleteChatPhoto = (bool)tempObject["delete_chat_photo"], // Фото группы было удалено
                _groupChatCreated = (bool)tempObject["group_chat_created"], // Супергрупа создана
                _channelChatCreated = (bool)tempObject["channel_chat_created"], // Канал создан
                _migrateToChatId = (long)tempObject["migrate_to_chat_id"], // Группа была преобразована в супергруппу с указанным ID 
                _migrateFromChatId = (long)tempObject["migrate_from_chat_id"] // Супергруппа была создана из группы с указанным ID
            };
            // Получаем указаное сообщение

            return tmp;
        }

        private User GetUser(JObject tempObject)
        {
            User tmp = new User()
            {
                _userID = (long)tempObject["id"], // Получаем ID пользователя
                _FirstName = (String)tempObject["first_name"], // Получаем имя пользователя
                _LastName = (String)tempObject["last_name"], // Получаем фамилию пользователя
                _UserName = (String)tempObject["username"] // Получаем логин пользователя бота
            };
            return tmp;
        }
        private Chat GetChat(JObject tempObject)
        {
            Chat tmp = new Chat()
            {
                _id = (long)tempObject["id"], // Получаем id чата 
                _type = GetTypeChat((String)tempObject["type"]), // Получаем тип чата
                _title = (String)tempObject["title"], // Получаем заголовок чата
                _userName = (String)tempObject["username"], // Получаем логин пользователя
                _FirstName = (String)tempObject["first_name"], // Получаем имя пользователя
                _LastName = (String)tempObject["last_name"] // Получаем фамилию пользователя
            };
            return tmp;
        }
        private TypeChat GetTypeChat(String type)
        {
            switch (type)
            {
                case "private": return TypeChat.PRIVATE;
                case "group": return TypeChat.GROUP;
                case "supergroup": return TypeChat.SUPERGROUP;
                case "channel": return TypeChat.CHANNEL;
            }
            return default(TypeChat);
        }
        //private MessageEntity[] GetEntities(JObject tempObject)
        //{
        //    List<MessageEntity> msg = new List<MessageEntity>();

        //}
        private Audio GetAudio(JObject tempObject)
        {
            Audio tmp = new Audio()
            {
                _fileId = (String)tempObject["file_id"], // Получаем ID
                _duration = (long)tempObject["duration"], // Получем длительность
                _performer = (String)tempObject["performer"], // Получаем исполнителя
                _title = (String)tempObject["title"], // Получаем заголовок
                _mimeType = (String)tempObject["mime_type"], // Получаем MIME
                _fileSize = (long)tempObject["file_size"] // Получаем размер файла
            };
            return tmp;
        }
        private Document GetDocument(JObject tempObject)
        {
            Document tmp = new Document()
            {
                _fileId = (String)tempObject["file_id"], // Получаем Id
                _thumb = GetPhotoSize((JObject)tempObject["thumb"]), // Получаем фотку
                _fileName = (String)tempObject["file_name"], // Получаем название файла
                _mymeType = (String)tempObject["mime_type"], // Получаем MIME
                _fileSize = (long)tempObject["file_size"] // Получаем размер файла
            };
            return tmp;
            
        }
        private PhotoSize GetPhotoSize(JObject temmpObject)
        {
            PhotoSize tmp = new PhotoSize()
            {
                _fileId = (String)temmpObject["file_id"], // Получаем id 
                _width = (long)temmpObject["width"], // Получаем ширину
                _height = (long)temmpObject["height"], // Получаем высоту 
                _fileSize = (long)temmpObject["file_size"] // Получаем размер файла 
            };
            return tmp;
        }
        //private PhotoSize[] GetPhoto(JObject tempObject)
        //{
           
        //}
        private Sticker GetSticker(JObject tempObject)
        {
            Sticker tmp = new Sticker()
            {
                _fileId = (String)tempObject["file_id"], // ID файла 
                _width = (long)tempObject["width"], // Ширина стикера
                _height = (long)tempObject["height"], // Высота стикера 
                _thumb = GetPhotoSize((JObject)tempObject["thumb"]), // Превью
                _fileSize = (long)tempObject["file_size"] // Размер файла 
            };
            return tmp;
        }
        private Video GetVideo(JObject tempObject)
        {
            Video tmp = new Video()
            {
                _fileId = (String)tempObject["file_id"],
                _width = (long)tempObject["width"],
                _height = (long)tempObject["height"],
                _duration = (long)tempObject["duration"],
                _thumb = GetPhotoSize((JObject)tempObject["thumb"]),
                _mimeType = (String)tempObject["mime_type"],
                _fileSize = (long)tempObject["file_size"]
            };
            return tmp;
        }
        private Voice GetVoice(JObject tempObject)
        {
            Voice tmp = new Voice()
            {
                _fileId = (String)tempObject["file_id"],
                _duration = (long)tempObject["duration"],
                _mimeType = (String)tempObject["mime_type"],
                _fileSize = (long)tempObject["file_size"]
            };
            return tmp;
        }
        private Contact GetContact(JObject tempObject)
        {
            Contact tmp = new Contact()
            {
                _phoneNumber = (String)tempObject[""],
                _FirstName = (String)tempObject[""],
                _LastName = (String)tempObject[""],
                _userID = (long)tempObject[""]
            };
            return tmp;
        }
        private Location GetLocation(JObject tempObject)
        {
            Location tmp = new Location()
            {
                _longitude = (float)tempObject["longitude"],
                _latitude = (float)tempObject["latitude"]
            };
            return tmp;
        }
        private Venue GetVenue(JObject tempObject)
        {
            Venue tmp = new Venue()
            {
                _location = GetLocation((JObject)tempObject["location"]),
                _title = (String)tempObject["title"],
                _address = (String)tempObject["address"],
                _fourSquareId = (String)tempObject["foursquare_id"]
            };
            return tmp;
        }
    }
}