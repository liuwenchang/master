using MahApps.Metro.Controls;
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
using ZhangJianTaoProj.Model;
using ZhangJianTaoProj.Provider;
using zjtMatlab;

namespace ZhangJianTaoProj
{
    /// <summary>
    /// InputData.xaml 的交互逻辑
    /// </summary>
    public partial class InputData : UserControl
    {

        public delegate void CalcEnd(bool isHadData);
        public event CalcEnd CalcEnd_Handle;
        public InputData()
        {
            InitializeComponent();
        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                if (sender == OpenFileA)
                {
                    this.SelectedFileA.Text = dialog.FileName;
                    CalcParamProvider.totalModels.Insert(0,new CalcParam(dialog.FileName, 1));
                }
                if (sender == OpenFileB)
                {
                    this.SelectedFileB.Text = dialog.FileName;
                    CalcParamProvider.totalModels.Insert(1, new CalcParam(dialog.FileName, 2));
                }
                if (sender == OpenFileC)
                {
                    CalcParamProvider.totalModels.Insert(2, new CalcParam(dialog.FileName, 3));
                    this.SelectedFileC.Text = dialog.FileName;
                }
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (CalcParamProvider.isHadCeXiangData)
            {
                setResImgSource();
                this.SelectedFileA.Text = CalcParamProvider.totalModels[0].DataPath;
                this.SelectedFileB.Text = CalcParamProvider.totalModels[1].DataPath;
                this.SelectedFileC.Text = CalcParamProvider.totalModels[2].DataPath;

            }
            else
            {
                setResImgNull();
            }

        }
        private bool CheckModelIsInit()
        {
            if (CalcParamProvider.totalModels.Count < CalcParamProvider.totalModelsMinCount)
                return false;
            foreach (var item in CalcParamProvider.totalModels)
            {
                if (item == null)
                    return false;
            }
            return true;
        }
        private async Task<bool> calc(CalcParam model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    int ceXiangResCount = 4;
                    using (NoiseReduce re = new NoiseReduce())
                    {
                        re.InputData(model.DataPath, model.Index);
                        re.DoubleDataExp(model.DataPath, model.Index);
                        MWArray[] angle = re.Direct(ceXiangResCount, model.DataPath, model.Index);
                        for (int i = 0; i < ceXiangResCount; i++)
                        {
                            double t = Convert.ToDouble(angle[i].ToString());
                            model.ceXiangRes.Add(t);
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Default.Error("数据导入计算错误", ex);
                    return false;
                }
            });
        }
        private void clearOldData()
        {
            CalcParamProvider.isHadCeXiangData = false;
            CalcParamProvider.isHadLocationData = false;
            CalcParamProvider.CeXiangResList.Clear();
            CalcParamProvider.LocationResList.Clear();
        }
        private async void Start_Click(object sender, RoutedEventArgs e)
        {
             
            if (!CheckModelIsInit())
            {
                MessageBox.Show("请分别选择"+ CalcParamProvider.totalModelsMinCount + "组数据");
                return;
            }
            clearOldData();
            Start.Content = "正在处理数据，大约需要3分钟";
            Start.IsEnabled = false;
            setResImgNull();
            StartProgress.Visibility = Visibility.Visible;
            List<Task<bool>> tasks = new List<Task<bool>>();
            //tasks.Add(calc(totalModels[0]));
            //await Task.Run(() =>
            //{
            //    ParallelLoopResult res = Parallel.ForEach<Model>(totalModels, str =>
            //    {
            //        calc(str); //效率跟task差不多
            //    });
            //});
            foreach (var item in CalcParamProvider.totalModels)
            {
                tasks.Add(calc(item));
            }
            foreach (var item in tasks)
            {
               bool res = await item;
                if (!res)
                {
                    MessageBox.Show("计算出错");
                    Start.IsEnabled = true;
                    return;
                }
            }
            //angle.ArrayType
            //angle.ToArray().ge
            setResImgSource();
            CalcParamProvider.saveCeXiangData();
            Start.Content = "开始计算";
            Start.IsEnabled = true;
            StartProgress.Visibility = Visibility.Hidden;
            CalcParamProvider.isHadCeXiangData = true;
            CalcEnd_Handle?.Invoke(CalcParamProvider.isHadCeXiangData);
        }
        private void setResImgNull()
        {
            ShowPic.clearPic();
        }
        private void setResImgSource()
        {
            ShowPic.imgA1 = CalcParamProvider.getMemroyImg(CalcParamProvider.totalModels[0].getImgPath(CalcParam.ModelType.Input)[0]);
            ShowPic.imgB1 = CalcParamProvider.getMemroyImg(CalcParamProvider.totalModels[1].getImgPath(CalcParam.ModelType.Input)[0]);
            ShowPic.imgC1 = CalcParamProvider.getMemroyImg(CalcParamProvider.totalModels[2].getImgPath(CalcParam.ModelType.Input)[0]);
        }
    }
}
