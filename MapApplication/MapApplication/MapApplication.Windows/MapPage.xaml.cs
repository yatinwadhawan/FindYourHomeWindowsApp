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
using Windows.UI.Popups;
using Bing.Maps;
using Bing.Maps.Bing_Maps_XamlTypeInfo;
using Bing.Maps.Traffic;
using System.Runtime.Serialization.Json;
using System.Net.NetworkInformation;
using System.Net.Http;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MapApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        List<Places> list;
        int count = 0,x=2;
        public MapPage()
        {
            this.InitializeComponent();
            map.ZoomLevel = 16.10;
            list = new List<Places>();
            LoadAddresses();
            foreach (Places prime in list)
            {
                DownloadPageAsync(prime);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            list = new List<Places>();
            LoadAddresses();
            Places place = e.Parameter as Places;
            if (place != null)
            {
                list.Add(place);
                DownloadPageAsync(place);
            }
        }

        private void pushpinTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            address.Visibility = Visibility.Visible;
            rent.Visibility = Visibility.Visible;
            address.Visibility = Visibility.Visible;
            rooms.Visibility = Visibility.Visible;
            cateogory.Visibility = Visibility.Visible;
            submit.Visibility = Visibility.Visible;
            house.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
            if(x % 2 ==0)
            {
                house.Source=new BitmapImage(new Uri(base.BaseUri,"/Images/houseimag2.jpg"));
                x++;
            }
            else
            {
                house.Source = new BitmapImage(new Uri(base.BaseUri, "/Images/houseimg.jpg"));
                x--;
            }

            address.Text = "Address : " + list[count].address;
            rent.Text = "Rent : "+list[count].rent.ToString()+"$";
            rooms.Text = "Rooms : " + list[count].rooms.ToString();
            if(list[count].category == 1)
                cateogory.Text = "Category : Urgent";
            if (list[count].category == 2)
                cateogory.Text = "Category : After 3 Months";
            if (list[count].category == 3)
                cateogory.Text = "Category : After 6 Months";
            count++;
        }

        async void DownloadPageAsync(Places place)
        {
            string key = "AmH_EFl0fevZcbXGwaVdtWHmHxhSTyVFrShcq8cLFqBZ7XPfwRhAYuifcBb4Em-c";
            string query = place.address;

            Uri geocodeRequest = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}", query, key));

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(geocodeRequest))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                object objResponse = jsonSerializer.ReadObject(await content.ReadAsStreamAsync());
                Response jsonResponse = objResponse as Response;
                if (result != null && result.Length >= 50)
                {
                    ProcessResponse(jsonResponse, place);
                }
            }
        }

        public void ProcessResponse (Response locationsResponse, MapApplication.Places place)
        {
            int locNum = locationsResponse.ResourceSets[0].Resources.Length;

            for (int i = 0; i < locNum; i++)
            {
                Location location = (Location)locationsResponse.ResourceSets[0].Resources[i];
                if (location.Confidence == "High")
                {
                    Pushpin push = new Pushpin();
                    push.Text = location.Address.FormattedAddress;
                    push.Height = 100;
                    push.Width = 100;
                    push.Tapped += pushpinTapped;

                    Uri imgUri = new Uri(base.BaseUri, "/Images/pushpin.png");
                    BitmapImage imgSourceR = new BitmapImage(imgUri);
                    ImageBrush imgBrush = new ImageBrush() { ImageSource = imgSourceR };

                    push.DataContext = new Rectangle()
                    {
                        Fill = imgBrush,
                        Height = 100,
                        Width = 100
                    };

                    Bing.Maps.Location locat = new Bing.Maps.Location(location.Point.Coordinates[0], location.Point.Coordinates[1]);
                    MapLayer.SetPosition(push, locat);
                    if (place.category == 1)
                        push.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (place.category == 2)
                        push.Background = new SolidColorBrush(Windows.UI.Colors.Violet);
                    if (place.category == 3)
                        push.Background = new SolidColorBrush(Windows.UI.Colors.Black);

                    map.Children.Add(push);
                    map.Center = locat;
                }
            }
        }

        //Show MessageDialog Box 
        public async void ShowMessage(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        public void LoadAddresses()
        {
            list.Add(new Places("2827 Orchard Avenue Los Angeles 90007", 1400, 1, "1st Jan 2015",1));
            list.Add(new Places("2707 Portland Street Los Angeles 90007", 2000, 2, "1st Feb 2014",2));
            list.Add(new Places("1189 W 36th St, Los Angeles, CA 90007", 988, 1, "1st Jan 2015",3));
            list.Add(new Places("2827 Orchard Avenue Los Angeles 90007", 1500, 1, "2nd March 2015",1));
            list.Add(new Places("2712 Portland Street Los Angeles 90007", 1450, 1, "1st March 2015",2));
            list.Add(new Places("1187 W 36th St, Los Angeles, CA 90007", 2500, 2, "1st June 2015",3));
            list.Add(new Places("2828 Orchard Avenue Los Angeles 90007", 1680, 1, "1st June 2015",1));
            list.Add(new Places("2720 Portland Street Los Angeles 90007", 1400, 1, "1st April 2015",2));
            list.Add(new Places("1171 W 36th St, Los Angeles, CA 90007", 2500, 2, "1st June 2015",3));
            list.Add(new Places("2827 Orchard Avenue Los Angeles 90007", 1280, 1, "1st Jan 2015",1));
            list.Add(new Places("2708 Portland Street Los Angeles 90007", 1680, 1, "1st Aug 2015",2));
            list.Add(new Places("1185 W 36th St, Los Angeles, CA 90007", 1700, 1, "1st June 2015",2));
            list.Add(new Places("2890 Orchard Avenue Los Angeles 90007", 2500, 1, "1st July 2015",3));
            list.Add(new Places("2709 Portland Street Los Angeles 90007", 1550, 1, "1st May 2015",1));
            list.Add(new Places("1190 W 36th St, Los Angeles, CA 90007", 1450, 2, "1st March 2015",3));
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            map.Children.RemoveAt(0);
            map.Children.RemoveAt(1);
            map.Children.RemoveAt(2);
        }
    }
}
