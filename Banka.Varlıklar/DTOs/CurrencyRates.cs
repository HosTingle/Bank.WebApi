using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Banka.Varlıklar.DTOs
{
    [XmlRoot("rss")]
    public class CurrencyRates
    {
        [XmlElement("channel")]
        public Channel Channel { get; set; }
    }

    public class Channel
    {
        [XmlElement("item")]
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        [XmlElement("targetCurrency")]
        public string Code { get; set; }

        [XmlElement("exchangeRate")]
        public decimal Rate { get; set; }

        // İstersen diğer alanları da ekleyebilirsin
    }


}
