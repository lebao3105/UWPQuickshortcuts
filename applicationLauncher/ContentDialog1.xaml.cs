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
using System.Diagnostics;

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

        // available settings
        //private readonly string[] its = {
        //    "Sign-in options", "Your info", "Apps and Features", "Default apps",
        //    "Bluetooth", "Camera", "Mouse (and touchpad)", "USB", "Wifi", "Airplane mode",
        //    "Cellular", "Mobile hotspot", "Settings"
        //};

        //private readonly string[] settings = {
        //    "signinoptions", "yourinfo", "appsfeatures", "defaultapps", "bluetooth", "camera",
        //    "mousetouchpad", "usb", "network-wifi", "proximity", "network-cellular",
        //    "network-mobilehotspot", ""
        //};

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
                case "Wifi":
                    cmd = "network-wifi";
                    break;
                case "Airplane mode":
                    cmd = "proximity";
                    break;
                case "Cellular":
                    cmd = "network-cellular";
                    break;
                case "Mobile hotspot":
                    cmd = "network-mobilehotpost";
                    break;
                case "Settings":
                    cmd = "";
                    break;
            }
            launcher.OpenProtocol("ms-settings://" + cmd, selected_item);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Do nothing
        }

        private void ItemsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected_item = e.AddedItems[0].ToString();
        }
    }
}
