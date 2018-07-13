using System;
using YagodaCore.Date;
using Newtonsoft.Json;

namespace YagodaCore
{
    internal class CoreYagoda  : System.IDisposable
    {

        private string Url = "dev.progrepablic.ru";
        private string Login = "vapeko";
        private string Password = "vapeko321";
        private string Port = "57773";
        private string IdSale = "GE";


        public CoreYagoda()
        {
        }

        /// <summary>
        /// Подключение к базе.
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            return true;
        }

        /// <summary>
        /// Получение информации и статуса по номеру телефона.
        /// </summary>
        /// <param name="NumberTel">Номер телефона.</param>
        /// <returns>Класс Entity, десерелизованный Json ответ </returns>
        public Entity GetInfo(string NumberTel)
        {
            string json="";
            return JsonConvert.DeserializeObject<Entity>(json);
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
            throw new NotImplementedException();
        }
    }
}