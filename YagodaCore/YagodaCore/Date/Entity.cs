using System.Collections.Generic;

namespace YagodaCore
{
    /// <summary>
    /// Класс описывающий Json ответ сервера.
    /// </summary>
    ///
    public class Entity
    {
        public Profile profile { get; set; }
        public string status { get; set; }
        public Info info { get; set; }
    }

    public class Profile
    {
        public string name { get; set; }
        public string birthDate { get; set; }
        public string sex { get; set; }
        public string fromSomeone { get; set; }
        public string comment { get; set; }
    }

    public class Info
    {
        public double balance { get; set; }
        public int averagePurchaseAmount { get; set; }
        public int rubSum { get; set; }
        public string status { get; set; }
        public string age { get; set; }
        public string monthCount { get; set; }
        public List<object> lastPurchase { get; set; }
        public List<string> segments { get; set; }
    }
}
