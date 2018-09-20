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
            }
            else if (listbox_itemtwo.IsSelected)
            {
                setting_listbox.SelectedIndex = -1;
                main_scrollViewer.Visibility = Visibility.Visible;
                setting_stackPanel.Visibility = Visibility.Collapsed;
                main_frame.Navigate(typeof(LocationPage));
                main_title.Text = "LocationWeather";
                back_button.Visibility = Visibility.Collapsed;
            }
            else if(listbox_itemthree.IsSelected)
            {
                setting_listbox.SelectedIndex = -1;
                setting_stackPanel.Visibility = Visibility.Collapsed;
                main_scrollViewer.Visibility = Visibility.Visible;
                main_frame.Navigate(typeof(CityPage));
                main_title.Text = "CityWeather";
                back_button.Visibility = Visibility.Collapsed;
            }
       
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            setting_stackPanel.Visibility = Visibility.Collapsed;
            back_button.Visibility = Visibility.Collapsed;
        }

        private void setting_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (ComboBox)sender;
            var selectionvalue = (ComboBoxItem)value.SelectedItem;
            var color_value = selectionvalue.Content;
            switch (color_value)
            {
                case "Red": this.main_grid.Background = new SolidColorBrush(Colors.Red);
                    this.main_listbox.Background = new SolidColorBrush(Colors.Red);
                    this.setting_listbox.Background = new SolidColorBrush(Colors.Red);
                    this.list_button.Background = new SolidColorBrush(Colors.Red);
                    this.back_button.Background = new SolidColorBrush(Colors.Red);
                    break;
                case "SkyBlue": this.main_grid.Background = new SolidColorBrush(Colors.SkyBlue);
                    this.main_listbox.Background = new SolidColorBrush(Colors.SkyBlue);
                    this.setting_listbox.Background = new SolidColorBrush(Colors.SkyBlue);
                    this.list_button.Background = new SolidColorBrush(Colors.SkyBlue);
                    this.back_button.Background = new SolidColorBrush(Colors.SkyBlue);
                    break;
                case "Black": this.main_grid.Background = new SolidColorBrush(Colors.Black);
                    this.main_listbox.Background = new SolidColorBrush(Colors.Black);
                    this.setting_listbox.Background = new SolidColorBrush(Colors.Black);
                    this.list_button.Background = new SolidColorBrush(Colors.Black);
                    this.back_button.Background = new SolidColorBrush(Colors.Black);
                    break;
                case "Gray": this.main_grid.Background = new SolidColorBrush(Colors.Gray);
                    this.main_listbox.Background = new SolidColorBrush(Colors.Gray);
                    this.setting_listbox.Background = new SolidColorBrush(Colors.Gray);
                    this.list_button.Background = new SolidColorBrush(Colors.Gray);
                    this.back_button.Background = new SolidColorBrush(Colors.Gray);
                    break;
                case "LightGray": this.main_grid.Background = new SolidColorBrush(Colors.LightGray);
                    this.main_listbox.Background = new SolidColorBrush(Colors.LightGray);
                    this.setting_listbox.Background = new SolidColorBrush(Colors.LightGray);
                    this.list_button.Background = new SolidColorBrush(Colors.LightGray);
                    this.back_button.Background = new SolidColorBrush(Colors.LightGray);
                    break;
                case "WhiteSmoke": this.main_grid.Background = new SolidColorBrush(Colors.WhiteSmoke);
                    this.main_listbox.Background = new SolidColorBrush(Colors.WhiteSmoke);
                    this.setting_listbox.Background = new SolidColorBrush(Colors.WhiteSmoke);
                    this.list_button.Background = new SolidColorBrush(Colors.WhiteSmoke);
                    this.back_button.Background = new SolidColorBrush(Colors.WhiteSmoke);
                    break;
                case "DeepPink": this.main_grid.Background = new SolidColorBrush(Colors.DeepPink);
                    this.main_listbox.Background = new SolidColorBrush(Colors.DeepPink);
                    this.setting_listbox.Background = new SolidColorBrush(Colors.DeepPink);                   
                    this.list_button.Background = new SolidColorBrush(Colors.DeepPink);
                    this.back_button.Background = new SolidColorBrush(Colors.DeepPink);
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
            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            main_scrollViewer.Visibility = Visibility.Visible;
            setting_stackPanel.Visibility = Visibility.Collapsed;
            setting_listbox.SelectedIndex = -1;
            back_button.Visibility = Visibility.Collapsed;
        }
    }
}

