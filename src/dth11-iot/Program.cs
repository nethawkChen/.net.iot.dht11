using System.Net.Sockets;
/*
   Description:
       Raspberry pi 3B+, Raspberry pi OS, .Net 6
       Use DHT11 get Temperture & Humidity data and call web api write to remote server
       Reference: https://github.com/dotnet/iot/tree/main/src/devices/Dhtxx

        Author: Kevin Chen
   Create Date: 2023.01.09
*/

using Model;
using Lib;

Console.WriteLine("DHT11 temperature & humidity test. Ctrl+C to end.");

int pin = 4;  // use GPIO 4

while (true) {
    ThData? thData = DHT11Sample.TestTH(pin);
    if (thData != null) {
        Console.WriteLine($"System Date:{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
        Console.WriteLine($"溫度:{thData.Temperature}, 濕度:{thData.Humidity}, 來源：{thData.Equipment}");

        RemoteSvr remoteSvr = new RemoteSvr();
        remoteSvr.WtiteSvr(thData);
    }

    Thread.Sleep(2000);
}





