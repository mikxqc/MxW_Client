using FluentFTP;
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
using System.Xml;

namespace mxw_client
{
    public partial class Main : Form
    {
        public static string version = "1.2.0b";
        public static string commit = ThisAssembly.Git.Commit;
        public static string branch = ThisAssembly.Git.Branch;

        public static string region = "";
        public static string realm = "";
        public static string clientpath = "";
        public static string ftphost = "";
        public static string ftpuser = "";
        public static string ftppass = "";
        public static string ftppath = "";


        public static bool debug = true;

        public class SettingsJson
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

        public class BackupJson
        {
            public string date { get; set; }
            public string time { get; set; }
            public string archive { get; set; }
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

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnOpen(object sender, EventArgs e)
        {
            this.Show();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            ClientUpdate(true);         
        }

        private void ClientUpdate(bool notify)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            var str = wc.DownloadString("https://mxw.mikx.ca/data/updater.json");
            var u = JsonConvert.DeserializeObject<Updater>(str);
            if (u.version != version && !debug)
            {
                Application.Exit();
                if (File.Exists("MxW_Updater.exe")) { File.Delete("MxW_Updater.exe"); }
                wc.DownloadFile("https://mxw.mikx.ca/release/MxW_Updater.exe", "MxW_Updater.exe");
                Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = @"MxW_Updater.exe";
                pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                pProcess.StartInfo.CreateNoWindow = true;
                pProcess.Start();
            }
            else
            {
                if (notify)
                {
                    MessageBox.Show("Vous utilisez la version la plus récente de MxW.");
                }              
            }
        }

        private void mDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (clientpath != "")
            {
                timerBackup.Enabled = true;
            }

            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Ouvrir", OnOpen);
            trayMenu.MenuItems.Add("Mise à jour", OnUpdate);
            trayMenu.MenuItems.Add("Fermer", OnExit);

            notifyIcon1.Text = "MxW "+Main.version+"("+ Main.commit + ")";
            notifyIcon1.Icon = Properties.Resources.favicon;

            notifyIcon1.ContextMenu = trayMenu;
            notifyIcon1.Visible = true;

            ClientUpdate(false);

            this.BackgroundImage = Properties.Resources.Main_Default;
            if (!File.Exists("settings.json"))
            {
                WebClient wc = new WebClient();
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
                    clientpath = j.clientpath;
                    ftppath = j.ftppath;
                    ftphost = j.ftphost;
                    ftpuser = j.ftpuser;
                    ftppass = j.ftppass;
                }
            }           
            
            //Init base label
            labMainVersion.Text = string.Format("MxW {0}({1}/{2})", version, commit, branch);

            //Init base ui color
            //Item id search box color
            Color tbIDSearch = ColorTranslator.FromHtml("#2a2929");
            textBoxIDSearch.BackColor = tbIDSearch;

            //Read settings.json
            //Check if there was a last selected realm

            //Load token price
            labTokenValue.Text = JsonLoader.Token.TokenBuyout(region).ToString();
        }

        private void labFuncClose_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            public string gentime { get; set; }
            public List<List> list { get; set; }
        }

        private void textBoxIDSearch_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxIDSearch.Text != "")
                {
                    int id = Convert.ToInt32(textBoxIDSearch.Text);                    
                    HttpWebRequest request = null;
                    HttpWebResponse response = null;
                    request = (HttpWebRequest)HttpWebRequest.Create(string.Format("https://mxw.mikx.ca/data/{0}/{1}/{2}.json", region, realm, id));
                    request.Timeout = 5000;
                    int flag;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                        flag = 1;
                    }
                    catch
                    {
                        flag = -1;
                    }

                    if (flag == 1)
                    {
                        labNotFound.Visible = false;
                        this.BackgroundImage = Properties.Resources.Main_ItemLoaded;                     
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
                        labInfoTotalV.Visible = true;
                        labItemWoWHead.Visible = true;
                        labItemTUJ.Visible = true;

                        // Name lenght fix
                        string fn = "";
                        int maxnl = 35;
                        string fnr = JsonLoader.Items.ItemName(id);
                        int nl = fnr.Length;
                        if (nl > maxnl)
                        {
                            fn = string.Format("{0}...", fnr.Substring(0, maxnl));
                        } else
                        {
                            fn = fnr;
                        }

                        labInfoName.Text = fn;
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

                        labInfoTotalV.Text = JsonLoader.Items.ItemGenTime(id);

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
                    request.Abort();
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

        private void label1_Click(object sender, EventArgs e)
        {
            Backup back = new Backup();
            back.Show();
        }

        private void timerBackup_Tick(object sender, EventArgs e)
        {
            FtpClient ftp = new FtpClient(Main.ftphost);
            ftp.Credentials = new System.Net.NetworkCredential(Main.ftpuser, Main.ftppass);
            ftp.Connect();

            string user = ftpuser.Substring(ftpuser.LastIndexOf('_') + 1);          
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            IO.ClearDir("tmp");
            IO.CreateSample(@"tmp\"+string.Format("{0}_wtf_{1}.{2}.{3}.{4}.{5}.mxw",user,month,day,year,hour,minute), "", Main.clientpath + @"\WTF");

            ftp.UploadFile(@"tmp\" + string.Format("{0}_wtf_{1}.{2}.{3}.{4}.{5}.mxw", user, month, day, year, hour, minute),@"backup/"+ string.Format("{0}_wtf_{1}.{2}.{3}.{4}.{5}.mxw", user, month, day, year, hour, minute));

            string fm = "";
            string pe = "";
            switch (DateTime.Now.Month)
            {
                case 1:
                    fm = "Janvier";
                    break;
                case 2:
                    fm = "Février";
                    break;
                case 3:
                    fm = "Mars";
                    break;
                case 4:
                    fm = "Avril";
                    break;
                case 5:
                    fm = "Mai";
                    break;
                case 6:
                    fm = "Juin";
                    break;
                case 7:
                    fm = "Juillet";
                    break;
                case 8:
                    fm = "Août";
                    break;
                case 9:
                    fm = "Septembre";
                    break;
                case 10:
                    fm = "Octobre";
                    break;
                case 11:
                    fm = "Novembre";
                    break;
                case 12:
                    fm = "Décembre";
                    break;
            }

            switch (DateTime.Now.Hour)
            {
                case 1:
                    pe = "am";
                    break;
                case 2:
                    pe = "am";
                    break;
                case 3:
                    pe = "am";
                    break;
                case 4:
                    pe = "am";
                    break;
                case 5:
                    pe = "am";
                    break;
                case 6:
                    pe = "am";
                    break;
                case 7:
                    pe = "am";
                    break;
                case 8:
                    pe = "am";
                    break;
                case 9:
                    pe = "am";
                    break;
                case 10:
                    pe = "am";
                    break;
                case 11:
                    pe = "am";
                    break;
                case 12:
                    pe = "pm";
                    break;
                case 13:
                    pe = "pm";
                    break;
                case 14:
                    pe = "pm";
                    break;
                case 15:
                    pe = "pm";
                    break;
                case 16:
                    pe = "pm";
                    break;
                case 17:
                    pe = "pm";
                    break;
                case 18:
                    pe = "pm";
                    break;
                case 19:
                    pe = "pm";
                    break;
                case 20:
                    pe = "pm";
                    break;
                case 21:
                    pe = "pm";
                    break;
                case 22:
                    pe = "pm";
                    break;
                case 23:
                    pe = "pm";
                    break;
                case 24:
                    pe = "am";
                    break;

            }

            BackupJson bjson = new BackupJson()
            {
                date = string.Format("{0} {1} {2}",day,fm,year),
                time = string.Format("{0}:{1}{2}", hour, Handler.Int.ZeroPad(DateTime.Now.Minute), pe),
                archive = string.Format("{0}_wtf_{1}.{2}.{3}.{4}.{5}.mxw", user, month, day, year, hour, minute)
            };

            using (FileStream fs = File.Open(@"tmp\" + string.Format("{0}_wtf_{1}.{2}.{3}.{4}.{5}.json", user, month, day, year, hour, minute), FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, bjson);
            }

            ftp.UploadFile(@"tmp\" + string.Format("{0}_wtf_{1}.{2}.{3}.{4}.{5}.json", user, month, day, year, hour, minute), @"backup/" + string.Format("{0}_wtf_{1}.{2}.{3}.{4}.{5}.json", user, month, day, year, hour, minute));
        }
    }
}
