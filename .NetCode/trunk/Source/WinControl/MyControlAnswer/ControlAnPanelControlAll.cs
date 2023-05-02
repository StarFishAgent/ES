using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using WinControl.MyControl;

namespace WinControl {
    public partial class AnPanelControlAll : UserControl {
        public AnPanelControlAll() {
            InitializeComponent();
        }

        private List<char> Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();
        /// <summary>
        ///新增富文本框(问答题)
        /// </summary>
        public void AddRichBoxEdit() {
            RichBoxEdit richBoxEdit = new RichBoxEdit();
            AnswerPanel.Controls.Add(richBoxEdit);//窗体添加控件
            this.Height = this.Height += 180;
            AnswerPanel.Height = AnswerPanel.Height += 180;
        }
        /// <summary>
        /// 添加选项Pro(多选)
        /// </summary>
        ///  /// <param name="time">循环次数</param>
        public void AddOptionPro(int time = 1) {
            for (int count = 0; count < time; count++) {
                RichBoxPro controlRichBox = new RichBoxPro();

                AnswerPanel.Controls.Add(controlRichBox);//窗体添加控件

                for (int times = 0; times < AnswerPanel.Controls.Count; times++) {
                    var ControlPro = (AnswerPanel.Controls[times] as RichBoxPro);

                    (ControlPro.Controls[0] as CheckEdit).Text = Alpha[times].ToString();
                }


                this.Height = this.Height += 135;//160改135
                AnswerPanel.Height = AnswerPanel.Height += 135;
            }
        }
        /// <summary>
        ///  Single(单选)
        /// </summary>
        /// <param name="time">循环次数</param>
        public void AddOptionSingle(List<string> RtfText, int time = 1, DataRow OptionRow = null) {
            for (int count = 0; count < time; count++) {

                AnRichBoxSingle controlRichBoxSingle = new AnRichBoxSingle();
                AnswerPanel.Controls.Add(controlRichBoxSingle);//窗体添加控件
                var times = AnswerPanel.Controls.Count - 1;
                var ControlSingle = (AnswerPanel.Controls[times] as AnRichBoxSingle);
                ControlSingle.SetRtfText(RtfText[count]);
                var Controlradiobtn = (ControlSingle.Controls[0] as RadioButton);
                Controlradiobtn.Text = Alpha[times].ToString();
                if(OptionRow != null) {
                    Controlradiobtn.Checked = Convert.ToBoolean(OptionRow[$"{Alpha[times].ToString()}"]);
                }
                this.Height = this.Height += 110;
                AnswerPanel.Height = AnswerPanel.Height += 110;
            }
        }
        public (DataTable, Dictionary<int, string>) GetOptionInfo(string guid, int id, DataTable OptionInfo, Dictionary<int, string> listABCD) {
            var times = AnswerPanel.Controls.Count - 1;
            var ControlSingle = (AnswerPanel.Controls[times] as AnRichBoxSingle);
            return ControlSingle.GetRadioButtonCheckedValue(AnswerPanel,guid, id, OptionInfo, listABCD);
        }
        /// <summary>
        /// 判断题
        /// </summary>
        /// <param name="time">循环次数</param>
        public void AddOptionIstrue(int time = 1) {
            for (int count = 0; count < time; count++) {
                ISTrueOrFalse iSTrueOrFalse = new ISTrueOrFalse();

                AnswerPanel.Controls.Add(iSTrueOrFalse);//窗体添加控件

                this.Height = this.Height += 190;
                AnswerPanel.Height = AnswerPanel.Height += 190;
            }
        }
        /// <summary>
        /// 问答题
        /// </summary>
        /// <param name="time">循环次数</param>
        public void AddOptionAsk(int time = 1) {
            for (int count = 0; count < time; count++) {
                RichBoxEdit richBoxEdit = new RichBoxEdit();

                AnswerPanel.Controls.Add(richBoxEdit);//窗体添加控件

                this.Height = this.Height += 210;
                AnswerPanel.Height = AnswerPanel.Height += 210;
            }
        }
        /// <summary>
        /// 填空题
        /// </summary>
        /// <param name="time">循环次数</param>
        public void AddOptionInput(int time = 1) {
            for (int count = 0; count < time; count++) {
                RichBoxEdit richBoxEdit = new RichBoxEdit();
                AnswerPanel.Controls.Add(richBoxEdit);//窗体添加控件

                this.Height = this.Height += 210;
                AnswerPanel.Height = AnswerPanel.Height += 210;
            }
        }
        #region 删除清除控件
        /// <summary>
        /// 清除控件
        /// </summary>
        public void Clear() {
            AnswerPanel.Controls.Clear();
            ChangeFormHeight();
        }
        /// <summary>
        /// 设置控件初始高度
        /// </summary>
        public void ChangeFormHeight() {
            this.Height = 315 + 80;

            this.AnswerPanel.Height = 0;
        }
        /// <summary>
        /// 清空答案和解析
        /// </summary>
        public void ClearAnswerControl() {
        }

        #endregion

        private void AnswerPanel_Enter(object sender, EventArgs e) {
            Helper.GetPanel = GetAnswerPanel(AnswerPanel);
        }
        public FlowLayoutPanel GetAnswerPanel(FlowLayoutPanel layoutPanel) {
            var control_values = layoutPanel;
            return control_values;
        }
    }
}
