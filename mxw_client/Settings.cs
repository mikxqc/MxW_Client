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
            public string clientpath { get; set; }
            public string ftphost { get; set; }
            public string ftpuser { get; set; }
            public string ftppass { get; set; }
            public string ftppath { get; set; }
        }

        public Settings()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Settings_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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

            if (CheckFtpHost())
            {
                RootObject jrealm = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
                tbFtpHost.Text = jrealm.ftphost;
            }
            else
            {
                
            }

            if (CheckFtpUser())
            {
                RootObject jrealm = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
                tbFtpUser.Text = jrealm.ftpuser;
            }
            else
            {
                
            }

            if (CheckFtpPass())
            {
                RootObject jrealm = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
                tbFtpMdp.Text = jrealm.ftppass;
            }
            else
            {

            }

            if (CheckFtpPath())
            {
                RootObject jrealm = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
                tbFtpPath.Text = jrealm.ftppath;
            }
            else
            {

            }

            if (CheckClientPath())
            {
                RootObject jrealm = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
                tbClientPath.Text = jrealm.clientpath;
            }
            else
            {

            }

            RootObject j = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
            txtBoxServer.Text = j.server;
        }

        private bool CheckClientPath()
        {
            RootObject j = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
            if (j.clientpath == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckFtpPath()
        {
            RootObject j = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
            if (j.ftppath == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckFtpPass()
        {
            RootObject j = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
            if (j.ftppass == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckFtpUser()
        {
            RootObject j = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
            if (j.ftpuser == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckFtpHost()
        {
            RootObject j = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("settings.json"));
            if (j.ftphost == "")
            {
                return false;
            }
            else
            {
                return true;
            }
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
                server = txtBoxServer.Text,
                ftphost = tbFtpHost.Text,
                ftpuser = tbFtpUser.Text,
                ftppass = tbFtpMdp.Text,
                ftppath = tbFtpPath.Text
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

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    tbClientPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
