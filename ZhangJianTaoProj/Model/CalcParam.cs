using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZhangJianTaoProj.Model
{
    /// <summary>
    /// liuwenchang
    /// </summary>
    public class CalcParam
    {
        public static string InputDataImgDir = "daoRuShuJu";
        public static string JiangZaoImgDir = "jiangzao";
        public static string CeXiangImgDir = "Direct";
        public static string DingWeiImgDir = "Location";
        public enum ModelType { Input, JiangZao, CeXiang, DingWei }
        public string DataPath { get; set; }
        public int Index { get; set; }

        public List<double> ceXiangRes;
        public CalcParam() { }
        public CalcParam(string dataPath, int index)
        {
            this.DataPath = dataPath;
            this.Index = index;
            ceXiangRes = new List<double>(4);
        }
        public static string DingWeiImgPath = string.Format(@"./{0}/1.jpg", DingWeiImgDir);
        public List<string> getImgPath(ModelType Type)
        {
            List<string> resList = new List<string>(2);
            switch (Type)
            {
                case ModelType.Input:
                    resList.Add(string.Format(@"./{0}/{1}1.jpg", InputDataImgDir, Index));
                    break;
                case ModelType.JiangZao:
                    resList.Add(string.Format(@"./{0}/{1}1.jpg", JiangZaoImgDir, Index));
                    resList.Add(string.Format(@"./{0}/{1}2.jpg", JiangZaoImgDir, Index));
                    break;
                case ModelType.CeXiang:
                    resList.Add(string.Format(@"./{0}/{1}1.jpg", CeXiangImgDir, Index));
                    resList.Add(string.Format(@"./{0}/{1}2.jpg", CeXiangImgDir, Index));
                    break;
            }
            return resList;
        }
        
    }
}
