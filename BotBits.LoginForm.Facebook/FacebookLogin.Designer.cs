using System.ComponentModel;
using System.Windows.Forms;
using AxSHDocVw;

namespace BotBits.LoginForm.Facebook
{
    partial class FacebookLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacebookLogin));
            this.labelPleaseWait = new System.Windows.Forms.Label();
            this.axWebBrowser = new AxSHDocVw.AxWebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPleaseWait
            // 
            this.labelPleaseWait.AutoSize = true;
            this.labelPleaseWait.Location = new System.Drawing.Point(12, 9);
            this.labelPleaseWait.Name = "labelPleaseWait";
            this.labelPleaseWait.Size = new System.Drawing.Size(176, 13);
            this.labelPleaseWait.TabIndex = 1;
            this.labelPleaseWait.Text = "Getting access token, please wait...";
            // 
            // axWebBrowser
            // 
            this.axWebBrowser.Enabled = true;
            this.axWebBrowser.Location = new System.Drawing.Point(-1000, 12);
            this.axWebBrowser.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser.OcxState")));
            this.axWebBrowser.Size = new System.Drawing.Size(300, 150);
            this.axWebBrowser.TabIndex = 0;
            this.axWebBrowser.DocumentComplete += new AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.axWebBrowser_DocumentComplete);
            // 
            // FacebookLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 30);
            this.Controls.Add(this.labelPleaseWait);
            this.Controls.Add(this.axWebBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FacebookLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Facebook login";
            ((System.ComponentModel.ISupportInitialize)(this.axWebBrowser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWebBrowser axWebBrowser;
        private Label labelPleaseWait;



    }
}