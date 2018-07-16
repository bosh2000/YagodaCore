using System;
using System.IO;
using System.Xml;

namespace YagodaCore
{
    /// <summary>
    /// Класс инициализации YagodaCore , чтение настроек подключения.
    /// </summary>
    internal class InitYagodaCode
    {
        private SettingYagodaCore setting;

        public void InitYagodaCore()
        {
        }

        public SettingYagodaCore GetSetting()
        {
            var xDoc = new XmlDocument();
            try
            {
                xDoc.Load("seeting.xml");
            }catch(IOException ext)
            {
                Console.WriteLine(ext.Message);
            }

            XmlElement xRoot = xDoc.DocumentElement;
            setting.Url = xRoot.GetAttribute("url");
            setting.Login = xRoot.GetAttribute("login");
            setting.Password = xRoot.GetAttribute("password");
            setting.Port = xRoot.GetAttribute("port");
            setting.IdSale = xRoot.GetAttribute("idsale");
            setting.PrefixDataBase = xRoot.GetAttribute("prefixdatabase");
            return setting;
        }
    }
}