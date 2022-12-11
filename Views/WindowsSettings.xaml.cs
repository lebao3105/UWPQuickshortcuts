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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPQuickshortcuts.Views
{
    public sealed partial class WindowsSettings : ContentDialog
    {
        public WindowsSettings()
        {
            this.InitializeComponent();
        }

        private string selected_item;
        private string cmd;

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
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
            }
            if (selected_item == "Settings") {
                await launcher.OpenProtocol("ms-settings://", "Windows Settings");
                return;
            }
            await launcher.OpenProtocol("ms-settings://" + cmd, selected_item + " on Settings");
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // do nothing
        }

        private void ItemsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected_item = (string)e.AddedItems[0];
        }
    }
}
