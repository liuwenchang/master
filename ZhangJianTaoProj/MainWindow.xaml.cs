﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZhangJianTaoProj
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private  void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            if (e.IsItemOptions)
            {
                    this.Close();
            }
            else
            {
                HamburgerMenuControl.Content = e.InvokedItem;
            }

        }
        private async Task<MessageDialogResult> ShowMessageDialog()
        {
            // This demo runs on .Net 4.0, but we're using the Microsoft.Bcl.Async package so we have async/await support
            // The package is only used by the demo and not a dependency of the library!
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "是",
                NegativeButtonText = "否",
                AnimateShow = true,
                AnimateHide = false,
                //FirstAuxiliaryButtonText = "取消",
                ColorScheme = MetroDialogOptions.ColorScheme
            };
            return await this.ShowMessageAsync("应用提示", "是否退出应用?",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            //if (result != MessageDialogResult.FirstAuxiliary)
            //  return await this.ShowMessageAsync("Result", "You said: " + (result == MessageDialogResult.Affirmative ? mySettings.AffirmativeButtonText : mySettings.NegativeButtonText +
            //        Environment.NewLine + Environment.NewLine + "This dialog will follow the Use Accent setting."));
        }

        private async void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            MessageDialogResult result = await ShowMessageDialog();
            if (result == MessageDialogResult.Affirmative)
                Application.Current.Shutdown();
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoginDialogData result = await this.ShowLoginAsync("口令认证", "请输入您的用户口令", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, ShouldHideUsername = true });
            while (true) {

                    if (result.Password == "admin")
                        break;
                    else
                        result = await this.ShowLoginAsync("口令认证", "认证失败，请重新输入您的用户口令", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, ShouldHideUsername = true });
            }
            return;
        }
    }
}
