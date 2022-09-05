using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace applicationLauncher
{
    /// <summary>
    /// A page with many buttons:)
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async Task RunTask(string command, string name)
        {
            var link = new Uri(command);
            var isSuccess = await Windows.System.Launcher.LaunchUriAsync(link);
            if (isSuccess)
            {
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText("Completed!")
                    .AddText("Done - successfully started " + name)
                    .Show();
            } else
            {
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText("Failed")
                    .AddText("There was error(s) while starting "+name)
                    .Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RunTask("ms-actioncenter://", "Action center");
        }

        // wifi
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RunTask("ms-settings-wifi://", "Wifi Settings");
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog {
                Title = "About this app",
                Content = "QuickShortcuts v1.0 by Le Bao Nguyen.\n" +
                "Project source code: https://github.com/lebao3105/UWPQuickshortcuts",
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }

        private void bluetooth_settings_Click(object sender, RoutedEventArgs e)
        {
            RunTask("ms-settings-bluetooth://", "Bluetooth Settings");
        }

        private void lock_settings_Click(object sender, RoutedEventArgs e)
        {
            RunTask("ms-settings-lock://", "Look Screen Settings");
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            RunTask("ms-settings://", "Settings");
        }
    }
}
