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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static UsefulWeather.City;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace UsefulWeather
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var position = await LocationWeather.GetPosition();
            RootObject weather = await weatherAPI.GetWeatherByLocation(position.Coordinate.Point.Position.Latitude,
                position.Coordinate.Point.Position.Longitude);
            DataContext = weather;
            C_textblock.Text = "°C";
            Time_textblock.Text = "Time";
            Temp_textblock.Text = "Temperature";
            Dec_textblock.Text = "Description";
            Icon_textblock.Text = "Icon";
            mainMaxTem_String.Text = "Max Temp:";
            mainMinTem_String.Text = "Min Temp:";
            mainWindSpeed_String.Text = "Wind Speed:";
            WindSpeedUnit_String.Text = "km/h";
            MaxTempC_textblock.Text = "°C";
            MinTempC_textblock.Text = "°C";


            var icon = String.Format("ms-appx:///Assets/WeatherIcons/{0}.png",weather.list[0].weather[0].icon);
            main_Image.Source = new BitmapImage(new Uri(icon,UriKind.Absolute));

            var icon1 = String.Format("ms-appx:///Assets/WeatherIcons/{0}.png", weather.list[1].weather[0].icon);
            image1_image.Source = new BitmapImage(new Uri(icon1, UriKind.Absolute));

            var icon2 = String.Format("ms-appx:///Assets/WeatherIcons/{0}.png", weather.list[2].weather[0].icon);
            image2_image.Source = new BitmapImage(new Uri(icon2, UriKind.Absolute));

            var icon3 = String.Format("ms-appx:///Assets/WeatherIcons/{0}.png", weather.list[3].weather[0].icon);
            image3_image.Source = new BitmapImage(new Uri(icon3, UriKind.Absolute));

            var icon4 = String.Format("ms-appx:///Assets/WeatherIcons/{0}.png", weather.list[4].weather[0].icon);
            image4_image.Source = new BitmapImage(new Uri(icon4, UriKind.Absolute));

            var icon5 = String.Format("ms-appx:///Assets/WeatherIcons/{0}.png", weather.list[5].weather[0].icon);
            image5_image.Source = new BitmapImage(new Uri(icon5, UriKind.Absolute));

            var icon6 = String.Format("ms-appx:///Assets/WeatherIcons/{0}.png", weather.list[6].weather[0].icon);
            image6_image.Source = new BitmapImage(new Uri(icon6, UriKind.Absolute));

            var icon7 = String.Format("ms-appx:///Assets/WeatherIcons/{0}.png", weather.list[7].weather[0].icon);
            image7_image.Source = new BitmapImage(new Uri(icon7, UriKind.Absolute));


        }
    }
}
