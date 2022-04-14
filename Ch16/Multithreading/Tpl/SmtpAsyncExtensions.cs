using System.ComponentModel;
using System.Net.Mail;

namespace Tpl;

public static class SmtpAsyncExtensions
{
    public static Task SendTaskAsync(this SmtpClient mailClient, string from,
                                string recipients, string subject, string body)
    {
        var tcs = new TaskCompletionSource<object?>();

        void CompletionHandler(object s, AsyncCompletedEventArgs e)
        {
            // Check this is the notification for our send
            if (!object.ReferenceEquals(e.UserState, tcs)) { return; }
            mailClient.SendCompleted -= CompletionHandler;
            if (e.Cancelled)
            {
                tcs.SetCanceled();
            }
            else if (e.Error != null)
            {
                tcs.SetException(e.Error);
            }
            else
            {
                tcs.SetResult(null);
            }
        };

        mailClient.SendCompleted += CompletionHandler;
        mailClient.SendAsync(from, recipients, subject, body, tcs);

        return tcs.Task;
    }
}
