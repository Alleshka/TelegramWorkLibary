using System;

namespace TelegramWorkLibrary.Struct
{
    // Этот объект представляет точку на карте.
    public struct Location
    {
        public float _longitude { get; set; } // Долгота 
        public float _latitude { get; set; } // Широта
    }
}
