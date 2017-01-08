using System;
using System.Windows.Forms;

namespace BotBits.LoginForm
{
    internal partial class Add : Form
    {
        public Add(string windowName, LoginData loginData = null)
        {
            this.LoginData = loginData;
            this.InitializeComponent();
            this.buttonAdd.Text = windowName;
            if (this.LoginData != null)
            {
                switch (this.LoginData.LoginType)
                {
                    case LoginType.Kongregate:
                        this.radioButtonKongregate.Checked = true;
                        break;
                    case LoginType.ArmorGames:
                        this.radioButtonArmorGames.Checked = true;
                        break;
                }

                this.textBoxEmail.Text = this.LoginData.Email;
                this.textBoxPassword.Text = this.LoginData.Password;
            }
            else
            {
                this.LoginData = new LoginData();
            }
        }

        public LoginData LoginData { get; set; }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.radioButtonRegular.Checked) this.LoginData.LoginType = LoginType.Regular;
            if (this.radioButtonKongregate.Checked) this.LoginData.LoginType = LoginType.Kongregate;
            if (this.radioButtonArmorGames.Checked) this.LoginData.LoginType = LoginType.ArmorGames;
            if (this.radioButtonFacebook.Checked) this.LoginData.LoginType = LoginType.Facebook;

            this.LoginData.Email = this.textBoxEmail.Text;
            this.LoginData.Password = this.textBoxPassword.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void radioCheck(object sender, EventArgs e)
        {
            if (this.radioButtonFacebook.Checked)
            {
                this.labelEmail.Text = "Token: ";
                this.labelPassword.Visible = false;
                this.textBoxPassword.Visible = false;
            }
            else
            {
                this.labelEmail.Text = "Email/UserId";
                this.labelPassword.Visible = true;
                this.textBoxPassword.Visible = true;
            }
        }
    }
}