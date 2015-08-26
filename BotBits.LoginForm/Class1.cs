using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotBits.LoginForm
{
    public static class ConnectionManagerExtensions
    {
        public static Task<LoginClient> PromptLoginAsync(this ConnectionManager connectionManager)
        {
            return RunThreadAsync<LoginClient>(tcs =>
            {
                Application.EnableVisualStyles();
                var form = new Login(connectionManager);
                Application.Run(form);
                if (form.LoginClient != null)
                {
                    tcs.SetResult(form.LoginClient);
                }
                else
                {
                    tcs.SetException(new OperationCanceledException());
                }
            });
        }

        public static LoginClient PromptLogin(this ConnectionManager connectionManager)
        {
            return connectionManager.PromptLoginAsync().GetResultEx();
        }

        private static Task<T> RunThreadAsync<T>(Action<TaskCompletionSource<T>> callback)
        {
            var tcs = new TaskCompletionSource<T>();
            var thread = new Thread(() => callback(tcs));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Name = "BotBits.LoginForm.Thread";
            thread.Start();
            return tcs.Task;
        }

        private static T GetResultEx<T>(this Task<T> task)
        {
            try
            {
                return task.Result;
            }
            catch (AggregateException ex)
            {
                throw ex.InnerExceptions.FirstOrDefault() ?? ex;
            }
        }
    }
}
