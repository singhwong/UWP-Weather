using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
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
    public sealed partial class CityPage : Page
    {
        private SolidColorBrush red = new SolidColorBrush(Colors.Red);
        private SolidColorBrush skyBlue = new SolidColorBrush(Colors.SkyBlue);
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);
        private SolidColorBrush gray = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush lightGray = new SolidColorBrush(Colors.LightGray);
        private SolidColorBrush whiteSmoke = new SolidColorBrush(Colors.WhiteSmoke);
        private SolidColorBrush deepPink = new SolidColorBrush(Colors.DeepPink);
        private SolidColorBrush antiqueWhite = new SolidColorBrush(Colors.AntiqueWhite);
        private SolidColorBrush aqua = new SolidColorBrush(Colors.Aqua);
        private SolidColorBrush azure = new SolidColorBrush(Colors.Azure);
        private SolidColorBrush coral = new SolidColorBrush(Colors.Coral);
        private SolidColorBrush brown = new SolidColorBrush(Colors.Brown);
        private SolidColorBrush darkViolet = new SolidColorBrush(Colors.DarkViolet);
        private SolidColorBrush gold = new SolidColorBrush(Colors.Gold);
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private string foreground_value;
        public CityPage()
        {
            this.InitializeComponent();            
        }

        private async void cityname_button_Click(object sender, RoutedEventArgs e)
        {
            LoadForeground();
            city_progressring.IsActive = true;
            try
            {               
                RootObject weather = await weatherAPI.GetWeatherByCityName(cityname_textbox.Text);
                DataContext = weather;
                C_textblock.Text = "°C";
                Time_textblock.Text = "Time";
                Temp_textblock.Text = "Temperature";
                Dec_textblock.Text = "Description";
                Icon_textblock.Text = "Icon";
                cityname_textbox.Text = "";
                mainMaxTem_String.Text = "Max Temp:";
                mainMinTem_String.Text = "Min Temp:";
                mainWindSpeed_String.Text = "Wind Speed:";
                WindSpeedUnit_String.Text = "m/s";
                MaxTempC_textblock.Text = "°C";
                MinTempC_textblock.Text = "°C";
                lat_textString.Text = "Latitude: ";
                lon_textString.Text = "Longitude: ";

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
                ContentDialog dia = new ContentDialog
                {
                    Title = "Wrong Input",
                    Content = "Enter the city name is wrong, please input again.",
                    IsPrimaryButtonEnabled = true,
                    PrimaryButtonText = "OK",
                };
                ContentDialogResult result = await dia.ShowAsync();
                
            }
            city_progressring.IsActive = false;
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
            inputcityname_textblock.Foreground = color;
            lat_textString.Foreground = color;
            lat_textblock.Foreground = color;
            lon_textString.Foreground = color;
            lon_textblock.Foreground = color;
        }
        private void LoadForeground()
        {
            try
            {
                foreground_value = localSettings.Values["Foreground"].ToString();
            }
            catch
            {
                localSettings.Values["Foreground"] = "black";
                foreground_value = localSettings.Values["Foreground"].ToString();
            }
            switch (foreground_value)
            {
                case "red": TextblockForeground(red); break;
                case "skyblue": TextblockForeground(skyBlue); break;
                case "black": TextblockForeground(black); break;
                case "gray": TextblockForeground(gray); break;
                case "lightgray": TextblockForeground(lightGray); break;
                case "whitesmoke": TextblockForeground(whiteSmoke); break;
                case "deeppink": TextblockForeground(deepPink); break;
                case "antiquewhite": TextblockForeground(antiqueWhite); break;
                case "aqua": TextblockForeground(aqua); break;
                case "azure": TextblockForeground(azure); break;
                case "coral": TextblockForeground(coral); break;
                case "brown": TextblockForeground(brown); break;
                case "darkviolet": TextblockForeground(darkViolet); break;
                case "gold": TextblockForeground(gold); break;
                default:
                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadForeground();
        }
    }
}
