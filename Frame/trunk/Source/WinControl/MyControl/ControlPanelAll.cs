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

namespace WinControl.MyControl
{
    public partial class PanelControlAll : UserControl
    {
        public PanelControlAll()
        {
            InitializeComponent();
            SetcmbValue();
        }
        #region 添加控件
        private List<char> Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();//数组
        /// <summary>
        ///新增富文本框
        /// </summary>
        public void AddRichBoxEdit()
        {
            this.Height += 100;
            RichBoxEdit richBoxEdit = new RichBoxEdit();
            richBoxEdit.Size = new Size(738, 150);

            StarFishPanel.Controls.Add(richBoxEdit);//窗体添加控件
        }
        /// <summary>
        /// 添加选项Pro(多选)
        /// </summary>
        public void AddOptionPro(int a = 1)
        {
            for (int b = 0; b < a; b++)
            {
                this.Height += 100;
                RichBoxPro controlRichBox = new RichBoxPro();
                controlRichBox.Size = new Size(1043, 129);

                StarFishPanel.Controls.Add(controlRichBox);//窗体添加控件
                var count = StarFishPanel.Controls.Count;//控件数量

                for (int i = 0; i < count; i++)
                {

                    var ControlPro = (StarFishPanel.Controls[i] as RichBoxPro);

                    (ControlPro.Controls[0] as CheckEdit).Text = Alpha[i].ToString();

                }
            }
        }
        /// <summary>
        /// Single(单选)
        /// </summary>
        public void AddOptionSingle(int a = 1)
        {
            for (int b = 0; b < a; b++)
            {
                this.Height += 130;
                RichBoxSingle controlRichBoxSingle = new RichBoxSingle();
                controlRichBoxSingle.Size = new Size(1043, 129);

                StarFishPanel.Controls.Add(controlRichBoxSingle);//窗体添加控件

                var count = StarFishPanel.Controls.Count;//控件数量

                for (int i = 0; i < count; i++)
                {

                    var ControlPro = (StarFishPanel.Controls[i] as RichBoxSingle);

                    (ControlPro.Controls[0] as RadioButton).Text = Alpha[i].ToString();
                }
            }
        }
        /// <summary>
        /// 清除控件
        /// </summary>
        public void Clear()
        {
            StarFishPanel.Controls.Clear();
        }
        /// <summary>
        /// 删除选项(通用)
        /// </summary>
        public void DeleteOption()
        {
            for (int i = 0; i < StarFishPanel.Controls.Count; i++)
            {

                if (StarFishPanel.Controls.Count - 1 == i)
                {
                    IsDelete(Helper.GetControlAnswer, Helper.GetPanel);
                    StarFishPanel.Controls.RemoveAt(i);
                    this.Height -= 152;
                    StarFishPanel.Height = StarFishPanel.Height - 152;
                }
            }
        }
        #endregion
        #region 获取值
        #region 单选题
        /// <summary>
        /// 获取单选题文本框的值（Text）
        /// </summary>
        public List<string> GetRichTextSingleText()
        {
            List<string> Result = new List<string>();
            var count = StarFishPanel.Controls.Count;//控件数量
            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxSingle);
                var text = (Control_All.Controls[1] as RichEditControl).Text;
                Result.Add(text);
            }
            return Result;
        }
        /// <summary>
        /// 获取单选题文本框的值（Rtf）
        /// </summary>
        public List<string> GetRichTextSingleRtfText()
        {
            List<string> Result = new List<string>();
            var count = StarFishPanel.Controls.Count;//控件数量
            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxSingle);
                var text = (Control_All.Controls[1] as RichEditControl).RtfText;
                Result.Add(text);
            }
            return Result;
        }
        /// <summary>
        /// 获取选项中的RadioButton的值
        /// </summary>
        /// <returns></returns>
        public List<bool> GetRadioButtonValue()
        {
            List<bool> Result = new List<bool>();

            var count = StarFishPanel.Controls.Count;//控件数量

            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxSingle);
                var check = (Control_All.Controls[0] as RadioButton).Checked;
                Result.Add(check);
            }
            return Result;
        }
        #endregion
        #region 多选题
        /// <summary>
        /// 获取选项中的CheckBox的值
        /// </summary>
        /// <returns></returns>
        public List<bool> GetCheckBoxValue()
        {
            List<bool> Result = new List<bool>();

            var count = StarFishPanel.Controls.Count;//控件数量

            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxPro);
                var check = (Control_All.Controls[0] as CheckBox).Checked;
                Result.Add(check);
            }
            return Result;
        }
        /// <summary>
        /// 获取多选题文本框的值
        /// </summary>
        public List<string> GetRichTextProText()
        {
            List<string> Result = new List<string>();
            var count = StarFishPanel.Controls.Count;//控件数量
            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxPro);
                var text = (Control_All.Controls[1] as RichEditControl).Text;
                Result.Add(text);
            }
            return Result;
        }
        /// <summary>
        /// 获取多选题文本框的Rtf值
        /// </summary>
        public List<string> GetRichTextProRtfText()
        {
            List<string> Result = new List<string>();
            var count = StarFishPanel.Controls.Count;//控件数量
            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxPro);
                var text = (Control_All.Controls[1] as RichEditControl).RtfText;
                Result.Add(text);
            }
            return Result;
        }
        #endregion
        #region 判断题

        #endregion
        #region 控件barmanger
        /// <summary>
        /// 获取题目类型
        /// </summary>
        /// <returns></returns>
        public string GetcmbTypeValue()
        {
            var Result = "";
            Result = cmbType.EditValue.ToString();
            return Result;
        }
        #endregion
        #region 窗体
        /// <summary>
        /// 获取容器是否处于活动状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StarFishPanel_Enter(object sender, EventArgs e)
        {
            Helper.GetPanel = GetStarFishPanel(StarFishPanel);
            Helper.GetControlAnswer = GetControlAnswer(panelControl1);
        }
        #endregion
        #region 窗体容器
        /// <summary>
        /// 获取容器FlowLayoutPanel
        /// </summary>
        /// <param name="layoutPanel"></param>
        /// <returns></returns>
        public FlowLayoutPanel GetStarFishPanel(FlowLayoutPanel layoutPanel)
        {
            var control_values = layoutPanel;
            return control_values;
        }
        /// <summary>
        /// 获取容器PanelControl
        /// </summary>
        /// <param name="controlAnswer"></param>
        /// <returns></returns>
        public PanelControl GetControlAnswer(PanelControl controlAnswer)
        {
            var control_values = controlAnswer;
            return control_values;
        }
        #endregion
        #endregion
        #region 设置值
        /// <summary>
        /// 设置下拉控件的值
        /// </summary>
        public void SetcmbValue()
        {
            string[] str = new string[] { "单选题", "多选题", "判断题", "填空题", "问答题" };
            ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)cmbType.Edit).Items.AddRange(str);
            cmbType.EditValue = ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)cmbType.Edit).Items[0];
        }
        /// <summary>
        /// 设置题目编号
        /// </summary>
        /// <param name="num"></param>
        public void SetlblValue(int num)
        {
            lblView.Caption = "第" + num + "题";
        }
        /// <summary>
        /// 设置单选控件值
        /// </summary>
        /// <param name="StarFishPanel"></param>
        public void SetRadioButtonChecked(FlowLayoutPanel StarFishPanel)
        {
            var count = StarFishPanel.Controls.Count;//控件数量

            for (int i = 0; i < count; i++)
            {

                var ControlPro = (StarFishPanel.Controls[i] as RichBoxSingle);

                (ControlPro.Controls[0] as RadioButton).Checked = false;

            }
        }
        /// <summary>
        /// 选中题目并在答案文本框上面显示
        /// </summary>
        public void SetTextAnswer(string text, PanelControl controlAnswer)
        {
            var ControlPro = (controlAnswer.Controls[1] as RichBoxEdit);
            ControlPro.SetText(text);
        }
        /// <summary>
        /// 设置答案为空值
        /// </summary>
        /// <param name="controlAnswer"></param>
        public void SetNullTextAnswer(PanelControl controlAnswer)
        {
            var ControlPro = (controlAnswer.Controls[1] as RichBoxEdit);
            ControlPro.SetnullText();
        }
        #endregion
        #region 判断值
        /// <summary>
        /// 是否可以删除
        /// </summary>
        public void IsDelete(PanelControl controlAnswer, FlowLayoutPanel layoutPanel)
        {
            var controlAnswertext = (controlAnswer.Controls[1] as RichBoxEdit).GetText().ToString();
            var layoutPanelCount = (layoutPanel.Controls.Count);
            var Control_All = (StarFishPanel.Controls[layoutPanelCount - 1] as RichBoxSingle);
            var check = (Control_All.Controls[0] as RadioButton).Text;
            if (controlAnswertext == check)
            {
                SetNullTextAnswer(controlAnswer);
            }
        }
        #endregion
        #region 按钮事件
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cmbType.EditValue.ToString() == "单选题")
            {
                if (StarFishPanel.Controls.Count >= 26)
                {
                    MessageBox.Show("最多只能添加26个选项");
                    return;
                }
                this.Height += 152;
                StarFishPanel.Height = StarFishPanel.Height + 152;
                this.AddOptionSingle();
                return;
            }
            if (cmbType.EditValue.ToString() == "多选题")
            {
                if (StarFishPanel.Controls.Count >= 26)
                {
                    MessageBox.Show("最多只能添加26个选项");
                    return;
                }
                this.AddOptionPro();
                return;
            }
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StarFishPanel.Controls.Count <= 2)
            {
                MessageBox.Show("最少要保留2个选项");
                return;
            }
            this.DeleteOption();
            return;
        }
        #endregion
        #region 值改变
        /// <summary>
        /// 下拉框值更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_EditValueChanged(object sender, EventArgs e)
        {
            if (StarFishPanel.Controls.Count <= 0)
            {
                return;
            }
            else
            {
                if (cmbType.EditValue.ToString() == "单选题")
                {
                    this.Clear();
                    this.AddOptionSingle(4);
                }
                if (cmbType.EditValue.ToString() == "多选题")
                {
                    this.Clear();
                    this.AddOptionPro(4);
                }
            }
        }
        #endregion
        #region 窗体
        /// <summary>
        /// 加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelControlAll_Load(object sender, EventArgs e)
        {
            this.Height = 315 + 60;
        }
        #endregion


    }
}
