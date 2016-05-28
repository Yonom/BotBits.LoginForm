using System.ComponentModel;
using System.Windows.Forms;

namespace BotBits.LoginForm
{
    partial class Add
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
            this.radioButtonRegular = new System.Windows.Forms.RadioButton();
            this.radioButtonArmorGames = new System.Windows.Forms.RadioButton();
            this.radioButtonKongregate = new System.Windows.Forms.RadioButton();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.radioButtonFacebook = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioButtonRegular
            // 
            this.radioButtonRegular.AutoSize = true;
            this.radioButtonRegular.Checked = true;
            this.radioButtonRegular.Location = new System.Drawing.Point(12, 12);
            this.radioButtonRegular.Name = "radioButtonRegular";
            this.radioButtonRegular.Size = new System.Drawing.Size(62, 17);
            this.radioButtonRegular.TabIndex = 0;
            this.radioButtonRegular.TabStop = true;
            this.radioButtonRegular.Text = "Regular";
            this.radioButtonRegular.UseVisualStyleBackColor = true;
            this.radioButtonRegular.CheckedChanged += new System.EventHandler(this.radioCheck);
            // 
            // radioButtonArmorGames
            // 
            this.radioButtonArmorGames.AutoSize = true;
            this.radioButtonArmorGames.Location = new System.Drawing.Point(166, 12);
            this.radioButtonArmorGames.Name = "radioButtonArmorGames";
            this.radioButtonArmorGames.Size = new System.Drawing.Size(85, 17);
            this.radioButtonArmorGames.TabIndex = 2;
            this.radioButtonArmorGames.Text = "ArmorGames";
            this.radioButtonArmorGames.UseVisualStyleBackColor = true;
            this.radioButtonArmorGames.CheckedChanged += new System.EventHandler(this.radioCheck);
            // 
            // radioButtonKongregate
            // 
            this.radioButtonKongregate.AutoSize = true;
            this.radioButtonKongregate.Location = new System.Drawing.Point(80, 12);
            this.radioButtonKongregate.Name = "radioButtonKongregate";
            this.radioButtonKongregate.Size = new System.Drawing.Size(80, 17);
            this.radioButtonKongregate.TabIndex = 3;
            this.radioButtonKongregate.Text = "Kongregate";
            this.radioButtonKongregate.UseVisualStyleBackColor = true;
            this.radioButtonKongregate.CheckedChanged += new System.EventHandler(this.radioCheck);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(12, 45);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(71, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email/UserId:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 71);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(92, 13);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password/Token:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(110, 42);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(220, 20);
            this.textBoxEmail.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(110, 68);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(220, 20);
            this.textBoxPassword.TabIndex = 7;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 94);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(318, 36);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // radioButtonFacebook
            // 
            this.radioButtonFacebook.AutoSize = true;
            this.radioButtonFacebook.Location = new System.Drawing.Point(257, 12);
            this.radioButtonFacebook.Name = "radioButtonFacebook";
            this.radioButtonFacebook.Size = new System.Drawing.Size(73, 17);
            this.radioButtonFacebook.TabIndex = 9;
            this.radioButtonFacebook.Text = "Facebook";
            this.radioButtonFacebook.UseVisualStyleBackColor = true;
            this.radioButtonFacebook.CheckedChanged += new System.EventHandler(this.radioCheck);
            // 
            // Add
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 141);
            this.Controls.Add(this.radioButtonFacebook);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.radioButtonKongregate);
            this.Controls.Add(this.radioButtonArmorGames);
            this.Controls.Add(this.radioButtonRegular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Account Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton radioButtonRegular;
        private RadioButton radioButtonArmorGames;
        private RadioButton radioButtonKongregate;
        private Label labelEmail;
        private Label labelPassword;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button buttonAdd;
        private RadioButton radioButtonFacebook;
    }
}