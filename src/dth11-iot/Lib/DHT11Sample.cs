using Iot.Device.DHTxx;
using Model;
using UnitsNet;

namespace Lib {
    public class DHT11Sample {
        public static ThData? TestTH(int GpioPin) {
            ThData? thData = null;

            try {
                using Dht11 dht11 = new(GpioPin);

                Temperature temperature = default;
                RelativeHumidity humidity = default;

                bool success = dht11.TryReadTemperature(out temperature) && dht11.TryReadHumidity(out humidity);
                if (success) {
                    thData = new ThData() {
                        Temperature = temperature.DegreesCelsius,
                        Humidity = humidity.Percent,
                        Equipment = Utility.GetHostName()
                    };
                }
            } catch (Exception er) {
                Console.WriteLine($"DHT11 未預期的錯誤:{er.Message}");
            }

            return thData;
        }
    }
}