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

        public bool Connect()
        {
            return true;
        }

        public Entity GetInfo(string NumberTel)
        {
            string json="";
            return JsonConvert.DeserializeObject<Entity>(json);
        }

        public bool WritePurchase(Purchase purchase)
        {
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}