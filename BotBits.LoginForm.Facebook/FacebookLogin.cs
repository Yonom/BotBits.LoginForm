using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using mshtml;

namespace BotBits.LoginForm.Facebook
{
    public partial class FacebookLogin : Form
    {
        public FacebookLogin()
        {
            this.InitializeComponent();

            object zero = 0;
            object emptyString = "";
            this.axWebBrowser.Navigate(@"https://apps.facebook.com/everedits/",
                ref zero, ref emptyString, ref emptyString, ref emptyString);
        }
        
        private void axWebBrowser_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e)
        {
            try
            {
                var htmlDocument = (IHTMLDocument2)this.axWebBrowser.Document;
                if (htmlDocument.frames.length == 0)
                {
                    MessageBox.Show(this, @"Please open Internet Explorer and login on facebook.com. " +
                                    @"(Make sure to enable ""Keep me logged in"")",
                                    "Not logged in");
                    this.DialogResult = DialogResult.Abort;
                }

                if (e.uRL.ToString() != "https://everybody-edits-su9rn58o40itdbnw69plyw.fb.playerio.com/fb/everybody-edits/") return;
                var frame = (HTMLWindow2)htmlDocument.frames.item(1);
                var doc = (HTMLDocument)CrossFrameIE.GetDocumentFromWindow(frame.window);
                HTMLObjectElement flash = (HTMLObjectElement)doc.all.OfType<IHTMLObjectElement>().First();
                var es = flash.getElementsByTagName("param").OfType<HTMLParamElement>().First(p => p.name == "flashvars");
                var flashVars = es.value;
                NameValueCollection qscoll = HttpUtility.ParseQueryString(flashVars);
                this.AccessToken = qscoll["fb_access_token"];
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to get token. " + ex.Message);
                this.DialogResult = DialogResult.Abort;
            }

        }

        public string AccessToken { get; private set; }
    }
}
