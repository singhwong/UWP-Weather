using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UsefulWeather.Models;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
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
        #region 声明颜色并赋值
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
        #endregion
        //private string background_value;
        private string background_value;
        private string foreground_value;
        private double num;
        private double acrylic_value;
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer localAcrylic = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_background = ApplicationData.Current.LocalSettings;

        private AcrylicBrush myBrush = new AcrylicBrush();

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
            LocalSettings();//设置前景色为上次保存的值
            GetLocalBackground();
            SetLoadAcrylic();//设置不透明度为上次保存的值
            #region 判定在当前设备，反馈控件是否给予显示
            if (Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.IsSupported())
            {
                this.listbox_itemfeedback.Visibility = Visibility.Visible;
            }
            #endregion

            //ExtendAcrylicIntoTitleBar();

        }
        private void SetAcrylic(double num)
        {
            #region 设置亚克力背景
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
            {

                myBrush.BackgroundSource = AcrylicBackgroundSource.HostBackdrop;

                myBrush.TintOpacity = num;
                main_grid.Background = myBrush;
                list_button.Background = myBrush;
                refresh_button.Background = myBrush;
                main_splitview.Background = myBrush;
                main_listbox.Background = myBrush;
                setting_listbox.Background = myBrush;
                about_button.Background = myBrush;
                back_button.Background = myBrush;
            }
            else
            {
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(100, 20, 24, 37));
                main_grid.Background = myBrush;
                list_button.Background = myBrush;
                refresh_button.Background = myBrush;
                main_splitview.Background = myBrush;
                main_listbox.Background = myBrush;
                setting_listbox.Background = myBrush;
                about_button.Background = myBrush;
                back_button.Background = myBrush;
            }
            #endregion
        }
        #region 将亚克力扩展到标题栏
        private void ExtendAcrylicIntoTitleBar()
        {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }
        #endregion
        private void LocalSettings()
        {
            try
            {
                foreground_value = localSettings.Values["Foreground"].ToString();
            }
            catch
            {
                foreground_value = "black";
            }
            finally
            {
                switch (foreground_value)
                {
                    case "red":
                        SetForeGround(red);
                        foreGround_combobox.SelectedIndex = 0; break;
                    case "skyblue":
                        SetForeGround(skyBlue);
                        foreGround_combobox.SelectedIndex = 1; break;
                    case "black":
                        SetForeGround(black);
                        foreGround_combobox.SelectedIndex = 2; break;
                    case "gray":
                        SetForeGround(gray);
                        foreGround_combobox.SelectedIndex = 3; break;
                    case "lightgray":
                        SetForeGround(lightGray);
                        foreGround_combobox.SelectedIndex = 4; break;
                    case "whitesmoke":
                        SetForeGround(whiteSmoke);
                        foreGround_combobox.SelectedIndex = 5; break;
                    case "deeppink":
                        SetForeGround(deepPink);
                        foreGround_combobox.SelectedIndex = 6; break;
                    case "antiquewhite":
                        SetForeGround(antiqueWhite);
                        foreGround_combobox.SelectedIndex = 7; break;
                    case "aqua":
                        SetForeGround(aqua);
                        foreGround_combobox.SelectedIndex = 8; break;
                    case "azure":
                        SetForeGround(azure);
                        foreGround_combobox.SelectedIndex = 9; break;
                    case "coral":
                        SetForeGround(coral);
                        foreGround_combobox.SelectedIndex = 10; break;
                    case "brown":
                        SetForeGround(brown);
                        foreGround_combobox.SelectedIndex = 11; break;
                    case "darkviolet":
                        SetForeGround(darkViolet);
                        foreGround_combobox.SelectedIndex = 12; break;
                    case "gold":
                        SetForeGround(gold);
                        foreGround_combobox.SelectedIndex = 13; break;
                    default:
                        break;
                }
            }
        }
        private void GetLocalBackground()
        {
            try
            {
                background_value = local_background.Values["Background"].ToString();
            }
            catch
            {
                background_value = "deeppink";
            }
            finally
            {
                switch (background_value)
                {
                    case "red":
                        myBrush.TintColor = Colors.Red;
                        myBrush.FallbackColor = Colors.Red;
                        backGround_combobox.SelectedIndex = 0; break;
                    case "skyblue":
                        myBrush.TintColor = Colors.SkyBlue;
                        myBrush.FallbackColor = Colors.SkyBlue;
                        backGround_combobox.SelectedIndex = 1; break;
                    case "black":
                        myBrush.TintColor = Colors.Black;
                        myBrush.FallbackColor = Colors.Black;
                        backGround_combobox.SelectedIndex = 2; break;
                    case "gray":
                        myBrush.TintColor = Colors.Gray;
                        myBrush.FallbackColor = Colors.Gray;
                        backGround_combobox.SelectedIndex = 3; break;
                    case "lightgray":
                        myBrush.TintColor = Colors.LightGray;
                        myBrush.FallbackColor = Colors.LightGray;
                        backGround_combobox.SelectedIndex = 4; break;
                    case "whitesmoke":
                        myBrush.TintColor = Colors.WhiteSmoke;
                        myBrush.FallbackColor = Colors.WhiteSmoke;
                        backGround_combobox.SelectedIndex = 5; break;
                    case "deeppink":
                        myBrush.TintColor = Colors.DeepPink;
                        myBrush.FallbackColor = Colors.DeepPink;
                        backGround_combobox.SelectedIndex = 6; break;
                    case "antiquewhite":
                        myBrush.TintColor = Colors.AntiqueWhite;
                        myBrush.FallbackColor = Colors.AntiqueWhite;
                        backGround_combobox.SelectedIndex = 7; break;
                    case "aqua":
                        myBrush.TintColor = Colors.Aqua;
                        myBrush.FallbackColor = Colors.Aqua;
                        backGround_combobox.SelectedIndex = 8; break;
                    case "azure":
                        myBrush.TintColor = Colors.Azure;
                        myBrush.FallbackColor = Colors.Azure;
                        backGround_combobox.SelectedIndex = 9; break;
                    case "coral":
                        myBrush.TintColor = Colors.Coral;
                        myBrush.FallbackColor = Colors.Coral;
                        backGround_combobox.SelectedIndex = 10; break;
                    case "brown":
                        myBrush.TintColor = Colors.Brown;
                        myBrush.FallbackColor = Colors.Brown;
                        backGround_combobox.SelectedIndex = 11; break;
                    case "darkviolet":
                        myBrush.TintColor = Colors.DarkViolet;
                        myBrush.FallbackColor = Colors.DarkViolet;
                        backGround_combobox.SelectedIndex = 12; break;
                    case "gold":
                        myBrush.TintColor = Colors.Gold;
                        myBrush.FallbackColor = Colors.Gold;
                        backGround_combobox.SelectedIndex = 13; break;
                    default:
                        break;
                }
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

        private void foreGround_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (ComboBox)sender;
            var selectionvalue = (ComboBoxItem)value.SelectedItem;
            var color_value = selectionvalue.Content;
            switch (color_value)
            {
                case "Red":
                    SetForeGround(red);
                    localSettings.Values["Foreground"] = "red"; break;
                case "SkyBlue":
                    SetForeGround(skyBlue);
                    localSettings.Values["Foreground"] = "skyblue"; break;
                case "Black":
                    SetForeGround(black);
                    localSettings.Values["Foreground"] = "black"; break;
                case "Gray":
                    SetForeGround(gray);
                    localSettings.Values["Foreground"] = "gray"; break;
                case "LightGray":
                    SetForeGround(lightGray);
                    localSettings.Values["Foreground"] = "lightgray"; break;
                case "WhiteSmoke":
                    SetForeGround(whiteSmoke);
                    localSettings.Values["Foreground"] = "whitesmoke"; break;
                case "DeepPink":
                    SetForeGround(deepPink);
                    localSettings.Values["Foreground"] = "deeppink"; break;
                case "antiqueWhite":
                    SetForeGround(antiqueWhite);
                    localSettings.Values["Foreground"] = "antiquewhite"; break;
                case "aqua":
                    SetForeGround(aqua);
                    localSettings.Values["Foreground"] = "aqua"; break;
                case "azure":
                    SetForeGround(azure);
                    localSettings.Values["Foreground"] = "azure"; break;
                case "coral":
                    SetForeGround(coral);
                    localSettings.Values["Foreground"] = "coral"; break;
                case "brown":
                    SetForeGround(brown);
                    localSettings.Values["Foreground"] = "brown"; break;
                case "darkViolet":
                    SetForeGround(darkViolet);
                    localSettings.Values["Foreground"] = "darkviolet"; break;
                case "gold":
                    SetForeGround(gold);
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
            about_button.Foreground = color;
            uri_textblock.Foreground = color;
            github_textblock.Foreground = color;
            feedback_textblock.Foreground = color;
            feedback_Text.Foreground = color;
            slider_textblock.Foreground = color;
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
                main_listbox.SelectedIndex = -1;
                var launcher = Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.GetDefault();
                await launcher.LaunchAsync();
            }
        }

        private async void about_button_Click_1(object sender, RoutedEventArgs e)
        {
            ContentDialog content = new ContentDialog
            {
                Title = "about",
                Content = "The weather api from github.\n" +
               "Perhaps because of the weather api, the data is not accurate, for reference only.",
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
            };
            ContentDialogResult result = await content.ShowAsync();
        }

        private void setting_slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            var value = e.NewValue;
            num = value / 100;
            SetAcrylic(num);
            localAcrylic.Values["value"] = num;
        }
        private void SetLoadAcrylic()
        {
            try
            {
                acrylic_value = (double)localAcrylic.Values["value"];
            }
            catch
            {
                acrylic_value = 0.3;
                setting_slider.Value = 0;
            }
            SetAcrylic(acrylic_value);
            setting_slider.Value = acrylic_value * 100;
        }

        private void backGround_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (ComboBox)sender;
            var selectionvalue = (ComboBoxItem)value.SelectedItem;
            var color_value = selectionvalue.Content.ToString();
            switch (color_value)
            {
                case "Red":
                    myBrush.TintColor = Colors.Red;
                    myBrush.FallbackColor = Colors.Red;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "red"; break;
                case "SkyBlue":
                    myBrush.TintColor = Colors.SkyBlue;
                    myBrush.FallbackColor = Colors.SkyBlue;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "skyblue"; break;
                case "Black":
                    myBrush.TintColor = Colors.Black;
                    myBrush.FallbackColor = Colors.Black;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "black"; break;
                case "Gray":
                    myBrush.TintColor = Colors.Gray;
                    myBrush.FallbackColor = Colors.Gray;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "gray"; break;
                case "LightGray":
                    myBrush.TintColor = Colors.LightGray;
                    myBrush.FallbackColor = Colors.LightGray;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "lightgray"; break;
                case "WhiteSmoke":
                    myBrush.TintColor = Colors.WhiteSmoke;
                    myBrush.FallbackColor = Colors.WhiteSmoke;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "whitesmoke"; break;
                case "DeepPink":
                    myBrush.TintColor = Colors.DeepPink;
                    myBrush.FallbackColor = Colors.DeepPink;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "deeppink"; break;
                case "antiqueWhite":
                    myBrush.TintColor = Colors.AntiqueWhite;
                    myBrush.FallbackColor = Colors.AntiqueWhite;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "antiquewhite"; break;
                case "aqua":
                    myBrush.TintColor = Colors.Aqua;
                    myBrush.FallbackColor = Colors.Aqua;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "aqua"; break;
                case "azure":
                    myBrush.TintColor = Colors.Azure;
                    myBrush.FallbackColor = Colors.Azure;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "azure"; break;
                case "coral":
                    myBrush.TintColor = Colors.Coral;
                    myBrush.FallbackColor = Colors.Coral;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "coral"; break;
                case "brown":
                    myBrush.TintColor = Colors.Brown;
                    myBrush.FallbackColor = Colors.Brown;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "brown"; break;
                case "darkViolet":
                    myBrush.TintColor = Colors.DarkViolet;
                    myBrush.FallbackColor = Colors.DarkViolet;
                    SetAcrylic(num);
                    local_background.Values["Background"] = "darkviolet"; break;
                case "gold":
                    myBrush.TintColor = Colors.Gold;
                    myBrush.FallbackColor = Colors.Gold;
                    local_background.Values["Background"] = "gold"; break;
                default: break;
            }
        }

    }
}

