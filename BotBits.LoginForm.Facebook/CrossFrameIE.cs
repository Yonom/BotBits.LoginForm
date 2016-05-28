using System.Runtime.InteropServices;
using SHDocVw;
using System;
using mshtml;

namespace BotBits.LoginForm.Facebook
{
    internal class CrossFrameIe
    {
        private static Guid iidIWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");
        private static Guid iidIWebBrowser2 = new Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E");
        private const int EAccessdenied = unchecked((int)0x80070005L);


        // Returns null in case of failure.
        public static IHTMLDocument2 GetDocumentFromWindow(IHTMLWindow2 htmlWindow)
        {
            if (htmlWindow == null) return null;

            // First try the usual way to get the document.
            try
            {
                IHTMLDocument2 doc = htmlWindow.document;
                return doc;
            }
            catch (COMException comEx)
            {
                // I think COMException won't be ever fired but just to be sure ...
                if (comEx.ErrorCode != EAccessdenied) return null;
            }
            catch (UnauthorizedAccessException) { }
            catch { return null; }// Any other error.

            // At this point the error was E_ACCESSDENIED because the frame contains a document from another domain.
            // IE tries to prevent a cross frame scripting security issue.
            try
            {
                // Convert IHTMLWindow2 to IWebBrowser2 using IServiceProvider.
                IServiceProvider sp = (IServiceProvider)htmlWindow;

                // Use IServiceProvider.QueryService to get IWebBrowser2 object.
                Object brws = null;
                sp.QueryService(ref iidIWebBrowserApp, ref iidIWebBrowser2, out brws);

                // Get the document from IWebBrowser2.
                IWebBrowser2 browser = (IWebBrowser2)(brws);

                return (IHTMLDocument2)browser.Document;
            }
            catch { }

            return null;
        }
    }

    // This is the COM IServiceProvider interface, not System.IServiceProvider .Net interface!
    [ComImport, ComVisible(true), Guid("6D5140C1-7436-11CE-8034-00AA006009FA"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IServiceProvider
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryService(ref Guid guidService, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvObject);
    }
}