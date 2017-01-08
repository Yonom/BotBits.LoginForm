using System;
using System.IO;
using System.Windows.Forms;

namespace BotBits.LoginForm
{
    internal static class SettingsManager
    {
        private static readonly string _loginDatasPath;

        static SettingsManager()
        {
            BotBitsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BotBits\\LoginForm";
            if (!Directory.Exists(BotBitsPath)) Directory.CreateDirectory(BotBitsPath);

            try
            {
                _loginDatasPath = BotBitsPath + "\\Accounts.xml";
                LoginDatas = !File.Exists(_loginDatasPath)
                    ? new LoginDatas(true)
                    : XmlSerialize.Deserialize<LoginDatas>(_loginDatasPath);
            }
            catch (Exception)
            {
                LoginDatas = new LoginDatas(true);
                MessageBox.Show(null, "Error", "Failed to load settings.");
            }
        }

        public static LoginDatas LoginDatas { get; }

        public static string BotBitsPath { get; }

        public static void Save()
        {
            XmlSerialize.Serialize(LoginDatas, _loginDatasPath);
        }
    }
}