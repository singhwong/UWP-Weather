﻿#pragma checksum "C:\Users\wang\source\repos\App1\UsefulWeather\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5019256F763A2DC6C14A6102BC6B4DC7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UsefulWeather
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 16
                {
                    this.list_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.list_button).Click += this.list_button_Click;
                }
                break;
            case 3: // MainPage.xaml line 25
                {
                    this.main_title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // MainPage.xaml line 32
                {
                    this.main_splitview = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 5: // MainPage.xaml line 38
                {
                    this.main_listbox = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.main_listbox).SelectionChanged += this.main_listbox_SelectionChanged;
                }
                break;
            case 6: // MainPage.xaml line 42
                {
                    this.listbox_itemone = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 7: // MainPage.xaml line 56
                {
                    this.listbox_itemtwo = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 8: // MainPage.xaml line 70
                {
                    this.listbox_itemthree = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 9: // MainPage.xaml line 84
                {
                    this.listbox_itemSetting = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 10: // MainPage.xaml line 104
                {
                    this.main_frame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

