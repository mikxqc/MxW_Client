using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mxw_client
{    
    public partial class Form1 : Form
    {
        public static string version = "1.0.0";
        public static string build = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileBuildPart.ToString();
        public static string commit = ThisAssembly.Git.Commit;
        public static string branch = ThisAssembly.Git.Branch;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labMainVersion.Text = string.Format("MxW {0}.{1}-{2}", version, build, commit);
        }

        private void labFuncClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
