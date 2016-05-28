using System.Collections.Generic;
using System.ComponentModel;

namespace BotBits.LoginForm
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LoginDatas : List<LoginData>
    {
        public LoginDatas() : this(false)
        {
            
        }
        
        internal LoginDatas(bool isNew)
        {
            if (isNew)
            {
                Add(new LoginData(LoginType.Regular, "guest", "guest"));
            }
        }
    }
}