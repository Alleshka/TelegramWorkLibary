using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет объект на карте.
    public struct Venue
    {
        public Location _location { get; set; } // Координаты обхекта 
        public String _title { get; set; } // Название объекта
        public String _address { get; set; } // Адрес объекта
        public String _fourSquareId { get; set; } // Опционально. Идентификатор объекта в Foursquare
    }
}
