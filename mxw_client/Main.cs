using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mxw_client
{
    public partial class Main : Form
    {
        public static string version = "1.0.1";
        public static string build = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileBuildPart.ToString();
        public static string commit = ThisAssembly.Git.Commit;
        public static string branch = ThisAssembly.Git.Branch;

        public static string region = "";
        public static string realm = "";

        public class SettingsJson
        {
            public bool first { get; set; }
            public string region { get; set; }
            public string realm { get; set; }
            public string server { get; set; }
        }

        public class Updater
        {
            public string version { get; set; }
        }

        public Main()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            var str = wc.DownloadString("https://mxw.mikx.ca/data/updater.json");
            var u = JsonConvert.DeserializeObject<Updater>(str);
            if (u.version != version)
            {
                System.Windows.Forms.Application.Exit();
                if (File.Exists("MxW_Updater.exe")) { File.Delete("MxW_Updater.exe"); }
                wc.DownloadFile("https://mxw.mikx.ca/release/MxW_Updater.exe", "MxW_Updater.exe");
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = @"MxW_Updater.exe";
                pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                pProcess.StartInfo.CreateNoWindow = true;
                pProcess.Start();
            }

            this.BackgroundImage = Properties.Resources.Main_Default;
            if (!File.Exists("settings.json"))
            {
                wc.DownloadFile("https://mxw.mikx.ca/data/settings_client.json", "settings.json");
            }

            if (File.Exists("settings.json"))
            {
                SettingsJson j = JsonConvert.DeserializeObject<SettingsJson>(File.ReadAllText("settings.json"));
                if (j.first)
                {
                    Settings settingsfrm = new Settings();
                    settingsfrm.Show();
                }
                else
                {
                    region = j.region;
                    realm = j.realm;
                }
            }           
            
            //Init base label
            labMainVersion.Text = string.Format("MxW {0}.{1}({2})", version, build, commit);

            //Init base ui color
            //Item id search box color
            Color tbIDSearch = ColorTranslator.FromHtml("#2a2929");
            textBoxIDSearch.BackColor = tbIDSearch;

            //Read settings.json
            //Check if there was a last selected realm
        }

        private void labFuncClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRealm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set selected region/realm
        }

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
            public string region { get; set; }
            public string realm { get; set; }

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
            public List<List> list { get; set; }
        }

        private void textBoxIDSearch_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxIDSearch.Text != "")
                {
                    int id = Convert.ToInt32(textBoxIDSearch.Text);
                    System.Net.HttpWebRequest request = null;
                    System.Net.HttpWebResponse response = null;
                    request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(string.Format("https://mxw.mikx.ca/data/{0}/{1}/{2}.json", region, realm, id));
                    request.Timeout = 30000;
                    int flag;
                    try
                    {
                        response = (System.Net.HttpWebResponse)request.GetResponse();
                        flag = 1;
                    }
                    catch
                    {
                        flag = -1;
                    }

                    if (flag == 1)
                    {
                        labNotFound.Visible = false;
                        this.BackgroundImage = Properties.Resources.Main_ItemLoaded1;                     
                        ///////////////////////////////
                        //Get item info from web json
                        int iqty = JsonLoader.Items.ItemCount(id);
                        int img = JsonLoader.Items.ItemMG(id);
                        int ims = JsonLoader.Items.ItemMS(id);
                        int imc = JsonLoader.Items.ItemMC(id);

                        int imog = JsonLoader.Items.ItemMoG(id);
                        int imos = JsonLoader.Items.ItemMoS(id);
                        int imoc = JsonLoader.Items.ItemMoC(id);

                        int imig = JsonLoader.Items.ItemMiG(id);
                        int imis = JsonLoader.Items.ItemMiS(id);
                        int imic = JsonLoader.Items.ItemMiC(id);

                        ///////////////////////////////
                        //Icon & Function Visibility
                        pictureBox1.Visible = true;
                        labInfoName.Visible = true;
                        labInfoQty.Visible = true;
                        labInfoTotal.Visible = true;
                        labInfoMax.Visible = true;
                        labInfoMoy.Visible = true;
                        labInfoMin.Visible = true;
                        labInfoMaxG.Visible = true;
                        labInfoMaxS.Visible = true;
                        labInfoMaxC.Visible = true;
                        labInfoMoyG.Visible = true;
                        labInfoMoyS.Visible = true;
                        labInfoMoyC.Visible = true;
                        labInfoMinG.Visible = true;
                        labInfoMinG.Visible = true;
                        labInfoMinS.Visible = true;
                        labInfoMinC.Visible = true;
                        labInfoQtyV.Visible = true;
                        //labInfoTotalV.Visible = true;
                        labItemWoWHead.Visible = true;
                        labItemTUJ.Visible = true;

                        labInfoName.Text = JsonLoader.Items.ItemName(id);
                        pictureBox1.ImageLocation = String.Format(@"https://git.mikx.ca/mikx/wow-interface/raw/master/art/icons-png/{0}.png", JsonLoader.Items.ItemIcon(id));

                        labInfoQtyV.Text = iqty.ToString();
                        labInfoMaxG.Text = img.ToString();
                        labInfoMaxS.Text = ims.ToString();
                        labInfoMaxC.Text = imc.ToString();

                        labInfoMoyG.Text = imog.ToString();
                        labInfoMoyS.Text = imos.ToString();
                        labInfoMoyC.Text = imoc.ToString();

                        labInfoMinG.Text = imig.ToString();
                        labInfoMinS.Text = imis.ToString();
                        labInfoMinC.Text = imic.ToString();

                        FillList(id);
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                        pictureBox1.Visible = false;
                        labInfoName.Visible = false;
                        labInfoQty.Visible = false;
                        labInfoTotal.Visible = false;
                        labInfoMax.Visible = false;
                        labInfoMoy.Visible = false;
                        labInfoMin.Visible = false;
                        labInfoMaxG.Visible = false;
                        labInfoMaxS.Visible = false;
                        labInfoMaxC.Visible = false;
                        labInfoMoyG.Visible = false;
                        labInfoMoyS.Visible = false;
                        labInfoMoyC.Visible = false;
                        labInfoMinG.Visible = false;
                        labInfoMinG.Visible = false;
                        labInfoMinS.Visible = false;
                        labInfoMinC.Visible = false;
                        labInfoQtyV.Visible = false;
                        labInfoTotalV.Visible = false;
                        labItemWoWHead.Visible = false;
                        labItemTUJ.Visible = false;
                        this.BackgroundImage = Properties.Resources.Main_Default;
                        labNotFound.Visible = true;
                    }                 
                }
            }
        }

        private void FillList(int id)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            dataGridView1.Columns["QTY"].SortMode = DataGridViewColumnSortMode.Automatic;
            int cw = 9;
            dataGridView1.Visible = true;         
            dataGridView1.Rows.Clear();
            Color lb1bc = ColorTranslator.FromHtml("#1c1c1c");
            dataGridView1.BackgroundColor = lb1bc;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            //Find<HScrollBar>(dataGridView1).BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = lb1bc;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.Columns["QTY"].Width = 40;
            dataGridView1.Columns["QTY"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["QTY"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["QTY"].DefaultCellStyle.ForeColor = Color.White;

            dataGridView1.Columns["X"].Width = 45;
            dataGridView1.Columns["X"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["X"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["X"].DefaultCellStyle.ForeColor = Color.Aqua;

            dataGridView1.Columns["EQUAL"].Width = 45;
            dataGridView1.Columns["EQUAL"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["EQUAL"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["EQUAL"].DefaultCellStyle.ForeColor = Color.Aqua;

            dataGridView1.Columns["UGOLD"].Width = 92;

            dataGridView1.Columns["UGOLD"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["UGOLD"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["UGOLD"].DefaultCellStyle.ForeColor = Color.Gold;

            dataGridView1.Columns["USILVER"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["USILVER"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["USILVER"].DefaultCellStyle.ForeColor = Color.Silver;
            dataGridView1.Columns["USILVER"].Width = 30;

            dataGridView1.Columns["UCOPPER"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["UCOPPER"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["UCOPPER"].DefaultCellStyle.ForeColor = Color.Peru;
            dataGridView1.Columns["UCOPPER"].Width = 30;

            dataGridView1.Columns["AGOLD"].Width = 92;

            dataGridView1.Columns["AGOLD"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["AGOLD"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["AGOLD"].DefaultCellStyle.ForeColor = Color.Gold;

            dataGridView1.Columns["ASILVER"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["ASILVER"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["ASILVER"].DefaultCellStyle.ForeColor = Color.Silver;
            dataGridView1.Columns["ASILVER"].Width = 30;

            dataGridView1.Columns["ACOPPER"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["ACOPPER"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["ACOPPER"].DefaultCellStyle.ForeColor = Color.Peru;
            dataGridView1.Columns["ACOPPER"].Width = 30;

            dataGridView1.Columns["OWNER"].Width = 110;
            dataGridView1.Columns["OWNER"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["OWNER"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["OWNER"].DefaultCellStyle.ForeColor = Color.Aqua;

            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            var str = wc.DownloadString(string.Format(@"https://mxw.mikx.ca/data/{0}/{1}/{2}.json",region, realm, id));
            var j = JsonConvert.DeserializeObject<RootObject>(str);

            foreach (var l in j.list)
            {
                dataGridView1.Rows.Add(new object[] { l.qty, "x", l.ug, l.us, l.uc, "=", l.tg, l.ts, l.tc, l.owner });
            }
        }

        private void labFuncSettings_Click(object sender, EventArgs e)
        {
            Settings settingsfrm = new Settings();
            settingsfrm.Show();
        }

        private void labItemWoWHead_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(string.Format("http://fr.wowhead.com/item={0}", textBoxIDSearch.Text));
        }

        private void labItemTUJ_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(string.Format("https://theunderminejournal.com/#{0}/{1}/item/{2}", region, realm, textBoxIDSearch.Text));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(string.Format("https://theunderminejournal.com/#{0}/{1}/item/{2}", region, realm, textBoxIDSearch.Text));
        }
    }
}
