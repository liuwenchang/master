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
    /// JiangZao.xaml 的交互逻辑
    /// </summary>
    public partial class JiangZao : UserControl
    {
        public JiangZao()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (CalcParamProvider.isHadCeXiangData)
            {
                ShowPic.imgA1 = CalcParamProvider.getMemroyImg(CalcParamProvider.totalModels[0].getImgPath(CalcParam.ModelType.JiangZao)[0]);
                ShowPic.imgA2 = CalcParamProvider.getMemroyImg(CalcParamProvider.totalModels[0].getImgPath(CalcParam.ModelType.JiangZao)[1]);
                ShowPic.imgB1 = CalcParamProvider.getMemroyImg(CalcParamProvider.totalModels[1].getImgPath(CalcParam.ModelType.JiangZao)[0]);
                ShowPic.imgB2 = CalcParamProvider.getMemroyImg(CalcParamProvider.totalModels[1].getImgPath(CalcParam.ModelType.JiangZao)[1]);
                ShowPic.imgC1 = CalcParamProvider.getMemroyImg(CalcParamProvider.totalModels[2].getImgPath(CalcParam.ModelType.JiangZao)[0]);
                ShowPic.imgC2 = CalcParamProvider.getMemroyImg(CalcParamProvider.totalModels[2].getImgPath(CalcParam.ModelType.JiangZao)[1]);
            }
            else
            {
                ShowPic.clearPic();
            }
        }
    }
}
