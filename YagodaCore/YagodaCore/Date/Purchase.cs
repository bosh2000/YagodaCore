using System;
using System.Collections.Generic;

namespace YagodaCore.Date
{
    /// <summary>
    /// Класс для формирования Json при проведении покупки.
    /// </summary>
    public class Purchase
    {
        public string buyerTel { get; set; }
        public string checkNo { get; set; }
        public DateTime checkDateTime { get; set; }
        public string uuid { get; set; }
        public string checkAmount { get; set; }
        public string bonusAmount { get; set; }
        public string payByBonus { get; set; }
        public string seller { get; set; }
        public string codeWord { get; set; }
        public List<Good> goods { get; set; }
    }

    public class Good
    {
        public string goodsName { get; set; }
        public int qty { get; set; }
        public string unit { get; set; }
        public double price { get; set; }
        public double cost { get; set; }
        public GoodsGroup goodsGroup { get; set; }
    }

    public class ParentGroup
    {
        public string code { get; set; }
        public string name { get; set; }
        public object parentGroup { get; set; }
    }

    public class GoodsGroup
    {
        public string code { get; set; }
        public string name { get; set; }
        public ParentGroup parentGroup { get; set; }
    }
}