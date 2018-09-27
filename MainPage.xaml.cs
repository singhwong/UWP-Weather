using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace UsefulWeather
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool itemone_bool = false;
        private bool itemtwo_bool = false;
        private bool itemthree_bool = false;
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
        private string background_value;
        private string foreground_value;
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        //private const string SettingTheme = "Theme";
        public MainPage()
        {
            this.InitializeComponent();
            main_frame.Navigate(typeof(HomePage));
        }

        private void list_button_Click(object sender, RoutedEventArgs e)
        {
            main_splitview.IsPaneOpen = !main_splitview.IsPaneOpen;
        }

        private void main_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (listbox_itemone.IsSelected)
            {
                setting_listbox.SelectedIndex = -1;
                main_scrollViewer.Visibility = Visibility.Visible;
                setting_stackPanel.Visibility = Visibility.Collapsed;
                main_frame.Navigate(typeof(HomePage));
                main_title.Text = "CurrentWeather";
                back_button.Visibility = Visibility.Collapsed;
                itemone_bool = true;
                itemtwo_bool = false;
                itemthree_bool = false;
                refresh_button.Visibility = Visibility.Visible;
            }
            else if (listbox_itemtwo.IsSelected)
            {
                setting_listbox.SelectedIndex = -1;
                main_scrollViewer.Visibility = Visibility.Visible;
                setting_stackPanel.Visibility = Visibility.Collapsed;
                main_frame.Navigate(typeof(LocationPage));
                main_title.Text = "LocationWeather";
                back_button.Visibility = Visibility.Collapsed;
                itemone_bool = false;
                itemtwo_bool = true;
                itemthree_bool = false;
                refresh_button.Visibility = Visibility.Collapsed;
            }
            else if (listbox_itemthree.IsSelected)
            {
                setting_listbox.SelectedIndex = -1;
                setting_stackPanel.Visibility = Visibility.Collapsed;
                main_scrollViewer.Visibility = Visibility.Visible;
                main_frame.Navigate(typeof(CityPage));
                main_title.Text = "CityWeather";
                back_button.Visibility = Visibility.Collapsed;
                itemone_bool = false;
                itemtwo_bool = false;
                itemthree_bool = true;
                refresh_button.Visibility = Visibility.Collapsed;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            setting_stackPanel.Visibility = Visibility.Collapsed;
            back_button.Visibility = Visibility.Collapsed;
            itemone_bool = true;
            LocalSettings();
            if (Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.IsSupported())
            {
                this.listbox_itemfeedback.Visibility = Visibility.Visible;
            }
        }
        private void LocalSettings()
        {
            try
            {
                background_value = localSettings.Values["Background"].ToString();
                foreground_value = localSettings.Values["Foreground"].ToString();
            }
            catch
            {
            }
            switch (background_value)
            {
                case "red": SetBackGround(red); break;
                case "skyblue": SetBackGround(skyBlue); break;
                case "black": SetBackGround(black); break;
                case "gray": SetBackGround(gray); break;
                case "lightgray": SetBackGround(lightGray); break;
                case "whitesmoke": SetBackGround(whiteSmoke); break;
                case "deeppink": SetBackGround(deepPink); break;
                case "antiquewhite": SetBackGround(antiqueWhite); break;
                case "aqua": SetBackGround(aqua); break;
                case "azure": SetBackGround(azure); break;
                case "coral": SetBackGround(coral); break;
                case "brown": SetBackGround(brown); break;
                case "darkviolet": SetBackGround(darkViolet); break;
                case "gold": SetBackGround(gold); break;
                default:
                    break;
            }
            switch (foreground_value)
            {
                case "red": SetForeGround(red); break;
                case "skyblue": SetForeGround(skyBlue); break;
                case "black": SetForeGround(black); break;
                case "gray": SetForeGround(gray); break;
                case "lightgray": SetForeGround(lightGray); break;
                case "whitesmoke": SetForeGround(whiteSmoke); break;
                case "deeppink": SetForeGround(deepPink); break;
                case "antiquewhite": SetForeGround(antiqueWhite); break;
                case "aqua": SetForeGround(aqua); break;
                case "azure": SetForeGround(azure); break;
                case "coral": SetForeGround(coral); break;
                case "brown": SetForeGround(brown); break;
                case "darkviolet": SetForeGround(darkViolet); break;
                case "gold": SetForeGround(gold); break;
                default:
                    break;
            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            main_scrollViewer.Visibility = Visibility.Visible;
            setting_stackPanel.Visibility = Visibility.Collapsed;
            setting_listbox.SelectedIndex = -1;
            back_button.Visibility = Visibility.Collapsed;
            if (itemone_bool == true)
            {
                main_title.Text = "CurrentWeather";
                refresh_button.Visibility = Visibility.Visible;
            }
            if (itemtwo_bool == true)
            {
                main_title.Text = "LocationWeather";
            }
            if (itemthree_bool == true)
            {
                main_title.Text = "CityWeather";
            }
            else
            {
                main_title.Text = "CurrentWeather";
            }
        }

        private void refresh_button_Click(object sender, RoutedEventArgs e)
        {
            main_frame.Navigate(typeof(HomePage));
        }

        private void backGround_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (ComboBox)sender;
            var selectionvalue = (ComboBoxItem)value.SelectedItem;
            var color_value = selectionvalue.Content;
            switch (color_value)
            {
                case "Red":SetBackGround(red);
                    localSettings.Values["Background"] = "red"; break;
                case "SkyBlue":SetBackGround(skyBlue);
                    localSettings.Values["Background"] = "skyblue"; break;
                case "Black":SetBackGround(black);
                    localSettings.Values["Background"] = "black"; break;
                case "Gray":SetBackGround(gray);
                    localSettings.Values["Background"] = "gray"; break;
                case "LightGray":SetBackGround(lightGray);
                    localSettings.Values["Background"] = "lightgray"; break;
                case "WhiteSmoke":SetBackGround(whiteSmoke);
                    localSettings.Values["Background"] = "whitesmoke"; break;
                case "DeepPink":SetBackGround(deepPink);
                    localSettings.Values["Background"] = "deeppink"; break;
                case "antiqueWhite":SetBackGround(antiqueWhite);
                    localSettings.Values["Background"] = "antiquewhite"; break;
                case "aqua":SetBackGround(aqua);
                    localSettings.Values["Background"] = "aqua"; break;
                case "azure":SetBackGround(azure);
                    localSettings.Values["Background"] = "zaure"; break;
                case "coral":SetBackGround(coral);
                    localSettings.Values["Background"] = "coral"; break;
                case "brown":SetBackGround(brown);
                    localSettings.Values["Background"] = "brown"; break;
                case "darkViolet":SetBackGround(darkViolet);
                    localSettings.Values["Background"] = "darkviolet"; break;
                case "gold":SetBackGround(gold);
                    localSettings.Values["Background"] = "gold"; break;
                default: break;
            }
        }

        private void foreGround_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (ComboBox)sender;
            var selectionvalue = (ComboBoxItem)value.SelectedItem;
            var color_value = selectionvalue.Content;
            switch (color_value)
            {
                case "Red":SetForeGround(red);
                    localSettings.Values["Foreground"] = "red"; break;
                case "SkyBlue":SetForeGround(skyBlue);
                    localSettings.Values["Foreground"] = "skyblue"; break;
                case "Black":SetForeGround(black);
                    localSettings.Values["Foreground"] = "black"; break;
                case "Gray":SetForeGround(gray);
                    localSettings.Values["Foreground"] = "gray"; break;
                case "LightGray":SetForeGround(lightGray);
                    localSettings.Values["Foreground"] = "lightgray"; break;
                case "WhiteSmoke":SetForeGround(whiteSmoke);
                    localSettings.Values["Foreground"] = "whitesmoke"; break;
                case "DeepPink":SetForeGround(deepPink);
                    localSettings.Values["Foreground"] = "deeppink"; break;
                case "antiqueWhite":SetForeGround(antiqueWhite);
                    localSettings.Values["Foreground"] = "antiquewhite"; break;
                case "aqua":SetForeGround(aqua);
                    localSettings.Values["Foreground"] = "aqua"; break;
                case "azure":SetForeGround(azure);
                    localSettings.Values["Foreground"] = "azure"; break;
                case "coral":SetForeGround(coral);
                    localSettings.Values["Foreground"] = "coral"; break;
                case "brown":SetForeGround(brown);
                    localSettings.Values["Foreground"] = "brown"; break;
                case "darkViolet":SetForeGround(darkViolet);
                    localSettings.Values["Foreground"] = "darkviolet"; break;
                case "gold":SetForeGround(gold);
                    localSettings.Values["Foreground"] = "gold"; break;
                default: break;
            }
        }

        private void SetForeGround(SolidColorBrush color)
        {
            list_button.Foreground = color;
            refresh_button.Foreground = color;
            back_button.Foreground = color;
            main_title.Foreground = color;
            home_textblock.Foreground = color;
            home_Text.Foreground = color;
            location_textblock.Foreground = color;
            location_Text.Foreground = color;
            city_textblock.Foreground = color;
            city_Text.Foreground = color;
            setting_textblock.Foreground = color;
            setting_Text.Foreground = color;
            backGround_textblock.Foreground = color;
            foreGround_textblock.Foreground = color;
            aobut_button.Foreground = color;
            uri_textblock.Foreground = color;
            github_textblock.Foreground = color;
            feedback_textblock.Foreground = color;
            feedback_Text.Foreground = color;
        }
        private void SetBackGround(SolidColorBrush color)
        {
            main_grid.Background = color;
            main_listbox.Background = color;
            setting_listbox.Background = color;
            list_button.Background = color;
            back_button.Background = color;
            refresh_button.Background = color;
            aobut_button.Background = color;
        }

        private async void aobut_button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog content = new ContentDialog
            {
                Title = "about",
                Content = "The weather api from github",
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
            };
            ContentDialogResult result = await content.ShowAsync();
        }

        private async void setting_listbox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (listbox_itemSetting.IsSelected)
            {
                back_button.Visibility = Visibility.Visible;
                main_listbox.SelectedIndex = -1;
                main_scrollViewer.Visibility = Visibility.Collapsed;
                setting_stackPanel.Visibility = Visibility.Visible;
                main_title.Text = "Setting";
                refresh_button.Visibility = Visibility.Collapsed;
            }
            else if (listbox_itemfeedback.IsSelected)
            {
                var launcher = Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.GetDefault();
                await launcher.LaunchAsync();
            }
        }
    }
}

