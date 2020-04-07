using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ZhangJianTaoProj.Model;
using System.Configuration;
namespace ZhangJianTaoProj.Provider
{
    class CalcParamProvider
    {
        public static bool isHadCeXiangData;
        public static bool isHadLocationData;
        public static int totalModelsMinCount;
        public static List<CalcParam> totalModels;
        public static List<double> CeXiangResList = new List<double>();
        public static List<double> LocationResList = new List<double>();
        public static string SensorPos = string.Empty;
        static CalcParamProvider()
        {
            totalModelsMinCount = 3;
            isHadCeXiangData = false;
            isHadLocationData = false;
            totalModels = new List<CalcParam>();
            string path = ConfigurationManager.AppSettings["Path"];
            string ceXiangRes = ConfigurationManager.AppSettings["CeXiangRes"];
            string locationRes = ConfigurationManager.AppSettings["LocationRes"];
            SensorPos = ConfigurationManager.AppSettings["SensorPos"];
            if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(ceXiangRes))
                return;
            string[] paths = path.Split(';');
            string[] CeXiangResTemp = ceXiangRes.Split(';');
            string[] LocationResTemp = locationRes.Split(';');
            int t = 1;
            foreach (var item in paths)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                if (!File.Exists(item))
                {
                    totalModels.Clear();
                    isHadCeXiangData = false;
                    return;
                }
                else
                {
                    totalModels.Add(new CalcParam(item, t++));
                    isHadCeXiangData = true;
                }
            }
            foreach (var item in CeXiangResTemp)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                CeXiangResList.Add(Convert.ToDouble(item));
            }
            int modelIndex = 0;
            foreach (var item in totalModels)
            {
                item.ceXiangRes.AddRange(CeXiangResList.Where((temp, index) => index >= modelIndex * 4 && index < (modelIndex + 1) * 4));
            }
            if (!string.IsNullOrWhiteSpace(locationRes))
            {
                isHadLocationData = true;
                foreach (var item in LocationResTemp)
                {
                    if (string.IsNullOrWhiteSpace(item))
                        continue;
                    LocationResList.Add(Convert.ToDouble(item));
                }
            }
        }
        public static void saveCeXiangData()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            StringBuilder paths = new StringBuilder();
            totalModels.ForEach(item => paths.AppendFormat("{0};", item.DataPath));
            if (paths.Length > 0)
            {
                paths.Remove(paths.Length - 1, 1);
            }
            StringBuilder ceXiangStringBuilder = new StringBuilder();
            foreach (var item in totalModels)
            {
                item.ceXiangRes.ForEach(temp => ceXiangStringBuilder.AppendFormat("{0:N2};", temp));
            }

            //LocationResList.ForEach(item => templocationRes.AppendFormat("{0:N2};", item));
            if (ceXiangStringBuilder.Length > 0)
            {
                ceXiangStringBuilder.Remove(ceXiangStringBuilder.Length - 1, 1);
            }
            cfa.AppSettings.Settings["Path"].Value = paths.ToString();
            cfa.AppSettings.Settings["CeXiangRes"].Value = ceXiangStringBuilder.ToString();
            cfa.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void saveLocationResData()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            StringBuilder locationStringBuilder = new StringBuilder();
            LocationResList.ForEach(item => locationStringBuilder.AppendFormat("{0:N2};", item));
            if (locationStringBuilder.Length > 0)
            {
                locationStringBuilder.Remove(locationStringBuilder.Length - 1, 1);
            }
            cfa.AppSettings.Settings["SensorPos"].Value = SensorPos;
            cfa.AppSettings.Settings["LocationRes"].Value = locationStringBuilder.ToString();
            cfa.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static BitmapImage getMemroyImg(string path)
        {
            if (!File.Exists(path))
                return null;
            var img1 = new BitmapImage();
            img1.BeginInit();
            img1.StreamSource = new MemoryStream(File.ReadAllBytes(path));
            img1.EndInit();
            return img1;
        }
    }
}
