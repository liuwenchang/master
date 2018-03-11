using MathWorks.MATLAB.NET.Arrays;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using zjtMatlab;

namespace ZhangJianTaoProj
{
    /// <summary>
    /// JiangZao.xaml 的交互逻辑
    /// </summary>
    public partial class JiangZao : UserControl
    {
        public JiangZao()
        {
            InitializeComponent();
        }

        private async void openFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                this.selectedFile.Text = dialog.FileName;
                await calc(dialog.FileName);
            }
        }
        private async Task<bool> calc(string fileName)
        {
            
            try
            {
                NoiseReduce re = new NoiseReduce();
                MWArray y = re.DoubleDataExp(fileName);
                string str = y.ToString();
                var img1 = new BitmapImage();
                img1.BeginInit();
                img1.StreamSource = new MemoryStream(File.ReadAllBytes(@"./jiangzao/1.jpg"));
                img1.EndInit();
                res1.Source = img1;
                var img2 = new BitmapImage();
                img2.BeginInit();
                img2.StreamSource = new MemoryStream(File.ReadAllBytes(@"./jiangzao/2.jpg"));
                img2.EndInit();
                res2.Source = img2;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Default.Error("降噪计算错误", ex);
                return false;
            }
        }
    }
}
