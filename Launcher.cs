using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace UWPQuickshortcuts
{
    class launcher
    {
        public static async Task OpenProtocol(string command, string name)
        {
            var link = new Uri(command);
            var isSuccess = await Windows.System.Launcher.LaunchUriAsync(link);
            if (isSuccess)
            {
                ShowNotification(name, true);
            }
            else
            {
                ShowNotification(name, false);
            }
        }

        public static void ShowNotification(string name, bool isOk)
        {
            string text;
            if (isOk)
            {
                text = "Successfully opened " + name;
            }
            else
            {
                text = "Error occured opening " + name;
            }

            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Completed!")
                .AddText(text)
                .Show();
        }
    }
}