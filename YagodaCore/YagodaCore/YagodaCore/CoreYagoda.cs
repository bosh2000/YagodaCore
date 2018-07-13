﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using YagodaCore.Date;

namespace YagodaCore
{
    internal class CoreYagoda : System.IDisposable
    {
        private WebClient webClient;

        /// <summary>
        /// Параметры подключения к серверу Ягоды.
        /// </summary>
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
        /// <returns>False при неудачной попытки создать объект.</returns>
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

            var json = JsonConvert.SerializeObject(purchase);

            try
            {
                NetworkCredential networkCredential = new NetworkCredential(Login, Password);
                //webClient.Credentials = networkCredential;
                var httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(Url + ":" + Port + "/csp/yagodapreprod/" + IdSale +"/postdata"));
                httpRequest.Method = "POST";
                httpRequest.Credentials = networkCredential;
                httpRequest.ContentType = "application/json";
                
                using (var requestStream = httpRequest.GetRequestStream())
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(json);
                }
                using (var httpResponse = httpRequest.GetResponse())
                using (var responseStream = httpResponse.GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    string response = reader.ReadToEnd();
                }
            }catch (WebException exp)
            {
                Console.WriteLine(exp.Message);
            }
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