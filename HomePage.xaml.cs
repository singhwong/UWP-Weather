using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Notifications;
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
        private SolidColorBrush white = new SolidColorBrush(Colors.White);
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);
        private SolidColorBrush skyblue = new SolidColorBrush(Colors.SkyBlue);
        private SolidColorBrush lightgray = new SolidColorBrush(Colors.LightGray);
        private SolidColorBrush lightblue = new SolidColorBrush(Colors.LightBlue);
        private SolidColorBrush aliceblue = new SolidColorBrush(Colors.AliceBlue);
        private SolidColorBrush lightcoral = new SolidColorBrush(Colors.LightCoral);
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private string foreground_value;
        public HomePage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadForeground();
            home_progressring.IsActive = true;
            try
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

                ShowMessage();
                var icon = String.Format("ms-appx:///Assets/WeatherIcons/{0}.png", weather.list[0].weather[0].icon);
                main_Image.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

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
            catch
            {
                ContentDialog cd = new ContentDialog
                {
                    Title = "Connection Error",
                    Content = "Unable to connect to the internet\nOr In the computer Settings," +
                    "You need to open access permission to the current position",
                    IsPrimaryButtonEnabled = true,
                    PrimaryButtonText = "OK",
                };
                ContentDialogResult result = await cd.ShowAsync();
            }
            home_progressring.IsActive = false;
            
        }
        private void ShowMessage()
        {
            var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);
            var tileAttributes = tileXml.GetElementsByTagName("text");
            tileAttributes[0].AppendChild(tileXml.CreateTextNode(cityname_textblock.Text));
            tileAttributes[1].AppendChild(tileXml.CreateTextNode(temp_textblock.Text + "°C"));
            tileAttributes[2].AppendChild(tileXml.CreateTextNode(mainDec_textblock.Text));
            tileAttributes[3].AppendChild(tileXml.CreateTextNode(mainWindSpeed_textblock.Text + "km/h"));
            var tileNotification = new TileNotification(tileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }

        private void white_button_Click(object sender, RoutedEventArgs e)
        {
            TextblockForeground(white);
            localSettings.Values["Foreground"] = "white";
        }

        private void black_button_Click(object sender, RoutedEventArgs e)
        {
            localSettings.Values["Foreground"] = "black";
            TextblockForeground(black);
        }

        private void skyblue_button_Click(object sender, RoutedEventArgs e)
        {
            TextblockForeground(skyblue);
            localSettings.Values["Foreground"] = "skyblue";
        }
        private void TextblockForeground(SolidColorBrush color)
        {
            country_textblock.Foreground = color;
            cityname_textblock.Foreground = color;
            temp_textblock.Foreground = color;
            C_textblock.Foreground = color;
            mainDec_textblock.Foreground = color;
            mainMaxTem_String.Foreground = color;
            mainMaxTem_textblock.Foreground = color;
            MaxTempC_textblock.Foreground = color;
            mainMinTem_String.Foreground = color;
            mainMinTem_textblock.Foreground = color;
            MinTempC_textblock.Foreground = color;
            mainWindSpeed_String.Foreground = color;
            mainWindSpeed_textblock.Foreground = color;
            WindSpeedUnit_String.Foreground = color;
            Time_textblock.Foreground = color;
            time1_textblock.Foreground = color;
            time2_textblock.Foreground = color;
            time3_textblock.Foreground = color;
            time4_textblock.Foreground = color;
            time5_textblock.Foreground = color;
            time6_textblock.Foreground = color;
            time7_textblock.Foreground = color;
            Temp_textblock.Foreground = color;
            temp1_textblock.Foreground = color;
            temp2_textblock.Foreground = color;
            temp3_textblock.Foreground = color;
            temp4_textblock.Foreground = color;
            temp5_textblock.Foreground = color;
            temp6_textblock.Foreground = color;
            temp7_textblock.Foreground = color;
            Dec_textblock.Foreground = color;
            dec1_textblock.Foreground = color;
            dec2_textblock.Foreground = color;
            dec3_textblock.Foreground = color;
            dec4_textblock.Foreground = color;
            dec5_textblock.Foreground = color;
            dec6_textblock.Foreground = color;
            dec7_textblock.Foreground = color;
            Icon_textblock.Foreground = color;           
        }
        private void LoadForeground()
        {
            try
            {
                foreground_value = localSettings.Values["Foreground"].ToString();
            }
            catch
            {
            }
            switch (foreground_value)
            {
                case "white":TextblockForeground(white);break;
                case "black":TextblockForeground(black);break;
                case "skyblue":TextblockForeground(skyblue);break;
                case "aliceblue":TextblockForeground(aliceblue);break;
                case "lightblue": TextblockForeground(lightblue); break;
                case "lightgray": TextblockForeground(lightgray); break;
                case "lightcoral": TextblockForeground(lightcoral); break;
                default:
                    break;
            }
        }

        private void aliceblue_button_Click(object sender, RoutedEventArgs e)
        {
            TextblockForeground(aliceblue);
            localSettings.Values["Foreground"] = "aliceblue";
        }

        private void lightgray_button_Click_1(object sender, RoutedEventArgs e)
        {
            TextblockForeground(lightgray);
            localSettings.Values["Foreground"] = "lightgray";
        }

        private void lightblue_button_Click(object sender, RoutedEventArgs e)
        {
            TextblockForeground(lightblue);
            localSettings.Values["Foreground"] = "lightblue";
        }

        private void lightcoral_button_Click(object sender, RoutedEventArgs e)
        {
            TextblockForeground(lightcoral);
            localSettings.Values["Foreground"] = "lightcoral";
        }
    }
}
