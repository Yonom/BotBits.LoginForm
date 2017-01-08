using System;
using System.Runtime.InteropServices;
using mshtml;
using SHDocVw;

namespace BotBits.LoginForm.Facebook
{
    internal class CrossFrameIe
    {
        private const int EAccessdenied = unchecked((int)0x80070005L);
        private static Guid iidIWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");
        private static Guid iidIWebBrowser2 = new Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E");


        // Returns null in case of failure.
        public static IHTMLDocument2 GetDocumentFromWindow(IHTMLWindow2 htmlWindow)
        {
            if (htmlWindow == null) return null;

            // First try the usual way to get the document.
            try
            {
                var doc = htmlWindow.document;
                return doc;
            }
            catch (COMException comEx)
            {
                // I think COMException won't be ever fired but just to be sure ...
                if (comEx.ErrorCode != EAccessdenied) return null;
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch
            {
                return null;
            } // Any other error.

            // At this point the error was E_ACCESSDENIED because the frame contains a document from another domain.
            // IE tries to prevent a cross frame scripting security issue.
            try
            {
                // Convert IHTMLWindow2 to IWebBrowser2 using IServiceProvider.
                var sp = (IServiceProvider)htmlWindow;

                // Use IServiceProvider.QueryService to get IWebBrowser2 object.
                object brws = null;
                sp.QueryService(ref iidIWebBrowserApp, ref iidIWebBrowser2, out brws);

                // Get the document from IWebBrowser2.
                var browser = (IWebBrowser2)(brws);

                return (IHTMLDocument2)browser.Document;
            }
            catch
            {
            }

            return null;
        }
    }

    // This is the COM IServiceProvider interface, not System.IServiceProvider .Net interface!
}