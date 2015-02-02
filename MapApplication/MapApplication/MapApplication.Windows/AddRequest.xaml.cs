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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MapApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddRequest : Page
    {
        public Places place;
        public AddRequest()
        {
            this.InitializeComponent();
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


        private void after_6_months_Click_1(object sender, RoutedEventArgs e)
        {
            place = new Places();
            place.address = Address.Text;
            place.rent = 500;
            place.rooms = 2;
            place.category = 3;
            place.available_date = DateTime.Today.ToString();
            this.Frame.Navigate(typeof(MapPage), place);
        }

        private void after_2_months_Click_1(object sender, RoutedEventArgs e)
        {
            place = new Places();
            place.address = Address.Text;
            place.rent = 500;
            place.rooms = 2;
            place.category = 3;
            place.available_date = DateTime.Today.ToString();
            this.Frame.Navigate(typeof(MapPage), place);
        }


        private void immediately_Click_1(object sender, RoutedEventArgs e)
        {

            place = new Places();
            place.address = Address.Text;
            place.rent = 500;
            place.rooms = 2;
            place.category = 1;
            place.available_date = DateTime.Today.ToString();
            this.Frame.Navigate(typeof(MapPage), place);
        }
    }
}
