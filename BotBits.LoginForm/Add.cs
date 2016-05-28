using System.Windows.Forms;
using System;

namespace BotBits.LoginForm
{
    internal partial class Add : Form
    {
        public Add(string windowName, LoginData loginData = null)
        {
            LoginData = loginData;
            InitializeComponent();
            buttonAdd.Text = windowName;
            if (LoginData != null)
            {
                switch (LoginData.LoginType)
                {
                    case LoginType.Kongregate:
                        radioButtonKongregate.Checked = true;
                        break;
                    case LoginType.ArmorGames:
                        radioButtonArmorGames.Checked = true;
                        break;
                }

                textBoxEmail.Text = LoginData.Email;
                textBoxPassword.Text = LoginData.Password;
            }
            else
            {
                LoginData = new LoginData();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (radioButtonRegular.Checked) LoginData.LoginType = LoginType.Regular;
            if (radioButtonKongregate.Checked) LoginData.LoginType = LoginType.Kongregate;
            if (radioButtonArmorGames.Checked) LoginData.LoginType = LoginType.ArmorGames;
            if (radioButtonFacebook.Checked) LoginData.LoginType = LoginType.Facebook;

            LoginData.Email = textBoxEmail.Text;
            LoginData.Password = textBoxPassword.Text;
            DialogResult = DialogResult.OK;
        }

        public LoginData LoginData { get; set; }
        
        private void radioCheck(object sender, EventArgs e)
        {
            if (radioButtonFacebook.Checked)
            {
                labelEmail.Text = "Token: ";
                labelPassword.Visible = false;
                textBoxPassword.Visible = false;
            }
            else
            {
                labelEmail.Text = "Email/UserId";
                labelPassword.Visible = true;
                textBoxPassword.Visible = true;
            }
        }
    }
}
