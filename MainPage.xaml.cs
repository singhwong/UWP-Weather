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
            else if(listbox_itemthree.IsSelected)
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

        private void setting_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SolidColorBrush red = new SolidColorBrush(Colors.Red);
            SolidColorBrush skyBlue = new SolidColorBrush(Colors.SkyBlue);
            SolidColorBrush black = new SolidColorBrush(Colors.Black);
            SolidColorBrush gray = new SolidColorBrush(Colors.Gray);
            SolidColorBrush lightGray = new SolidColorBrush(Colors.LightGray);
            SolidColorBrush whiteSmoke = new SolidColorBrush(Colors.WhiteSmoke);
            SolidColorBrush deepPink = new SolidColorBrush(Colors.DeepPink);
            var value = (ComboBox)sender;
            var selectionvalue = (ComboBoxItem)value.SelectedItem;
            var color_value = selectionvalue.Content;
            switch (color_value)
            {
                case "Red": this.main_grid.Background = red;
                    this.main_listbox.Background = red;
                    this.setting_listbox.Background = red;
                    this.list_button.Background = red;
                    this.back_button.Background = red;
                    this.refresh_button.Background = red;
                    break;
                case "SkyBlue": this.main_grid.Background = skyBlue;
                    this.main_listbox.Background = skyBlue;
                    this.setting_listbox.Background = skyBlue;
                    this.list_button.Background = skyBlue;
                    this.back_button.Background = skyBlue;
                    this.refresh_button.Background = skyBlue;
                    break;
                case "Black": this.main_grid.Background = black;
                    this.main_listbox.Background = black;
                    this.setting_listbox.Background = black;
                    this.list_button.Background = black;
                    this.back_button.Background = black;
                    this.refresh_button.Background = black;
                    break;
                case "Gray": this.main_grid.Background = gray;
                    this.main_listbox.Background = gray;
                    this.setting_listbox.Background = gray;
                    this.list_button.Background = gray;
                    this.back_button.Background = gray;
                    this.refresh_button.Background = gray;
                    break;
                case "LightGray": this.main_grid.Background = lightGray;
                    this.main_listbox.Background = lightGray;
                    this.setting_listbox.Background = lightGray;
                    this.list_button.Background = lightGray;
                    this.back_button.Background = lightGray;
                    this.refresh_button.Background = lightGray;
                    break;
                case "WhiteSmoke": this.main_grid.Background = whiteSmoke;
                    this.main_listbox.Background = whiteSmoke;
                    this.setting_listbox.Background = whiteSmoke;
                    this.list_button.Background = whiteSmoke;
                    this.back_button.Background = whiteSmoke;
                    this.refresh_button.Background = whiteSmoke;
                    break;
                case "DeepPink": this.main_grid.Background = deepPink;
                    this.main_listbox.Background = deepPink;
                    this.setting_listbox.Background = deepPink;                   
                    this.list_button.Background = deepPink;
                    this.back_button.Background = deepPink;
                    this.refresh_button.Background = deepPink;
                    break;
                default:break;
            }           
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
            if (itemone_bool==true)
            {
                main_title.Text = "CurrentWeather";
                refresh_button.Visibility = Visibility.Visible;
            }
            if (itemtwo_bool==true)
            {
                main_title.Text = "LocationWeather";
            }
            if (itemthree_bool==true)
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
    }
}

