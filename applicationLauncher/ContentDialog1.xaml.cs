using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Threading.Tasks;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuickShortcuts
{
    public sealed partial class ContentDialog1 : ContentDialog
    {
        public ContentDialog1()
        {
            this.InitializeComponent();
        }

        private string selected_item;
        private string cmd;

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            switch (selected_item)
            {
                case "Sign-in options":
                    cmd = "signinoptions";
                    break;
                case "Your info":
                    cmd = "yourinfo";
                    break;
                case "Apps and Features":
                    cmd = "appsfeatures";
                    break;
                case "Default apps":
                    cmd = "defaultapps";
                    break;
                case "Bluetooth":
                    cmd = "bluetooth";
                    break;
                case "Camera":
                    cmd = "camera";
                    break;
                case "Mouse (and touchpad)":
                    cmd = "mousetouchpad";
                    break;
                case "USB":
                    cmd = "usb";
                    break;
                case "Settings":
                    cmd = "";
                    break;
                default:
                    return;
            }
            RunTask2();
        }

        /// <summary>
        /// Yet another RunTask function.
        /// </summary>
        private async Task RunTask2()
        {
            var link = new Uri("ms-settings:" + cmd);
            var isSuccess = await Windows.System.Launcher.LaunchUriAsync(link);
            if (isSuccess)
            {
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText("Completed!")
                    .AddText("Done - successfully opened your prefered setting")
                    .Show();
            }
            else
            {
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText("Failed")
                    .AddText("There was error(s) while opening Settings.")
                    .Show();
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ItemsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected_item = e.AddedItems[0].ToString();
        }
    }
}
