﻿namespace mxw_client
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labMainVersion = new System.Windows.Forms.Label();
            this.labFuncClose = new System.Windows.Forms.Label();
            this.labCredits = new System.Windows.Forms.Label();
            this.labFuncSettings = new System.Windows.Forms.Label();
            this.comboBoxRealm = new System.Windows.Forms.ComboBox();
            this.labToken = new System.Windows.Forms.Label();
            this.textBoxIDSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labInfoTotalV = new System.Windows.Forms.Label();
            this.labInfoTotal = new System.Windows.Forms.Label();
            this.labInfoMinC = new System.Windows.Forms.Label();
            this.labInfoMoyC = new System.Windows.Forms.Label();
            this.labInfoMaxC = new System.Windows.Forms.Label();
            this.labInfoMinS = new System.Windows.Forms.Label();
            this.labInfoMoyS = new System.Windows.Forms.Label();
            this.labInfoMaxS = new System.Windows.Forms.Label();
            this.labInfoQtyV = new System.Windows.Forms.Label();
            this.labInfoQty = new System.Windows.Forms.Label();
            this.labInfoMinG = new System.Windows.Forms.Label();
            this.labInfoMin = new System.Windows.Forms.Label();
            this.labInfoMoyG = new System.Windows.Forms.Label();
            this.labInfoMoy = new System.Windows.Forms.Label();
            this.labInfoMaxG = new System.Windows.Forms.Label();
            this.labInfoMax = new System.Windows.Forms.Label();
            this.labInfoName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labMainVersion
            // 
            this.labMainVersion.AutoSize = true;
            this.labMainVersion.BackColor = System.Drawing.Color.Transparent;
            this.labMainVersion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMainVersion.ForeColor = System.Drawing.Color.Silver;
            this.labMainVersion.Location = new System.Drawing.Point(8, 480);
            this.labMainVersion.Name = "labMainVersion";
            this.labMainVersion.Size = new System.Drawing.Size(69, 13);
            this.labMainVersion.TabIndex = 0;
            this.labMainVersion.Text = "#VERSION";
            // 
            // labFuncClose
            // 
            this.labFuncClose.AutoSize = true;
            this.labFuncClose.BackColor = System.Drawing.Color.Transparent;
            this.labFuncClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFuncClose.ForeColor = System.Drawing.Color.White;
            this.labFuncClose.Location = new System.Drawing.Point(825, 11);
            this.labFuncClose.Name = "labFuncClose";
            this.labFuncClose.Size = new System.Drawing.Size(15, 13);
            this.labFuncClose.TabIndex = 1;
            this.labFuncClose.Text = "X";
            this.labFuncClose.Click += new System.EventHandler(this.labFuncClose_Click);
            // 
            // labCredits
            // 
            this.labCredits.AutoSize = true;
            this.labCredits.BackColor = System.Drawing.Color.Transparent;
            this.labCredits.Font = new System.Drawing.Font("Verdana", 7F);
            this.labCredits.ForeColor = System.Drawing.Color.Silver;
            this.labCredits.Location = new System.Drawing.Point(694, 480);
            this.labCredits.Name = "labCredits";
            this.labCredits.Size = new System.Drawing.Size(150, 12);
            this.labCredits.TabIndex = 2;
            this.labCredits.Text = "PAR MIKX | MXW.MIKX.CA";
            // 
            // labFuncSettings
            // 
            this.labFuncSettings.AutoSize = true;
            this.labFuncSettings.BackColor = System.Drawing.Color.Transparent;
            this.labFuncSettings.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFuncSettings.ForeColor = System.Drawing.Color.White;
            this.labFuncSettings.Location = new System.Drawing.Point(798, 11);
            this.labFuncSettings.Name = "labFuncSettings";
            this.labFuncSettings.Size = new System.Drawing.Size(15, 13);
            this.labFuncSettings.TabIndex = 3;
            this.labFuncSettings.Text = "S";
            // 
            // comboBoxRealm
            // 
            this.comboBoxRealm.BackColor = System.Drawing.Color.Silver;
            this.comboBoxRealm.FormattingEnabled = true;
            this.comboBoxRealm.Location = new System.Drawing.Point(666, 7);
            this.comboBoxRealm.Name = "comboBoxRealm";
            this.comboBoxRealm.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRealm.TabIndex = 4;
            this.comboBoxRealm.SelectedIndexChanged += new System.EventHandler(this.comboBoxRealm_SelectedIndexChanged);
            // 
            // labToken
            // 
            this.labToken.AutoSize = true;
            this.labToken.BackColor = System.Drawing.Color.Transparent;
            this.labToken.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labToken.ForeColor = System.Drawing.Color.Silver;
            this.labToken.Location = new System.Drawing.Point(296, 43);
            this.labToken.Name = "labToken";
            this.labToken.Size = new System.Drawing.Size(37, 12);
            this.labToken.TabIndex = 5;
            this.labToken.Text = "JETON";
            // 
            // textBoxIDSearch
            // 
            this.textBoxIDSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIDSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIDSearch.ForeColor = System.Drawing.Color.White;
            this.textBoxIDSearch.Location = new System.Drawing.Point(18, 85);
            this.textBoxIDSearch.Name = "textBoxIDSearch";
            this.textBoxIDSearch.Size = new System.Drawing.Size(257, 15);
            this.textBoxIDSearch.TabIndex = 6;
            this.textBoxIDSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxIDSearch_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(412, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "ENCHÈRE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(481, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "ADDONS";
            // 
            // labInfoTotalV
            // 
            this.labInfoTotalV.AutoSize = true;
            this.labInfoTotalV.BackColor = System.Drawing.Color.Transparent;
            this.labInfoTotalV.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoTotalV.ForeColor = System.Drawing.Color.White;
            this.labInfoTotalV.Location = new System.Drawing.Point(178, 234);
            this.labInfoTotalV.Name = "labInfoTotalV";
            this.labInfoTotalV.Size = new System.Drawing.Size(42, 16);
            this.labInfoTotalV.TabIndex = 51;
            this.labInfoTotalV.Text = "Total";
            this.labInfoTotalV.Visible = false;
            // 
            // labInfoTotal
            // 
            this.labInfoTotal.AutoSize = true;
            this.labInfoTotal.BackColor = System.Drawing.Color.Transparent;
            this.labInfoTotal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labInfoTotal.Location = new System.Drawing.Point(39, 234);
            this.labInfoTotal.Name = "labInfoTotal";
            this.labInfoTotal.Size = new System.Drawing.Size(44, 16);
            this.labInfoTotal.TabIndex = 50;
            this.labInfoTotal.Text = "Total";
            this.labInfoTotal.Visible = false;
            // 
            // labInfoMinC
            // 
            this.labInfoMinC.AutoSize = true;
            this.labInfoMinC.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMinC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMinC.ForeColor = System.Drawing.Color.Peru;
            this.labInfoMinC.Location = new System.Drawing.Point(39, 426);
            this.labInfoMinC.Name = "labInfoMinC";
            this.labInfoMinC.Size = new System.Drawing.Size(17, 16);
            this.labInfoMinC.TabIndex = 49;
            this.labInfoMinC.Text = "0";
            this.labInfoMinC.Visible = false;
            // 
            // labInfoMoyC
            // 
            this.labInfoMoyC.AutoSize = true;
            this.labInfoMoyC.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMoyC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMoyC.ForeColor = System.Drawing.Color.Peru;
            this.labInfoMoyC.Location = new System.Drawing.Point(39, 362);
            this.labInfoMoyC.Name = "labInfoMoyC";
            this.labInfoMoyC.Size = new System.Drawing.Size(17, 16);
            this.labInfoMoyC.TabIndex = 48;
            this.labInfoMoyC.Text = "0";
            this.labInfoMoyC.Visible = false;
            // 
            // labInfoMaxC
            // 
            this.labInfoMaxC.AutoSize = true;
            this.labInfoMaxC.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMaxC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMaxC.ForeColor = System.Drawing.Color.Peru;
            this.labInfoMaxC.Location = new System.Drawing.Point(39, 298);
            this.labInfoMaxC.Name = "labInfoMaxC";
            this.labInfoMaxC.Size = new System.Drawing.Size(17, 16);
            this.labInfoMaxC.TabIndex = 47;
            this.labInfoMaxC.Text = "0";
            this.labInfoMaxC.Visible = false;
            // 
            // labInfoMinS
            // 
            this.labInfoMinS.AutoSize = true;
            this.labInfoMinS.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMinS.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMinS.ForeColor = System.Drawing.Color.Silver;
            this.labInfoMinS.Location = new System.Drawing.Point(39, 410);
            this.labInfoMinS.Name = "labInfoMinS";
            this.labInfoMinS.Size = new System.Drawing.Size(17, 16);
            this.labInfoMinS.TabIndex = 46;
            this.labInfoMinS.Text = "0";
            this.labInfoMinS.Visible = false;
            // 
            // labInfoMoyS
            // 
            this.labInfoMoyS.AutoSize = true;
            this.labInfoMoyS.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMoyS.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMoyS.ForeColor = System.Drawing.Color.Silver;
            this.labInfoMoyS.Location = new System.Drawing.Point(39, 346);
            this.labInfoMoyS.Name = "labInfoMoyS";
            this.labInfoMoyS.Size = new System.Drawing.Size(17, 16);
            this.labInfoMoyS.TabIndex = 45;
            this.labInfoMoyS.Text = "0";
            this.labInfoMoyS.Visible = false;
            // 
            // labInfoMaxS
            // 
            this.labInfoMaxS.AutoSize = true;
            this.labInfoMaxS.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMaxS.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMaxS.ForeColor = System.Drawing.Color.Silver;
            this.labInfoMaxS.Location = new System.Drawing.Point(39, 282);
            this.labInfoMaxS.Name = "labInfoMaxS";
            this.labInfoMaxS.Size = new System.Drawing.Size(17, 16);
            this.labInfoMaxS.TabIndex = 44;
            this.labInfoMaxS.Text = "0";
            this.labInfoMaxS.Visible = false;
            // 
            // labInfoQtyV
            // 
            this.labInfoQtyV.AutoSize = true;
            this.labInfoQtyV.BackColor = System.Drawing.Color.Transparent;
            this.labInfoQtyV.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoQtyV.ForeColor = System.Drawing.Color.White;
            this.labInfoQtyV.Location = new System.Drawing.Point(178, 218);
            this.labInfoQtyV.Name = "labInfoQtyV";
            this.labInfoQtyV.Size = new System.Drawing.Size(37, 16);
            this.labInfoQtyV.TabIndex = 43;
            this.labInfoQtyV.Text = "Qté.";
            this.labInfoQtyV.Visible = false;
            // 
            // labInfoQty
            // 
            this.labInfoQty.AutoSize = true;
            this.labInfoQty.BackColor = System.Drawing.Color.Transparent;
            this.labInfoQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labInfoQty.Location = new System.Drawing.Point(39, 218);
            this.labInfoQty.Name = "labInfoQty";
            this.labInfoQty.Size = new System.Drawing.Size(89, 16);
            this.labInfoQty.TabIndex = 42;
            this.labInfoQty.Text = "Enchère(s)";
            this.labInfoQty.Visible = false;
            // 
            // labInfoMinG
            // 
            this.labInfoMinG.AutoSize = true;
            this.labInfoMinG.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMinG.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMinG.ForeColor = System.Drawing.Color.Gold;
            this.labInfoMinG.Location = new System.Drawing.Point(39, 394);
            this.labInfoMinG.Name = "labInfoMinG";
            this.labInfoMinG.Size = new System.Drawing.Size(26, 16);
            this.labInfoMinG.TabIndex = 41;
            this.labInfoMinG.Text = "10";
            this.labInfoMinG.Visible = false;
            // 
            // labInfoMin
            // 
            this.labInfoMin.AutoSize = true;
            this.labInfoMin.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labInfoMin.Location = new System.Drawing.Point(39, 378);
            this.labInfoMin.Name = "labInfoMin";
            this.labInfoMin.Size = new System.Drawing.Size(89, 16);
            this.labInfoMin.TabIndex = 40;
            this.labInfoMin.Text = "Valeur Min.";
            this.labInfoMin.Visible = false;
            // 
            // labInfoMoyG
            // 
            this.labInfoMoyG.AutoSize = true;
            this.labInfoMoyG.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMoyG.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMoyG.ForeColor = System.Drawing.Color.Gold;
            this.labInfoMoyG.Location = new System.Drawing.Point(39, 330);
            this.labInfoMoyG.Name = "labInfoMoyG";
            this.labInfoMoyG.Size = new System.Drawing.Size(26, 16);
            this.labInfoMoyG.TabIndex = 39;
            this.labInfoMoyG.Text = "10";
            this.labInfoMoyG.Visible = false;
            // 
            // labInfoMoy
            // 
            this.labInfoMoy.AutoSize = true;
            this.labInfoMoy.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMoy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labInfoMoy.Location = new System.Drawing.Point(39, 314);
            this.labInfoMoy.Name = "labInfoMoy";
            this.labInfoMoy.Size = new System.Drawing.Size(55, 16);
            this.labInfoMoy.TabIndex = 38;
            this.labInfoMoy.Text = "Valeur";
            this.labInfoMoy.Visible = false;
            // 
            // labInfoMaxG
            // 
            this.labInfoMaxG.AutoSize = true;
            this.labInfoMaxG.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMaxG.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMaxG.ForeColor = System.Drawing.Color.Gold;
            this.labInfoMaxG.Location = new System.Drawing.Point(39, 266);
            this.labInfoMaxG.Name = "labInfoMaxG";
            this.labInfoMaxG.Size = new System.Drawing.Size(26, 16);
            this.labInfoMaxG.TabIndex = 37;
            this.labInfoMaxG.Text = "10";
            this.labInfoMaxG.Visible = false;
            // 
            // labInfoMax
            // 
            this.labInfoMax.AutoSize = true;
            this.labInfoMax.BackColor = System.Drawing.Color.Transparent;
            this.labInfoMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labInfoMax.Location = new System.Drawing.Point(39, 250);
            this.labInfoMax.Name = "labInfoMax";
            this.labInfoMax.Size = new System.Drawing.Size(94, 16);
            this.labInfoMax.TabIndex = 36;
            this.labInfoMax.Text = "Valeur Max.";
            this.labInfoMax.Visible = false;
            // 
            // labInfoName
            // 
            this.labInfoName.AutoSize = true;
            this.labInfoName.BackColor = System.Drawing.Color.Transparent;
            this.labInfoName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoName.ForeColor = System.Drawing.Color.White;
            this.labInfoName.Location = new System.Drawing.Point(18, 179);
            this.labInfoName.Name = "labInfoName";
            this.labInfoName.Size = new System.Drawing.Size(51, 13);
            this.labInfoName.TabIndex = 52;
            this.labInfoName.Text = "$NOM$";
            this.labInfoName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labInfoName.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(112, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::mxw_client.Properties.Resources.Main_ItemLoaded;
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labInfoName);
            this.Controls.Add(this.labInfoTotalV);
            this.Controls.Add(this.labInfoTotal);
            this.Controls.Add(this.labInfoMinC);
            this.Controls.Add(this.labInfoMoyC);
            this.Controls.Add(this.labInfoMaxC);
            this.Controls.Add(this.labInfoMinS);
            this.Controls.Add(this.labInfoMoyS);
            this.Controls.Add(this.labInfoMaxS);
            this.Controls.Add(this.labInfoQtyV);
            this.Controls.Add(this.labInfoQty);
            this.Controls.Add(this.labInfoMinG);
            this.Controls.Add(this.labInfoMin);
            this.Controls.Add(this.labInfoMoyG);
            this.Controls.Add(this.labInfoMoy);
            this.Controls.Add(this.labInfoMaxG);
            this.Controls.Add(this.labInfoMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIDSearch);
            this.Controls.Add(this.labToken);
            this.Controls.Add(this.comboBoxRealm);
            this.Controls.Add(this.labFuncSettings);
            this.Controls.Add(this.labCredits);
            this.Controls.Add(this.labFuncClose);
            this.Controls.Add(this.labMainVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labMainVersion;
        private System.Windows.Forms.Label labFuncClose;
        private System.Windows.Forms.Label labCredits;
        private System.Windows.Forms.Label labFuncSettings;
        private System.Windows.Forms.Label labToken;
        private System.Windows.Forms.TextBox textBoxIDSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBoxRealm;
        public System.Windows.Forms.Label labInfoTotalV;
        public System.Windows.Forms.Label labInfoTotal;
        public System.Windows.Forms.Label labInfoMinC;
        public System.Windows.Forms.Label labInfoMoyC;
        public System.Windows.Forms.Label labInfoMaxC;
        public System.Windows.Forms.Label labInfoMinS;
        public System.Windows.Forms.Label labInfoMoyS;
        public System.Windows.Forms.Label labInfoMaxS;
        public System.Windows.Forms.Label labInfoQtyV;
        public System.Windows.Forms.Label labInfoQty;
        public System.Windows.Forms.Label labInfoMinG;
        public System.Windows.Forms.Label labInfoMin;
        public System.Windows.Forms.Label labInfoMoyG;
        public System.Windows.Forms.Label labInfoMoy;
        public System.Windows.Forms.Label labInfoMaxG;
        public System.Windows.Forms.Label labInfoMax;
        public System.Windows.Forms.Label labInfoName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
