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
        private Dictionary<string, string> selected_command = new Dictionary<string, string>();

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            selected_command.Add("Sign-in options", "signinoptions");
            selected_command.Add("Your info", "yourinfo");
            selected_command.Add("Apps and Features", "appsfeatures");
            selected_command.Add("Default apps", "defaultapps");
            selected_command.Add("Bluetooth", "bluetooth");
            selected_command.Add("Camera", "camera");
            selected_command.Add("Mouse (and touchpad)", "mousetouchpad");
            selected_command.Add("USB", "usb");
            selected_command.Add("Wifi", "network-wifi");
            selected_command.Add("Airplane mode", "proximity");
            selected_command.Add("Cellular", "network-cellular");
            selected_command.Add("Mobile hotspot", "network-mobilehotspot");

            if (selected_item == "Settings") {
                await launcher.OpenProtocol("ms-settings:", "Windows Settings");
            }
            else
            {
                await launcher.OpenProtocol("ms-settings:" + selected_command[selected_item], selected_item + " on Settings");
            }
            return;
            
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
