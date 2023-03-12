using System.Net.Http.Headers;
using System.Text;
using Model;
using Newtonsoft.Json;

namespace Lib {
    public class RemoteSvr {
        String svrApiUrl = "http://10.0.100.90:82/api/";
        String loginApi = "Account/Login";
        String thApi = "DaysTH/AddTh";

        /// <summary>
        /// 呼叫 Web Api
        /// </summary>
        /// <param name="thData"></param>
        public async void WtiteSvr(ThData thData) {
            try {
                string token = await GetApiToken();
                var api = svrApiUrl + thApi;
                using (var client = new HttpClient()) {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    String dht11Payload = "{";
                    dht11Payload += "\"Temperature\":" + thData.Temperature;
                    dht11Payload += ",\"Humidity\":" + thData.Humidity;
                    dht11Payload += ",\"Equipment\":\"" + thData.Equipment + "\"";
                    dht11Payload += "}";

                    HttpContent content = new StringContent(dht11Payload, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(api, content);
                    var rep = response.Content.ReadAsStringAsync();
                    var ret = rep.Result;
                    Console.WriteLine($"ret={ret}");
                }
            } catch (Exception er) {
                Console.WriteLine($"WtiteSvr() error:{er.Message}");
            }
        }

        /// <summary>
        /// 取得jwt token
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> GetApiToken() {
            string? token = "";
            var api = svrApiUrl + loginApi;
            using (var client = new HttpClient()) {
                try {
                    var payload = "{\"username\":\"user1\",\"password\":\"12345\"}";
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(api, content);
                    var rep = response.Content.ReadAsStringAsync();
                    var ret = rep.Result;
                    var jwtRsp = JsonConvert.DeserializeObject<JwtResponse>(ret);
                    token = jwtRsp.token;
                    return token;
                } catch (Exception er) {
                    throw new Exception(er.Message);
                }
            }

        }
    }
}