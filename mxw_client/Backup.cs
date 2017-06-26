using FluentFTP;
using Newtonsoft.Json;
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

namespace mxw_client
{
    public partial class Backup : Form
    {
        public class BackupJson
        {
            public string date { get; set; }
            public string time { get; set; }
        }

        public Backup()
        {
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {         
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            dataGridView1.Rows.Clear();
            Color lb1bc = ColorTranslator.FromHtml("#1c1c1c");
            dataGridView1.BackgroundColor = lb1bc;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            //Find<HScrollBar>(dataGridView1).BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = lb1bc;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.Columns["coDate"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["coDate"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["coDate"].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns["coHour"].DefaultCellStyle.BackColor = lb1bc;
            dataGridView1.Columns["coHour"].DefaultCellStyle.SelectionBackColor = lb1bc;
            dataGridView1.Columns["coHour"].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns["coDate"].Width = 90;
            dataGridView1.Columns["coHour"].Width = 50;
            GetListAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public async void GetListAsync()
        {
            FtpClient ftp = new FtpClient(Main.ftphost);
            ftp.Credentials = new System.Net.NetworkCredential(Main.ftpuser, Main.ftppass);
            ftp.Connect();

            FtpListItem[] fli = await ftp.GetListingAsync(Main.ftppath);      

            foreach (FtpListItem item in fli)
            {
                if (!Directory.Exists(@"backup\"))
                {
                    Directory.CreateDirectory(@"backup\");
                }
                string fx = item.Name.Substring(item.Name.LastIndexOf('.') + 1); ;
                if (fx == "mxw")
                {
                    string bjson = item.Name.Substring(0, item.Name.LastIndexOf(".") + 1);
                    ftp.DownloadFile(@"backup\" + item.Name.Substring(0, item.Name.LastIndexOf(".") + 1) + "json", "backup/" + bjson + "json");
                    BackupJson j = JsonConvert.DeserializeObject<BackupJson>(File.ReadAllText(@"backup\" + bjson + "json"));
                    dataGridView1.Rows.Add(new object[] { j.date, j.time, item.Name });
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Add(btn);
                    btn.Text = "Restaurer";
                    btn.UseColumnTextForButtonValue = true;
                }
            }
            ftp.Disconnect();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            FtpClient ftp = new FtpClient(Main.ftphost);
            ftp.Credentials = new System.Net.NetworkCredential(Main.ftpuser, Main.ftppass);
            ftp.Connect();
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                IO.CreateSample(Main.clientpath+@"\wtf_last.zip","", Main.clientpath + @"\WTF");
                IO.ClearDir(Main.clientpath + @"\WTF");
                string archive = dataGridView1[2, e.RowIndex].Value.ToString();
                ftp.DownloadFile(@"tmp\"+archive,@"backup/"+ archive,true);
                IO.ExtractBackup(archive,"",Main.clientpath+@"\WTF");
                ftp.Disconnect();
            }
        }
    }
}
