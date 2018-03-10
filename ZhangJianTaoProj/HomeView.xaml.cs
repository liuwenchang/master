using MahApps.Metro.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ZhangJianTaoProj
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private int currentIndex;
        private int totalCount;
        public HomeView()
        {
            InitializeComponent();
            totalCount = FlipView1st.Items.Count;
            currentIndex = 0;
            var t = new DispatcherTimer(TimeSpan.FromSeconds(2), DispatcherPriority.Normal, Tick, this.Dispatcher);
        }
        void Tick(object sender, EventArgs e)
        {
            var dateTime = DateTime.Now;
            FlipView1st.SelectedIndex = currentIndex++ % totalCount;
        }
        private void FlipView1st_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var flipview = ((FlipView)sender);
            switch (flipview.SelectedIndex)
            {
                case 0:
                    flipview.BannerText = "1!";
                    break;
                case 1:
                    flipview.BannerText = "2!";
                    break;
                case 2:
                    flipview.BannerText = "3!";
                    break;
                case 3:
                    flipview.BannerText = "4!";
                    break;
            }
        }
    }
}
