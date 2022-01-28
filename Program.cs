using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRKuznitsaKadrov
{
    class Program
    {
        public static List<Transport> transports = new List<Transport>();

        static void Main(string[] args)
        {
            ReadExcel();
            Console.ReadLine();
            Question1();
            Console.ReadLine();
            Question2();
            Console.ReadLine();
        }

        public static void ReadExcel()
        {
            using (StreamReader sr = new StreamReader("Вопрос1.csv",Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    transports.Add(new Transport(Convert.ToInt64(data[0]), data[1], data[2],
                                                 Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToDecimal(data[5])));
                }
            }
        }
        public static void Question1()
        {
            
            var transports100km = transports.Where(w => w.Speed * w.TravelTime / 60 >= 100);
            
            var minTravelTimes = transports100km.GroupBy(g => g.Sity).Select(s => s.Min(m => m.TravelTime));

            var result = transports100km.Where(w => minTravelTimes.Contains(w.TravelTime)).
                Select(s => new { s.Sity, s.ID, s.TransportType, s.TravelTime, TripPrice = s.Price * s.TravelTime / 60});

            foreach (var transport in result)
            {
                Console.WriteLine($"{transport.Sity}. Номер {transport.ID}. Транспорт {transport.TransportType}. Время {transport.TravelTime} мин. Цена {transport.TripPrice} руб.");
            }
                   
        }
        public static void Question2()
        {
            var result = transports.Where(s => s.Sity == "Москва" && (s.TransportType == "P1" || s.TransportType == "P2")
                                          && s.Speed < 60).GroupBy(g => g.TransportType);
            
            foreach (var group in result)
            {
                int totalTravelTime = 0;
                foreach (var transport in group)
                {
                    totalTravelTime += transport.TravelTime;
                }
                Console.WriteLine($"Транспорт {group.Key} провёл {totalTravelTime} минут");
            }
        }
    }
}
