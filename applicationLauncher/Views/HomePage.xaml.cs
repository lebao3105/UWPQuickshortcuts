using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuickShortcuts.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
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
            } else
            {
                await QuickShortcuts.launcher.OpenProtocol("ms-actioncenter://", "Action center");
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            QuickShortcuts.ContentDialog1 dlg = new QuickShortcuts.ContentDialog1();
            await dlg.ShowAsync();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "About this app",
                Content = "QuickShortcuts v1.0 by Le Bao Nguyen.\n" +
                "Project source code: https://github.com/lebao3105/UWPQuickshortcuts",
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }
    }
}
