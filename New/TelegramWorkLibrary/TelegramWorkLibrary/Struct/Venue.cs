using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramWorkLibrary.Struct
{
    struct Venue
    {
        public Location _location { get; set; } // Координаты обхекта 
        public String _title { get; set; }
        public String _address { get; set; } 
        public String _fourSquareId { get; set; }
    }
}
