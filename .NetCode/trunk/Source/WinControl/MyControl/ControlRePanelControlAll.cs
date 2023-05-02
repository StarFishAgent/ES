using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinControl.MyControl;

namespace WinControl
{
    public partial class RePanelControlAll : UserControl
    {
        public RePanelControlAll()
        {
            InitializeComponent();
        }
        private List<char> Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();
        /// <summary>
        ///新增富文本框(问答题)
        /// </summary>
        public void AddRichBoxEdit()
        {
            RichBoxEdit richBoxEdit = new RichBoxEdit();
            StarFishPanel.Controls.Add(richBoxEdit);//窗体添加控件
            this.Height = this.Height += 180;
            StarFishPanel.Height = StarFishPanel.Height += 180;
        }
        /// <summary>
        /// 添加选项Pro(多选)
        /// </summary>
        ///  /// <param name="time">循环次数</param>
        public void AddOptionPro(int time = 1)
        {
            for (int count = 0; count < time; count++)
            {
                RichBoxPro controlRichBox = new RichBoxPro();

                StarFishPanel.Controls.Add(controlRichBox);//窗体添加控件

                for (int times = 0; times < StarFishPanel.Controls.Count; times++)
                {
                    var ControlPro = (StarFishPanel.Controls[times] as RichBoxPro);

                    (ControlPro.Controls[0] as CheckEdit).Text = Alpha[times].ToString();
                }


                this.Height = this.Height += 160;
                StarFishPanel.Height = StarFishPanel.Height += 160;
            }
        }
        /// <summary>
        ///  Single(单选)
        /// </summary>
        /// <param name="time">循环次数</param>
        public void AddOptionSingle(int time = 1)
        {
            for (int count = 0; count < time; count++)
            {

                RichBoxSingle controlRichBoxSingle = new RichBoxSingle();

                StarFishPanel.Controls.Add(controlRichBoxSingle);//窗体添加控件

                for (int times = 0; times < StarFishPanel.Controls.Count; times++)
                {
                    var ControlPro = (StarFishPanel.Controls[times] as RichBoxSingle);

                    (ControlPro.Controls[0] as RadioButton).Text = Alpha[times].ToString();
                }


                this.Height = this.Height += 160;
                StarFishPanel.Height = StarFishPanel.Height += 160;
            }
        }
        /// <summary>
        /// 判断题
        /// </summary>
        /// <param name="time">循环次数</param>
        public void AddOptionIstrue(int time = 1)
        {
            for (int count = 0; count < time; count++)
            {
                ISTrueOrFalse iSTrueOrFalse = new ISTrueOrFalse();

                StarFishPanel.Controls.Add(iSTrueOrFalse);//窗体添加控件

                this.Height = this.Height += 190;
                StarFishPanel.Height = StarFishPanel.Height += 190;
            }
        }
        /// <summary>
        /// 问答题
        /// </summary>
        /// <param name="time">循环次数</param>
        public void AddOptionAsk(int time = 1)
        {
            for (int count = 0; count < time; count++)
            {
                RichBoxEdit richBoxEdit = new RichBoxEdit();

                StarFishPanel.Controls.Add(richBoxEdit);//窗体添加控件

                this.Height = this.Height += 210;
                StarFishPanel.Height = StarFishPanel.Height += 210;
            }
        }
        /// <summary>
        /// 填空题
        /// </summary>
        /// <param name="time">循环次数</param>
        public void AddOptionInput(int time = 1)
        {
            for (int count = 0; count < time; count++)
            {
                RichBoxEdit richBoxEdit = new RichBoxEdit();
                StarFishPanel.Controls.Add(richBoxEdit);//窗体添加控件

                this.Height = this.Height += 210;
                StarFishPanel.Height = StarFishPanel.Height += 210;
            }
        }
        #region 删除清除控件
        /// <summary>
        /// 清除控件
        /// </summary>
        public void Clear()
        {
            StarFishPanel.Controls.Clear();
            ChangeFormHeight();
        }
        /// <summary>
        /// 设置控件初始高度
        /// </summary>
        public void ChangeFormHeight()
        {
            this.Height = 315 + 80;

            this.StarFishPanel.Height = 0;
        }
        /// <summary>
        /// 清空答案和解析
        /// </summary>
        public void ClearAnswerControl()
        {
        }
        
        #endregion

    }
}
