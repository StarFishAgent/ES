using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace WinControl.MyControl
{
    public static class Helper
    {
        public static FlowLayoutPanel GetPanel;
        public static PanelControl GetControlAnswer;
        /// <summary>
        /// RtxStr To Byte[] 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToRtxBytes(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return default;
            else
            {
                try
                {
                    return Encoding.UTF8.GetBytes(str);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return default;
                }
            }
        }

        /// <summary>
        /// OBJ To String Object 转 String
        /// </summary>
        /// <param name="obj">任何类型变量</param>
        /// <returns></returns>
        public static string ToRtxBytesString(this object obj) {
            if (obj is byte[]) {
                if (obj == default)
                    return default;
                else {
                    try {
                        return Encoding.UTF8.GetString((byte[])obj);
                    }
                    catch (Exception ex) {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        return null;
                    }
                }
            }
            return default;
        }

    }
    public enum ControlType
    {


        /// <summary>
        /// 单选 SingleChoice
        /// </summary>
        单选题 = 0,

        /// <summary>
        /// 多选 MultipleChoice
        /// </summary>
        多选题 = 1,

        /// <summary>
        /// 判断 Judge
        /// </summary>
        判断题 = 2,

        /// <summary>
        /// 填空 Completion
        /// </summary>
        填空题 = 3,

        /// <summary>
        /// 问答 QuestionsAndAnswers
        /// </summary>
        问答题 = 4,
    }
}
