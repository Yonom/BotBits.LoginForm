using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotBits.LoginForm
{
    public static class LoginExtensions
    {
        public static Task<LoginClient> WithLoginPromptAsync(this Login login)
        {
            return RunThreadAsync<LoginClient>(tcs =>
            {
                Application.EnableVisualStyles();
                var form = new LoginForm(login);
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


        public static Task WithJoinPromptAsync(this LoginClient loginClient)
        {
            throw new NotImplementedException();

            //return RunThreadAsync<bool>(tcs =>
            //{
            //    Application.EnableVisualStyles();
            //    var form = new JoinForm(login);
            //    Application.Run(form);
            //    if (form.DialogResult == DialogResult.OK)
            //    {
            //        tcs.SetResult(true);
            //    }
            //    else
            //    {
            //        tcs.SetException(new OperationCanceledException());
            //    }
            //});
        }

        public static LoginClient WithLoginPrompt(this Login login)
        {
            return login.WithLoginPromptAsync().GetResultEx();
        }

        public static void WithJoinPrompt(this LoginClient loginClient)
        {
            loginClient.WithJoinPromptAsync().WaitEx();
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

        public static void WaitEx(this Task task)
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                throw ex.InnerExceptions.FirstOrDefault() ?? ex;
            }
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