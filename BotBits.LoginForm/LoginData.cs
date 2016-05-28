using System.ComponentModel;
using System;

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
            LoginType = loginType;
            Password = password;
            Email = email;
        }

        public LoginType LoginType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        internal LoginClient Login(Login login)
        {
            switch (LoginType)
            {
                case LoginType.ArmorGames: return login.WithArmorGames(Email, Password);
                case LoginType.Kongregate: return login.WithKongregate(Email, Password);
                case LoginType.Regular: return login.WithEmail(Email, Password);
                case LoginType.Facebook: return login.WithFacebook(Email);
                default: throw new InvalidOperationException();
            }
        }
    }
}
