using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinControl.MyControl
{
    public partial class RichBoxEdit : UserControl
    {
        public RichBoxEdit()
        {
            InitializeComponent();
        }
        #region 获取值
        /// <summary>
        /// 获取文本Text
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            return richEditControl1.Text;
        }
        /// <summary>
        /// 获取Rtf文本
        /// </summary>
        /// <returns></returns>
        public string GetRtfText()
        {
            return richEditControl1.RtfText;
        }
        #endregion
        #region 设置值
        /// <summary>
        /// 设置Text
        /// </summary>
        /// <param name="str"></param>
        public void SetText(string str)
        {
            richEditControl1.Text = str;
        }
        /// <summary>
        /// 设置空文本
        /// </summary>
        public void SetnullText()
        {
            richEditControl1.Text = "";
            richEditControl1.Text = null;
        }
        /// <summary>
        /// 设置Rtf文本
        /// </summary>
        /// <param name="obj"></param>
        public void SetRtfText(object obj)
        {
            richEditControl1.RtfText = obj.ToString();
        }
        /// <summary>
        /// 添加数组的值进入富文本框
        /// </summary>
        /// <param name="str"></param>
        public void AddRange(List<string> str)
        {
            SetnullText();
            for (int i = 0; i < str.Count; i++)
            {
                richEditControl1.Text += str[i];
            }
        }

        #endregion
    }
}
