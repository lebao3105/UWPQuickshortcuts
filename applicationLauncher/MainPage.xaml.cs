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
using System.Reflection;
using Windows.UI.Xaml.Media.Animation;


namespace applicationLauncher
{
    /// <summary>
    /// Contructs a(n) initial application page with a hamburger menu
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            NavigateToView("HomePage");
        }

        // Code reference: https://blogs.msmvps.com/bsonnino/2019/02/13/navigationview-in-uwp/
        private NavigationViewItem _lastitem;

        private async void navView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                QuickShortcuts.ContentDialog1 dlg = new QuickShortcuts.ContentDialog1();
                await dlg.ShowAsync();
            }

            var item = args.InvokedItem as NavigationViewItem;
            if (item == null || item == _lastitem)
                return;
            var clickedView = item.Tag?.ToString();
            if (!NavigateToView(clickedView)) return;
            _lastitem = item;
        }

        private bool NavigateToView(string clickedView)
        {
            var view = Assembly.GetExecutingAssembly()
                .GetType($"QuickShortcuts.Views.{clickedView}");

            if (string.IsNullOrWhiteSpace(clickedView) || view == null)
            {
                return false;
            }
            ContentFm.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        private void navView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFm.CanGoBack)
                ContentFm.GoBack();
        }

        private async void ContentFm_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            var dlg = new ContentDialog
            {
                Title = "Error",
                Content = "Unable to switch between pages via the hamburger menu.\nPlease contact the developer.",
                CloseButtonText = "OK"
            };
            await dlg.ShowAsync();
        }
    }
}
