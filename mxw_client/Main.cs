using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        public static string version = "1.0.0";
        public static string build = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileBuildPart.ToString();
        public static string commit = ThisAssembly.Git.Commit;
        public static string branch = ThisAssembly.Git.Branch;

        public static string realm = "";

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Init base label
            labMainVersion.Text = string.Format("MxW {0}.{1}", version, build);

            //Init base ui color
            //Item id search box color
            Color tbIDSearch = ColorTranslator.FromHtml("#2a2929");
            textBoxIDSearch.BackColor = tbIDSearch;

            //Read settings.json
            //Check if there was a last selected realm


            //Init realm list
            LoadRealmList();
        }

        private void labFuncClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRealm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public class RootObject
        {
            public string region { get; set; }
            public string realm { get; set; }
        }

        public void LoadRealmList()
        {
            List<string> rlist = new List<string>();

            WebClient wc = new WebClient();
            var str = wc.DownloadString(@"https://mxw.mikx.ca/data/realms.json");
            var x = JsonConvert.DeserializeObject<List<RootObject>>(str);

            foreach (var r in x)
            {
                comboBoxRealm.Items.Add(string.Format("{0}-{1}",r.region,r.realm));
                realm = r.realm;
            }
        }

        private void textBoxIDSearch_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxIDSearch.Text != "")
                {
                    int id = Convert.ToInt32(textBoxIDSearch.Text);
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
                }
            }
        }
    }
}
