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
            this.Password = password;
            this.Email = email;
        }

        public LoginType LoginType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        internal LoginClient Login(Login login)
        {
            switch (this.LoginType)
            {
                case LoginType.ArmorGames:
                    return login.WithArmorGames(this.Email, this.Password);
                case LoginType.Kongregate:
                    return login.WithKongregate(this.Email, this.Password);
                case LoginType.Regular:
                    return login.WithEmail(this.Email, this.Password);
                case LoginType.Facebook:
                    return login.WithFacebook(this.Email);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}