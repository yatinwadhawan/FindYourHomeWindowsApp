using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
using Windows.UI.Popups;
using Bing.Maps;
using Bing.Maps.Bing_Maps_XamlTypeInfo;
using Bing.Maps.Traffic;
using System.Runtime.Serialization.Json;
using System.Net.NetworkInformation;
using System.Net.Http;
using Windows.Security.Authentication.Web;
using Windows.ApplicationModel.Activation;
using Facebook.Client;
using System.Windows;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MapApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
          
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            find.Visibility = Visibility.Collapsed;
            loginButton.Visibility = Visibility.Collapsed;
            huse.Visibility = Visibility.Collapsed;

            pic.Visibility = Visibility.Visible;
            wel.Visibility = Visibility.Visible;
            rent.Visibility = Visibility.Visible;
            add.Visibility = Visibility.Visible;
            profile.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
        }

       
        private void rent_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MapPage));
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            find.Visibility = Visibility.Visible;
            loginButton.Visibility = Visibility.Visible;
            huse.Visibility = Visibility.Visible;

            rent.Visibility = Visibility.Collapsed;
            add.Visibility = Visibility.Collapsed;
            profile.Visibility = Visibility.Collapsed;
            back.Visibility = Visibility.Collapsed;
            pic.Visibility = Visibility.Collapsed;
            wel.Visibility = Visibility.Collapsed;
        }

        private void add_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddRequest));
        }

        private void profile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ThirdParty ));
        }
    }
}
