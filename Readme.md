# DHT11 溫濕度感測元件

DHT11 是便宜又好用的一個溫度和濕度的感測元件﹐使用 .Net 開發要引用 Iot.Device.DHTxx﹐然後透過 TryReadTemperature 和 TryReadHumidity 分別取得溫度和濕度的數值

```
bool success = dht11.TryReadTemperature(out temperature) && dht11.TryReadHumidity(out humidity);
if (success) {
    thData = new ThData() {
        Temperature = temperature.DegreesCelsius,
        Humidity = humidity.Percent,
        Equipment = Utility.GetHostName()
    };
}
```

這個實驗的接線圖如下
![DHT11](https://github.com/nethawkChen/.net.iot.dht11/blob/main/fzz/DHT11-module_bb.png)