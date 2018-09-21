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
        }

        private void setting_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                case "Red":SetBackGround(red);break;
                case "SkyBlue":SetBackGround(skyBlue);break;
                case "Black":SetBackGround(black);break;
                case "Gray":SetBackGround(gray);break;
                case "LightGray":SetBackGround(lightGray);break;
                case "WhiteSmoke":SetBackGround(whiteSmoke);break;
                case "DeepPink":SetBackGround(deepPink);break;
                case "antiqueWhite":SetBackGround(antiqueWhite);break;
                case "aqua":SetBackGround(aqua);break;
                case "azure":SetBackGround(azure);break;
                case "coral":SetBackGround(coral);break;
                case "brown":SetBackGround(brown);break;
                case "darkViolet":SetBackGround(darkViolet);break;
                case "gold":SetBackGround(gold);break;
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
                case "Red":SetForeGround(red);break;
                case "SkyBlue":SetForeGround(skyBlue);break;
                case "Black":SetForeGround(black);break;
                case "Gray":SetForeGround(gray);break;
                case "LightGray":SetForeGround(lightGray);break;
                case "WhiteSmoke":SetForeGround(whiteSmoke);break;
                case "DeepPink":SetForeGround(deepPink);break;
                case "antiqueWhite":SetForeGround(antiqueWhite);break;
                case "aqua":SetForeGround(aqua);break;
                case "azure":SetForeGround(azure);break;
                case "coral":SetForeGround(coral);break;
                case "brown":SetForeGround(brown);break;
                case "darkViolet":SetForeGround(darkViolet);break;
                case "gold":SetForeGround(gold);break;
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
        }
        private void SetBackGround(SolidColorBrush color)
        {
            main_grid.Background = color;
            main_listbox.Background = color;
            setting_listbox.Background = color;
            list_button.Background = color;
            back_button.Background = color;
            refresh_button.Background = color;
        }
    }
}

