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
    /// TabShowPic.xaml 的交互逻辑
    /// </summary>
    public partial class TabShowPic : UserControl
    {
        public TabShowPic()
        {
            InitializeComponent();
        }
        public void clearPic()
        {
            imgA1 = null;
            imgA2 = null;
            imgB1 = null;
            imgB2 = null;
            imgC1 = null;
            imgC2 = null;
        }
        public BitmapImage imgA1 { set { A1.Source = value; } }
        public BitmapImage imgA2 { set { A2.Source = value; } }
        public BitmapImage imgB1 { set { B1.Source = value; } }
        public BitmapImage imgB2 { set { B2.Source = value; } }
        public BitmapImage imgC1 { set { C1.Source = value; } }
        public BitmapImage imgC2 { set { C2.Source = value; } }
    }

}
