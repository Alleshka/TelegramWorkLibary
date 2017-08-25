using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект содержит фотографии профиля пользователя.
    public struct UserPhrofilePhotos
    {
        public long _totalCount { get; set; } // Число фотографий профиля
        public PhotoSize[] _photos { get; set; } // Запрошенные изображения, каждое в 4 разных размерах.
    }
}
