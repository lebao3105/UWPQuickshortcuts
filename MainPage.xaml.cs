using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


namespace UWPQuickshortcuts
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            NavigateToView("HomePage");
        }

        private NavigationViewItem _lastitem;

        private bool NavigateToView(string clickedView)
        {
            var view = Assembly.GetExecutingAssembly()
                .GetType($"UWPQuickshortcuts.Views.{clickedView}");

            if (string.IsNullOrWhiteSpace(clickedView) || view == null)
            {
                return false;
            }
            ContentFm.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        private async void navView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                UWPQuickshortcuts.Views.WindowsSettings dlg = new UWPQuickshortcuts.Views.WindowsSettings();
                await dlg.ShowAsync();
                return;
            }

            var item = args.InvokedItem as NavigationViewItem;
            if (item == null || item == _lastitem)
                return;
            var clickedView = item.Tag?.ToString();
            if (!NavigateToView(clickedView)) return;
            _lastitem = item;
        }

        private void navView_BackRequested(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFm.CanGoBack)
                ContentFm.GoBack();
        }

        private async void ContentFm_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            var dlg = new ContentDialog
            {
                Title = "Error",
                Content = "Unable to switch between pages via the hamburger menu.",
                CloseButtonText = "OK"
            };
            await dlg.ShowAsync();
        }
    }
}
