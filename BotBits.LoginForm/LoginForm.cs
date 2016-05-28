using BotBits.LoginForm.Facebook;
using System.Windows.Forms;
using System;

namespace BotBits.LoginForm
{
    internal partial class LoginForm : Form
    {
        public Login Login { get; private set; }
        public LoginClient LoginClient { get; private set; }
        private LoginData SelectedData => SettingsManager.LoginDatas[listBoxAccounts.SelectedIndex];

        public LoginForm(Login login)
        {
            Login = login;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            foreach (var data in SettingsManager.LoginDatas) Add(data);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dia = new Add("Add");
            if (dia.ShowDialog(this) == DialogResult.OK)
            {
                SettingsManager.LoginDatas.Add(dia.LoginData);
                SettingsManager.Save();
                Add(dia.LoginData);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var id = listBoxAccounts.SelectedIndex;
            var dia = new Add("Save", SelectedData);
            if (dia.ShowDialog(this) == DialogResult.OK)
            {
                SettingsManager.Save();
                listBoxAccounts.Items[id] = DataToString(dia.LoginData);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var id = listBoxAccounts.SelectedIndex;
            SettingsManager.LoginDatas.RemoveAt(id);
            SettingsManager.Save();
            listBoxAccounts.Items.RemoveAt(id);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DoLogin(SelectedData);
        }

        private void buttonFacebook_Click(object sender, EventArgs e)
        {
            var dia = new FacebookLogin();
            if (dia.ShowDialog(this) == DialogResult.OK)
            {
                DoLogin(dia.AccessToken);
            }
        }

        private void buttonQuickLogin_Click(object sender, EventArgs e)
        {
            var dia = new Add("Connect");
            if (dia.ShowDialog(this) == DialogResult.OK)
            {
                DoLogin(dia.LoginData);
            }
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var enabled = listBoxAccounts.SelectedIndex != -1;
            buttonEdit.Enabled = enabled;
            buttonRemove.Enabled = enabled;
            buttonSelect.Enabled = enabled;
        }

        private void Add(LoginData data)
        {
            listBoxAccounts.Items.Add(DataToString(data));
        }

        private void DoLogin(LoginData data)
        {
            Hide();
            try
            {
                LoginClient = data.Login(Login);

                SettingsManager.LoginDatas.Remove(data);
                SettingsManager.LoginDatas.Insert(0, data);
                SettingsManager.Save();
                Close();
            }
            catch (Exception ex)
            {
                Show();
                MessageBox.Show("Unable to login: " + ex.Message, "Error!");
            }
        }

        private void DoLogin(string facebookToken)
        {
            Hide();
            try
            {
                LoginClient = Login.WithFacebook(facebookToken);
                Close();
            }
            catch (Exception ex)
            {
                Show();
                MessageBox.Show("Unable to login: " + ex.Message, "Error!");
            }
        }

        private static string DataToString(LoginData data)
        {
            return $"({data.LoginType}) {data.Email}";
        }
    }
}
