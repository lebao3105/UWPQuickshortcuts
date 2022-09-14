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
using Windows.Security.ExchangeActiveSyncProvisioning;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // I just found that ms-actioncenter:// does not available on Windows Phone, so I made this
            EasClientDeviceInformation info = new EasClientDeviceInformation();
            string system = info.OperatingSystem;
            if (system == "WindowsPhone")
            {
                ContentDialog dlg = new ContentDialog
                {
                    Title = "Infomation",
                    Content = "Protocol ms-actioncenter:// is not available on Windows Phone",
                    CloseButtonText = "OK"
                };
                await dlg.ShowAsync();
                return;
            }
            
            else
            {
                await QuickShortcuts.launcher.OpenProtocol("ms-actioncenter://", "Action center");
            }
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

        private async void settings_Click(object sender, RoutedEventArgs e)
        {
            QuickShortcuts.ContentDialog1 result = new QuickShortcuts.ContentDialog1();
            await result.ShowAsync();
        }
    }
}
