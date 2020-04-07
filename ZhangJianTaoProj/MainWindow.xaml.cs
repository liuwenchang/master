using MahApps.Metro.Controls;
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
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using zjtMatlab;
using ZhangJianTaoProj.Provider;

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
            //if (CalcParamProvider.isHadData)
            //{
            //    JiangZaoView.IsEnabled = true;
            //}
            //else
            //{
            //    JiangZaoView.IsEnabled = false;
            //}
            //JiangZaoView.IsEnabled = false;
            
            this.InputDataControl.CalcEnd_Handle += InputDataControl_CalcEnd_Handle;
            //MWArray x = @"C:\Users\liuxiaochang\Desktop\程序1\程序\位置1\003.dat";
            //try
            //{
            //    NoiseReduce re = new NoiseReduce();
            //    MWArray y = re.DoubleDataExp(x);
            //    string str = y.ToString();
            //}
            //catch (Exception ex) {
            //    string str = ex.ToString();
            //}
        }

        private void InputDataControl_CalcEnd_Handle(bool isHadData)
        {
            //if (isHadData)
            //{
            //    DingWeiView.St
            //}
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

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //LoginDialogData result = await this.ShowLoginAsync("口令认证", "请输入您的用户口令", new LoginDialogSettings { NegativeButtonVisibility = Visibility.Visible, ColorScheme = this.MetroDialogOptions.ColorScheme, ShouldHideUsername = true });
            //if(result ==null)
            //    Application.Current.Shutdown();
            //bool isCancel = false;
            //while (true) {
            //    if (result == null)
            //    {
            //        isCancel = true;
            //        break;
            //    }
            //    if (result.Password == "admin")
            //            break;
            //    result = await this.ShowLoginAsync("口令认证", "认证失败，请重新输入您的用户口令", new LoginDialogSettings { NegativeButtonVisibility = Visibility.Visible, ColorScheme = this.MetroDialogOptions.ColorScheme, ShouldHideUsername = true });
            //}
            //if(isCancel)
            //    Application.Current.Shutdown();
        }
    }
}
