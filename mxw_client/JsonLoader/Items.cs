using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mxw_client.JsonLoader
{
    class Items
    {
        private static string url = @"https://mxw.mikx.ca/data/{0}/{1}/{2}.json";
        private static string region = Main.region;
        private static string realm = Main.realm;

        public class List
        {
            public string owner { get; set; }
            public int qty { get; set; }
            public int tg { get; set; }
            public int ts { get; set; }
            public int tc { get; set; }
            public int ug { get; set; }
            public int us { get; set; }
            public int uc { get; set; }
            public string time { get; set; }
        }

        public class RootObject
        {
            public int item { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public int qty { get; set; }
            public int avg { get; set; }
            public int mag { get; set; }
            public int mig { get; set; }
            public int avs { get; set; }
            public int mas { get; set; }
            public int mis { get; set; }
            public int avc { get; set; }
            public int mac { get; set; }
            public int mic { get; set; }
            public string gentime { get; set; }
            public List<List> list { get; set; }
        }

        public static string ItemName(int id)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.name;
        }

        public static string ItemIcon(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.icon;
        }

        public static int ItemCount(int id)
        {          
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.qty;
        }

        public static int ItemMG(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.mag;
        }

        public static int ItemMS(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.mas;
        }

        public static int ItemMC(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.mac;
        }

        public static int ItemMoG(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.avg;
        }

        public static int ItemMoS(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.avs;
        }

        public static int ItemMoC(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.avc;
        }

        public static int ItemMiG(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.mig;
        }

        public static int ItemMiS(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.mis;
        }

        public static int ItemMiC(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.mic;
        }

        public static string ItemGenTime(int id)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(string.Format(url, region, realm, id));
            var x = JsonConvert.DeserializeObject<RootObject>(str);

            return x.gentime;
        }
    }
}
