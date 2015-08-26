using System;
using System.Windows.Forms;

namespace BotBits.LoginForm
{
    internal partial class Add : Form
    {
        public Add(string windowName, LoginData loginData = null)
        {
            this.LoginData = loginData;
            InitializeComponent();
            this.buttonAdd.Text = windowName;
            if (this.LoginData != null)
            {
                switch (this.LoginData.LoginType)
                {
                    case LoginType.Kongregate:
                        radioButtonKongregate.Checked = true;
                        break;
                    case LoginType.ArmorGames:
                        radioButtonArmorGames.Checked = true;
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (radioButtonRegular.Checked) this.LoginData.LoginType = LoginType.Regular;
            if (radioButtonKongregate.Checked) this.LoginData.LoginType = LoginType.Kongregate;
            if (radioButtonArmorGames.Checked) this.LoginData.LoginType = LoginType.ArmorGames;

            this.LoginData.Email = textBoxEmail.Text;
            this.LoginData.Password = textBoxPassword.Text;
            this.DialogResult = DialogResult.OK;
        }

        public LoginData LoginData { get; set; }
    }
}
