using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BotBits.LoginForm.Facebook;

namespace BotBits.LoginForm
{
    internal partial class Login : Form
    {
        public ConnectionManager ConnectionManager { get; private set; }
        public LoginClient LoginClient { get; private set; }
        private LoginData SelectedData { get { return SettingsManager.LoginDatas[this.listBoxAccounts.SelectedIndex]; } }

        public Login(ConnectionManager connectionManager)
        {
            this.ConnectionManager = connectionManager;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            foreach (var data in SettingsManager.LoginDatas)
                this.Add(data);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dia = new Add("Add");
            if (dia.ShowDialog(this) == DialogResult.OK)
            {
                SettingsManager.LoginDatas.Add(dia.LoginData);
                SettingsManager.Save();
                this.Add(dia.LoginData);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var id = this.listBoxAccounts.SelectedIndex;
            var dia = new Add("Save", this.SelectedData);
            if (dia.ShowDialog(this) == DialogResult.OK)
            {
                SettingsManager.Save();
                this.listBoxAccounts.Items[id] = DataToString(dia.LoginData);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var id = this.listBoxAccounts.SelectedIndex;
            SettingsManager.LoginDatas.RemoveAt(id);
            SettingsManager.Save();
            this.listBoxAccounts.Items.RemoveAt(id);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            this.DoLogin(this.SelectedData);
        }

        private void buttonFacebook_Click(object sender, EventArgs e)
        {
            var dia = new FacebookLogin();
            if (dia.ShowDialog(this) == DialogResult.OK)
            {
                this.DoLogin(dia.AccessToken);
            }
        }

        private void buttonQuickLogin_Click(object sender, EventArgs e)
        {
            var dia = new Add("Connect");
            if (dia.ShowDialog(this) == DialogResult.OK)
            {
                this.DoLogin(dia.LoginData);
            }
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var enabled = listBoxAccounts.SelectedIndex != -1;
            this.buttonEdit.Enabled = enabled;
            this.buttonRemove.Enabled = enabled;
            this.buttonSelect.Enabled = enabled;
        }

        private void Add(LoginData data)
        {
            this.listBoxAccounts.Items.Add(DataToString(data));
        }

        private void DoLogin(LoginData data)
        {
            this.Hide();
            try
            {
                this.LoginClient = data.Login(this.ConnectionManager);

                SettingsManager.LoginDatas.Remove(data);
                SettingsManager.LoginDatas.Insert(0, data);
                SettingsManager.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                this.Show();
                MessageBox.Show("Unable to login: " + ex.Message, "Error!");
            }
        }

        private void DoLogin(string facebookToken)
        {
            this.Hide();
            try
            {
                this.LoginClient = this.ConnectionManager.FacebookLogin(facebookToken);
                this.Close();
            }
            catch (Exception ex)
            {
                this.Show();
                MessageBox.Show("Unable to login: " + ex.Message, "Error!");
            }
        }

        private static string DataToString(LoginData data)
        {
            return String.Format("({0}) {1}", data.LoginType, data.Email);
        }
    }
}
