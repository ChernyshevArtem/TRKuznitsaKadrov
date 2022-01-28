using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRKuznitsaKadrov
{
    class Transport
    {
        public long ID { get; set; }
        public string TransportType { get; set; }
        public string Sity { get; set; }
        public int TravelTime { get; set; }
        public int Speed { get; set; }
        public decimal Price { get; set; }

        public Transport (long ID, string TransportType, string Sity, int TravelTime, int Speed, decimal Price)
        {
            this.ID = ID;
            this.TransportType = TransportType;
            this.Sity = Sity;
            this.TravelTime = TravelTime;
            this.Speed = Speed;
            this.Price = Price;
        }
        public override string ToString()
        {
           return $"{ID},{TransportType},{Sity},{TravelTime},{Speed},{Price}";
        }
    }
}
