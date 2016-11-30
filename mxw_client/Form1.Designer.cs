namespace mxw_client
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labMainVersion = new System.Windows.Forms.Label();
            this.labFuncClose = new System.Windows.Forms.Label();
            this.labCredits = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labMainVersion
            // 
            this.labMainVersion.AutoSize = true;
            this.labMainVersion.BackColor = System.Drawing.Color.Transparent;
            this.labMainVersion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMainVersion.ForeColor = System.Drawing.Color.White;
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
            this.labCredits.ForeColor = System.Drawing.Color.White;
            this.labCredits.Location = new System.Drawing.Point(694, 480);
            this.labCredits.Name = "labCredits";
            this.labCredits.Size = new System.Drawing.Size(150, 12);
            this.labCredits.TabIndex = 2;
            this.labCredits.Text = "PAR MIKX | MXW.MIKX.CA";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.labCredits);
            this.Controls.Add(this.labFuncClose);
            this.Controls.Add(this.labMainVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labMainVersion;
        private System.Windows.Forms.Label labFuncClose;
        private System.Windows.Forms.Label labCredits;
    }
}

