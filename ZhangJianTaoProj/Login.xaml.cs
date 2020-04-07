using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace ZhangJianTaoProj
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            login();
        }
        private void login()
        {
            if (Id.Text == "admin" && Password.Password == "admin")
            {
                MainWindow window = new MainWindow();
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("账号或者密码错误");
            }
        }

        private void BtnCancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnLogin_Click(object sender, ExecutedRoutedEventArgs e)
        {
            login();

        }
    }
}
