using System;
using System.ComponentModel;

namespace BotBits.LoginForm
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LoginData
    {
        public LoginData()
        {
            
        }

        internal LoginData(LoginType loginType, string email, string password)
        {
            this.LoginType = loginType;
            this.Email = email;
            this.Password = password;
        }

        public LoginType LoginType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        internal LoginClient Login(ConnectionManager connectionManager)
        {
            switch (LoginType)
            {
                case LoginType.Regular:
                    return connectionManager.EmailLogin(this.Email, this.Password);
                case LoginType.Kongregate:
                    return connectionManager.KongregateLogin(this.Email, this.Password);
                case LoginType.ArmorGames:
                    return connectionManager.ArmorGamesLogin(this.Email, this.Password);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
