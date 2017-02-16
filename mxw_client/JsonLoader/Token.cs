using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mxw_client.JsonLoader
{
    class Token
    {
        public class Raw
        {
            public int buy { get; set; }
            public int __invalid_name__24min { get; set; }
            public int __invalid_name__24max { get; set; }
            public int timeToSell { get; set; }
            public object timeToSellSeconds { get; set; }
            public int result { get; set; }
            public int updated { get; set; }
            public string updatedISO8601 { get; set; }
        }

        public class Formatted
        {
            public string buy { get; set; }
            public string __invalid_name__24min { get; set; }
            public string __invalid_name__24max { get; set; }
            public double __invalid_name__24pct { get; set; }
            public string timeToSell { get; set; }
            public string result { get; set; }
            public string updated { get; set; }
            public string updatedhtml { get; set; }
            public string sparkurl { get; set; }
            public string region { get; set; }
        }

        public class NA
        {
            public int timestamp { get; set; }
            public Raw raw { get; set; }
            public Formatted formatted { get; set; }
        }

        public class Raw2
        {
            public int buy { get; set; }
            public int __invalid_name__24min { get; set; }
            public int __invalid_name__24max { get; set; }
            public int timeToSell { get; set; }
            public object timeToSellSeconds { get; set; }
            public int result { get; set; }
            public int updated { get; set; }
            public string updatedISO8601 { get; set; }
        }

        public class Formatted2
        {
            public string buy { get; set; }
            public string __invalid_name__24min { get; set; }
            public string __invalid_name__24max { get; set; }
            public double __invalid_name__24pct { get; set; }
            public string timeToSell { get; set; }
            public string result { get; set; }
            public string updated { get; set; }
            public string updatedhtml { get; set; }
            public string sparkurl { get; set; }
            public string region { get; set; }
        }

        public class EU
        {
            public int timestamp { get; set; }
            public Raw2 raw { get; set; }
            public Formatted2 formatted { get; set; }
        }

        public class Raw3
        {
            public int buy { get; set; }
            public int __invalid_name__24min { get; set; }
            public int __invalid_name__24max { get; set; }
            public int timeToSell { get; set; }
            public object timeToSellSeconds { get; set; }
            public int result { get; set; }
            public int updated { get; set; }
            public string updatedISO8601 { get; set; }
        }

        public class Formatted3
        {
            public string buy { get; set; }
            public string __invalid_name__24min { get; set; }
            public string __invalid_name__24max { get; set; }
            public double __invalid_name__24pct { get; set; }
            public string timeToSell { get; set; }
            public string result { get; set; }
            public string updated { get; set; }
            public string updatedhtml { get; set; }
            public string sparkurl { get; set; }
            public string region { get; set; }
        }

        public class CN
        {
            public int timestamp { get; set; }
            public Raw3 raw { get; set; }
            public Formatted3 formatted { get; set; }
        }

        public class Raw4
        {
            public int buy { get; set; }
            public int __invalid_name__24min { get; set; }
            public int __invalid_name__24max { get; set; }
            public int timeToSell { get; set; }
            public object timeToSellSeconds { get; set; }
            public int result { get; set; }
            public int updated { get; set; }
            public string updatedISO8601 { get; set; }
        }

        public class Formatted4
        {
            public string buy { get; set; }
            public string __invalid_name__24min { get; set; }
            public string __invalid_name__24max { get; set; }
            public double __invalid_name__24pct { get; set; }
            public string timeToSell { get; set; }
            public string result { get; set; }
            public string updated { get; set; }
            public string updatedhtml { get; set; }
            public string sparkurl { get; set; }
            public string region { get; set; }
        }

        public class TW
        {
            public int timestamp { get; set; }
            public Raw4 raw { get; set; }
            public Formatted4 formatted { get; set; }
        }

        public class Raw5
        {
            public int buy { get; set; }
            public int __invalid_name__24min { get; set; }
            public int __invalid_name__24max { get; set; }
            public int timeToSell { get; set; }
            public object timeToSellSeconds { get; set; }
            public int result { get; set; }
            public int updated { get; set; }
            public string updatedISO8601 { get; set; }
        }

        public class Formatted5
        {
            public string buy { get; set; }
            public string __invalid_name__24min { get; set; }
            public string __invalid_name__24max { get; set; }
            public int __invalid_name__24pct { get; set; }
            public string timeToSell { get; set; }
            public string result { get; set; }
            public string updated { get; set; }
            public string updatedhtml { get; set; }
            public string sparkurl { get; set; }
            public string region { get; set; }
        }

        public class KR
        {
            public int timestamp { get; set; }
            public Raw5 raw { get; set; }
            public Formatted5 formatted { get; set; }
        }

        public class RootObject
        {
            public NA NA { get; set; }
            public EU EU { get; set; }
            public CN CN { get; set; }
            public TW TW { get; set; }
            public KR KR { get; set; }
        }

        public static int TokenBuyout(string region)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            var str = wc.DownloadString("https://mxw.mikx.ca/data/token.json");
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            if (region == "us")
            {
                return x.NA.raw.buy;
            }

            if (region == "eu")
            {
                return x.EU.raw.buy;
            }

            return 0;

        }
    }
}
