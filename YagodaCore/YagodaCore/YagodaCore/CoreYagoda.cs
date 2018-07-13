using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using YagodaCore.Date;

namespace YagodaCore
{
    internal class CoreYagoda : System.IDisposable
    {
        private WebClient webClient;

        private string Url = "http://dev.progrepublic.ru";
        private string Login = "vapeko";
        private string Password = "vapeko321";
        private string Port = "57773";
        private string IdSale = "GE";

        public CoreYagoda()
        {
        }

        /// <summary>
        /// Подготовка и инициализация WebClient
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            webClient = new WebClient()
            {
                Encoding = Encoding.UTF8
            };

            return webClient == null ? false : true;
        }

        /// <summary>
        /// Получение информации и статуса по номеру телефона.
        /// </summary>
        /// <param name="NumberTel">Номер телефона.</param>
        /// <returns>Класс Entity, десерелизованный Json ответ </returns>
        public Entity GetInfo(string NumberTel)
        {
            string urlRequest = Url + ":" + Port + "/csp/yagodapreprod/" + IdSale + "/getJsonInfo/" + NumberTel;

            string responceJson = string.Empty;

            try
            {
                NetworkCredential networkCredential = new NetworkCredential(Login, Password);
                webClient.Credentials = networkCredential;
                responceJson = webClient.DownloadString(new Uri(urlRequest));
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Entity result = JsonConvert.DeserializeObject<Entity>(responceJson);

            return result;
        }

        /// <summary>
        /// Отправка  на сервер покупки.
        /// </summary>
        /// <param name="purchase"></param>
        /// <returns></returns>
        public bool WritePurchase(Purchase purchase)
        {
            return true;
        }

        /// <summary>
        /// Реализация интерфейся IDisposable, для закрытия рессурсов.
        /// </summary>
        public void Dispose()
        {
            webClient.Dispose();
        }
    }
}