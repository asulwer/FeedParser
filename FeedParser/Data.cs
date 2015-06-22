using System;
using System.ComponentModel; //Browseable
using System.Collections.Generic; //List

using System.Linq; //Select
using System.Xml.Linq; //XElement & Descendants
using System.Xml.Serialization; //Serialize & Deserialize
using System.Windows.Forms.DataVisualization.Charting; //Charting Tooltips
using System.Web; //HttpUtility

namespace FeedParser
{
    [Serializable()]
    public class Feed
    {
        public Feed()
        {
            Symbol = "";
            Price = 0;
            Date = DateTime.Now;
            Change = 0;
            Open = 0;
            High = 0;
            Low = 0;
            Volume = 0;
        }

        public Feed(string symbol, Decimal price, DateTime date, Decimal change, Decimal open, Decimal high, Decimal low, Int64 volume)
        {
            Symbol = symbol;
            Price = price;
            Date = date;
            Change = change;
            Open = open;
            High = high;
            Low = low;
            Volume = volume;
        }

        //order by Date
        public static int CompareDate(Feed d1, Feed d2)
        {
            return d2.Date.CompareTo(d1.Date);
        }

        //order by volume
        public static int CompareVolume(Feed d1, Feed d2)
        {
            return d2.Volume.CompareTo(d1.Volume);
        }
        
        [Browsable(false)]
        public string Symbol { get; set; }
        public Decimal Price { get; set; }
        public DateTime Date { get; set; }
        public Decimal Change { get; set; }
        public Decimal Open { get; set; }
        public Decimal High { get; set; }
        public Decimal Low { get; set; }
        public Int64 Volume { get; set; }
    }

    public class Investment
    {
        public Investment()
        {
            Symbol = "";
            Date = DateTime.Now;
            Number = 0;
            PricePurchase = 0;
            PriceNow = 0;
            EpsilonPurchase = 0;
            EpsilonNow = 0;
            Status = "";
        }

        public Investment(string symbol, DateTime date, Int64 number, Decimal pricepurchase, Decimal pricenow, Decimal epsilonpurchase, Decimal epsilonnow, string status)
        {
            Symbol = symbol;
            Date = date;
            Number = number;
            PricePurchase = pricepurchase;
            PriceNow = pricenow;
            EpsilonPurchase = epsilonpurchase;
            EpsilonNow = epsilonnow;
            Status = status;
        }

        //order by Date
        public static int CompareDate(Investment i1, Investment i2)
        {
            return i2.Date.CompareTo(i1.Date);
        }

        [Browsable(false)]
        public string Symbol {get;set;}
        public DateTime Date { get; set; }
        public Int64 Number { get; set; }
        public Decimal PricePurchase { get; set; }
        public Decimal PriceNow { get; set; }
        public Decimal EpsilonPurchase { get; set; }
        public Decimal EpsilonNow { get; set; }
        public string Status { get; set; }
    }

    public class Portfolio
    {
        public Portfolio()
        {
            Cash = 0;
            Assets = 0;
            Investments = new List<Investment>();
        }

        public Portfolio(Decimal cash, Decimal assets)
        {
            Cash = cash;
            Assets = assets;
            Investments = new List<Investment>();
        }

        public Portfolio(Decimal cash, Decimal assets, List<Investment> investments)
        {
            Cash = cash;
            Assets = assets;
            Investments = investments;
        }

        public Decimal Cash { get; set; }
        public Decimal Assets { get; set; }
        public List<Investment> Investments { get; set; }
    }
}