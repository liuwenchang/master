using MathWorks.MATLAB.NET.Arrays;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using ZhangJianTaoProj.Provider;
using zjtMatlab;

namespace ZhangJianTaoProj
{
    /// <summary>
    /// Location.xaml 的交互逻辑
    /// </summary>
    public partial class Location : UserControl
    {
        public Location()
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(CalcParamProvider.SensorPos))
            {
                string[] sersorPos = CalcParamProvider.SensorPos.Split(';');
                PosA.Text = sersorPos[0];
                PosB.Text = sersorPos[1];
                PosC.Text = sersorPos[2];
            }
        }
        public void setStartEnable()
        {
            Start.IsEnabled = true;
        }
        public void setStartDisEnable()
        {
            Start.IsEnabled = false;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            setStartEnable();
            if (CalcParamProvider.isHadLocationData)
            {
                showCalcView();
            }
            else
            {
                clearView();
                if (!CalcParamProvider.isHadCeXiangData)
                {
                    setStartDisEnable();
                }
            }
        }
        private bool checkNums(List<string> pos)
        {
            foreach (var item in pos)
            {
                Regex regex = new Regex("(\\d+(\\.{1})\\d+)|(\\d+)");
                if (!regex.IsMatch(item))
                    return false;
            }
            return true;
        }
        private bool checkInputPos(List<string> posA, List<string> posB, List<string> posC)
        {
            string positionA = PosA.Text.Replace("，", ",");
            string positionB = PosB.Text.Replace("，", ",");
            string positionC = PosC.Text.Replace("，", ",");
            posA.AddRange(positionA.Split(','));
            posB.AddRange(positionB.Split(','));
            posC.AddRange(positionC.Split(','));
            if (posA.Count == 3 && posB.Count == 3 && posC.Count == 3 && checkNums(posA) && checkNums(posB) && checkNums(posC))
                return true;
            else
                return false;
        }
        private void showCalcView()
        {
            LocatonInfo1.Text = string.Format("坐标X,Y,Z：{0:N2},{1:N2},{2:N2}", CalcParamProvider.LocationResList[0], CalcParamProvider.LocationResList[1], CalcParamProvider.LocationResList[2]);
            LocatonInfo2.Text = string.Format("坐标X,Y,Z：{0:N2},{1:N2},{2:N2}", CalcParamProvider.LocationResList[3], CalcParamProvider.LocationResList[4], CalcParamProvider.LocationResList[5]);
            res1.Source = CalcParamProvider.getMemroyImg(@"./Location/1.jpg");

        }
        private async Task<List<double>> locationCalc(double[] data, double[] p1, double[] p2, double[] p3)
        {
            return await Task.Run(() =>
            {
                List<double> res = new List<double>(3);
                try
                {
                    using (NoiseReduce re = new NoiseReduce())
                    {
                        MWNumericArray mwNumArray = data;
                        MWNumericArray mwNumP1 = p1;
                        MWNumericArray mwNumP2 = p2;
                        MWNumericArray mwNumP3 = p3;
                        MWArray[] resMwArrays = re.Location(2, mwNumArray, mwNumP1, mwNumP2, mwNumP3);
                        foreach (var item in resMwArrays)
                        {
                            Array array = item.ToArray();
                            for (int i = 0; i < item.NumberOfElements; i++)
                            {
                                res.Add((double)array.GetValue(0, i));
                            }
                        }
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Default.Error("定位计算错误", ex);
                    return res;
                }
            });
        }
        private double[] convertListStrToArrayDouble(List<string> list)
        {
            List<double> res = new List<double>();
            foreach (var item in list)
            {
                res.Add(Convert.ToDouble(item));
            }
            return res.ToArray();
        }
        private void clearView()
        {
            LocatonInfo1.Text = "";
            LocatonInfo2.Text = "";
            res1.Source = null;
        }
        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            List<string> posA = new List<string>();
            List<string> posB = new List<string>();
            List<string> posC = new List<string>();
            if (!checkInputPos(posA, posB, posC))
            {
                MessageBox.Show("请输入坐标，\",\"为分隔符");
                return;
            }
            CalcParamProvider.LocationResList.Clear();
            CalcParamProvider.isHadLocationData = false;
            CalcParamProvider.SensorPos = string.Format("{0};{1};{2}", PosA.Text, PosB.Text, PosB.Text);
            setStartDisEnable();
            Start.Content = "正在处理数据，大约需要1分钟";
            clearView();
            StartProgress.Visibility = Visibility.Visible;
            List<double> locationData = new List<double>();
            CalcParamProvider.totalModels.ForEach(item => locationData.AddRange(item.ceXiangRes));
            try
            {
                CalcParamProvider.LocationResList = await locationCalc(locationData.ToArray(), convertListStrToArrayDouble(posA), convertListStrToArrayDouble(posB), convertListStrToArrayDouble(posC));
            }
            catch (Exception ex)
            {
                Logger.Default.Error("计算出错", ex);
                MessageBox.Show("计算出错");
            }
            CalcParamProvider.saveLocationResData();
            Start.Content = "开始计算";
            Start.IsEnabled = true;
            showCalcView();
            StartProgress.Visibility = Visibility.Hidden;
            CalcParamProvider.isHadLocationData = true;
        }
    }
}
