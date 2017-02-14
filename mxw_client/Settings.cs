using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace mxw_client
{
    public partial class Settings : Form
    {
        public class RootObject
        {
            public bool first { get; set; }
            public string region { get; set; }
            public string realm { get; set; }
            public string server { get; set; }
        }

        public Settings()
        {
            InitializeComponent();
        }

        private void labFuncClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            var str = wc.DownloadString(@"https://mxw.mikx.ca/data/realms.json");
            var x = JsonConvert.DeserializeObject<List<RootObject>>(str);

            foreach (var r in x)
            {
                comboBoxRealm.Items.Add(r.realm);
            }

            if (CheckRegion())
            {
                RootObject jregion = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
                comboBoxRegion.Text = jregion.region;
            } else
            {
                comboBoxRegion.Text = "Choisir une région...";
            }

            if (CheckRealm())
            {
                RootObject jrealm = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
                comboBoxRealm.Text = jrealm.realm;
            }
            else
            {
                comboBoxRealm.Text = "Choisir un royaume...";
            }

            RootObject j = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
            txtBoxServer.Text = j.server;
        }

        private bool CheckRegion()
        {
            RootObject j = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
            if (j.region == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckRealm()
        {
            RootObject j = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
            if (j.realm == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RootObject sjson = new RootObject()
            {
                first = false,
                region = comboBoxRegion.SelectedItem.ToString(),
                realm = comboBoxRealm.SelectedItem.ToString(),
                server = txtBoxServer.Text
            };

            File.Delete("settings.json");
            using (FileStream fs = File.Open("settings.json", FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, sjson);
            }
        }
    }
}
