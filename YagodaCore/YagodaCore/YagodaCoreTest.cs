using System;
using System.Collections.Generic;
using YagodaCore.Date;
using NLog;

namespace YagodaCore
{
    internal class YagodaCoreTest
    {
        public static Logger logger;
        private static void Main(string[] args)
        {
            logger = LogManager.GetCurrentClassLogger();
            using (var yagodaCore = new CoreYagoda(logger))
            {

                try
                {
                    logger.Info("Открываем подключение к базе...");
                    yagodaCore.Connect();
                }catch(Exception exp)
                {
                    logger.Error("Ошибка подключения к базе." + exp.Message);
                }
                finally
                {
                    logger.Info("Подключение к базе успешно.");
                }

                Console.WriteLine(yagodaCore.GetInfo("79625020828").ToString());

                
                Purchase purchase = new Purchase()
                {
                    buyerTel = "+7(962)5020828",
                    checkNo = "000002223434",
                    checkDateTime = DateTime.Now,
                    uuid = Guid.NewGuid().ToString(),     // тут должен быть ID чека в торговой системе.
                    checkAmount = "100",
                    bonusAmount = "20",
                    payByBonus = "0",
                    seller = "ИП Иванов А.А.",
                    codeWord = "",
                    goods = new List<Good>()
                    {
                        new Good()
                        {
                            goodsName="Хлеб",
                            qty=10,
                            unit="шт.",
                            price=10,
                            cost=100,
                            goodsGroup=null
                        }
                    }
                };

                yagodaCore.WritePurchase(purchase);

                Console.WriteLine(yagodaCore.GetInfo("79625020828").ToString());


            };
            Console.ReadLine();
        }
    }
}