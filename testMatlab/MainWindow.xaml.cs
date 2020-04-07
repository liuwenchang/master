using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
namespace testMatlab
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                double[,] averageScore = new double[5, 7];

                //double q = 0;
                ///MWArray a = 11;

                NoiseReduce re = new NoiseReduce();
                //MWArray y = re.DoubleDataExp((MWArray)x);
                //string str = y.ToString();
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
            }
        }
    }
}
