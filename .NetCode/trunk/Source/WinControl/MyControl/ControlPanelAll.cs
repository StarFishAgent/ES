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
        #region Switch 科目模板
        //var ValueType = cmbType.EditValue.ToString();
        //    switch (ValueType)
        //    {
        //        case "单选题":
        //            {
        //                break;
        //            }
        //        case "多选题":
        //            {
        //                break;
        //            }
        //        case "判断题":
        //            {
        //                break;
        //            }
        //        case "填空题":
        //            {
        //                break;
        //            }
        //        case "问答题":
        //            {
        //                break;
        //            }
        //    }
        #endregion
        #region 添加控件
        private List<char> Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();//数组
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
        /// 清空答案和解析
        /// </summary>
        public void ClearAnswerControl()
        {
            (GetAnalysisControl().Controls[1] as RichBoxEdit).SetnullText();
            (GetAnalysisControl().Controls[0] as RichBoxEdit).SetnullText();
        }
        #region 删除
        /// <summary>
        /// 删除控件
        /// </summary>
        /// <param name="height">删除时减少的高度</param>
        public void DeleteOp(int height)
        {
            for (int i = 0; i < StarFishPanel.Controls.Count; i++)
            {

                if (StarFishPanel.Controls.Count - 1 == i)
                {
                    IsDelete();
                    StarFishPanel.Controls.RemoveAt(i);
                    this.Height -= height;
                    StarFishPanel.Height = StarFishPanel.Height -= height;
                }
            }
        }
        /// <summary>
        /// 删除选项(通用)
        /// </summary>
        public void DeleteOption()
        {
            var ValueType = cmbType.EditValue.ToString();
            switch (ValueType)
            {
                case "单选题":
                    {
                        DeleteOp(160);
                        break;
                    }
                case "多选题":
                    {
                        DeleteOp(160);
                        break;
                    }
                case "判断题":
                    {
                        DeleteOp(190);
                        break;
                    }
                case "填空题":
                    {
                        DeleteOp(210);
                        break;
                    }
                case "问答题":
                    {
                        DeleteOp(210);
                        break;
                    }
            }

        }
        #endregion
        #endregion
        #endregion
        #region 获取值
        #region 单选题
        #region RichBox
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
        public List<byte[]> GetRichTextSingleRtfText()
        {
            List<byte[]> Result = new List<byte[]>();
            var count = StarFishPanel.Controls.Count;//控件数量
            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxSingle);
                var text = (Control_All.Controls[1] as RichEditControl).RtfText.ToRtxBytes();
                Result.Add(text);
            }
            return Result;
        }
        #endregion
        #region RadioButton
        /// <summary>
        /// 获取选项中的RadioButton的Check值
        /// </summary>
        /// <returns></returns>
        public List<bool> GetRadioButtonCheckValue()
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
        /// <summary>
        /// 获取选项中的RadioButton的Text值
        /// </summary>
        /// <returns></returns>
        public List<string> GetRadioButtonTextValue()
        {
            List<string> Result = new List<string>();

            var count = StarFishPanel.Controls.Count;//控件数量

            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxSingle);
                var check = (Control_All.Controls[0] as RadioButton).Text;
                Result.Add(check);
            }
            return Result;
        }
        #endregion
        #endregion
        #region 多选题
        #region CheckBox
        /// <summary>
        /// 获取选项中的CheckEdit的Checked值
        /// </summary>
        /// <returns></returns>
        public List<bool> GetCheckEditValue()
        {
            List<bool> Result = new List<bool>();

            var count = StarFishPanel.Controls.Count;//控件数量

            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxPro);
                var check = (Control_All.Controls[0] as CheckEdit).Checked;
                Result.Add(check);
            }
            return Result;
        }
        /// <summary>
        /// 获取选项中的CheckEditText的值
        /// </summary>
        public List<string> GetCheckEditText()
        {
            List<string> Result = new List<string>();

            var count = StarFishPanel.Controls.Count;//控件数量

            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxPro);

                Result.Add((Control_All.Controls[0] as CheckEdit).Text);

            }
            return Result;
        }
        /// <summary>
        /// 获取选项中的CheckEdit的值
        /// </summary>
        /// <param name="StarFishPanel">大控件</param>
        /// <param name="panelControl">解析控件</param>
        public void GetCheckEditText(FlowLayoutPanel StarFishPanel, PanelControl panelControl)
        {
            if (StarFishPanel == null || panelControl == null)
            {

            }
            else
            {
                List<string> Result = new List<string>();

                var count = StarFishPanel.Controls.Count;//控件数量

                for (int i = 0; i < count; i++)
                {
                    var Control_All = (StarFishPanel.Controls[i] as RichBoxPro);
                    if ((Control_All.Controls[0] as CheckEdit).Checked == true)
                    {
                        Result.Add((Control_All.Controls[0] as CheckEdit).Text);
                    }
                }
                SetAddRangeAnswer(Result, panelControl);
            }
        }
        #endregion
        #region RichBox
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
        public List<byte[]> GetRichTextProRtfText()
        {
            List<byte[]> Result = new List<byte[]>();
            var count = StarFishPanel.Controls.Count;//控件数量
            for (int i = 0; i < count; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxPro);
                var text = (Control_All.Controls[1] as RichEditControl).RtfText.ToRtxBytes();
                Result.Add(text);
            }
            return Result;
        }
        #endregion
        #endregion
        #region 判断题
        #region RadioButton
        /// <summary>
        /// 获取判断题是否正确(错误)
        /// </summary>
        /// <param name="StarFishPanel">选项容器</param>
        /// <param name="panelControl">答案解析容器</param>
        public void GetIsRadioButtonText(FlowLayoutPanel StarFishPanel, PanelControl panelControl)
        {
            if (StarFishPanel == null || panelControl == null)
            {

            }
            else
            {
                var Control_All = (StarFishPanel.Controls[0] as ISTrueOrFalse);
                if ((Control_All.Controls[0] as RadioButton).Checked == true)
                {
                    SetAnswerText(((Control_All.Controls[0] as RadioButton).Text), panelControl);
                }
                else if ((Control_All.Controls[1] as RadioButton).Checked == true)
                {
                    SetAnswerText(((Control_All.Controls[1] as RadioButton).Text), panelControl);
                }
            }

        }
        #endregion
        #endregion
        #region 问答题·填空题
        #region RichTextBox
        /// <summary>
        /// 获取富文本框控件值Text
        /// </summary>
        /// <returns></returns>
        public List<string> GetRichBoxText()
        {
            List<string> Result = new List<string>();
            var count = StarFishPanel.Controls.Count;//控件数量
            for (int i = 0; i < count; i++)
            {
                Result.Add((StarFishPanel.Controls[i] as RichBoxEdit).GetText());
            }
            return Result;
        }
        /// <summary>
        /// 获取富文本框控件值RtfText
        /// </summary>
        /// <returns></returns>
        public List<byte[]> GetRichBoxRtfText()
        {
            List<byte[]> Result = new List<byte[]>();
            var count = StarFishPanel.Controls.Count;//控件数量
            for (int i = 0; i < count; i++)
            {
                Result.Add((StarFishPanel.Controls[i] as RichBoxEdit).GetRtfText().ToRtxBytes());
            }
            return Result;
        }
        #endregion
        #endregion
        #region 解析
        /// <summary>
        /// 获取解析控件里面的PanelControl
        /// </summary>
        /// <returns></returns>
        public PanelControl GetAnalysisControl()
        {
            return (panelControlAnswer1.Controls[0] as PanelControl);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="panelControl"></param>
        /// <returns></returns>
        public PanelControl GetAnalysisControl(PanelControl panelControl)
        {
            return (panelControl.Controls[0] as PanelControl);
        }
        /// <summary>
        /// 获取答案文本框值
        /// </summary>
        /// <param name="text"></param>
        /// <param name="controlAnswer"></param>
        public string GetTextAnswer()
        {
            return (GetAnalysisControl().Controls[1] as RichBoxEdit).GetText().ToString();
        }
        /// <summary>
        /// 获取答案文本框Rtf值
        /// </summary>
        /// <param name="text"></param>
        /// <param name="controlAnswer"></param>
        public byte[] GetRtfTextAnswer()
        {
            return (GetAnalysisControl().Controls[1] as RichBoxEdit).GetText().ToRtxBytes();
        }
        /// <summary>
        /// 获取解析文本框值
        /// </summary>
        /// <param name="controlAnswer"></param>
        public string GetTextAnalysis()
        {
            return (GetAnalysisControl().Controls[0] as RichBoxEdit).GetText().ToString();
        }
        /// <summary>
        /// 获取解析文本框Rtf值
        /// </summary>
        /// <param name="controlAnswer"></param>
        public byte[] GetRtfTextAnalysis()
        {
            return (GetAnalysisControl().Controls[0] as RichBoxEdit).GetRtfText().ToRtxBytes();
        }
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

            Helper.GetControlAnswer = GetControlAnswer(GetAnalysisControl());
        }
        #endregion
        #region 窗体容器
        public int GetStarFishPanelControlCount()
        {
            return StarFishPanel.Controls.Count;
        }
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
        /// 
        /// </summary>
        /// <param name="IsEnable">是否允许修改</param>
        public void SetAnswerTF(bool IsEnable)
        {
            ((panelControlAnswer1.Controls[0] as PanelControl).Controls[1] as RichBoxEdit).Enabled = IsEnable;
        }
        /// <summary>
        /// 设置解析值(Rtf)
        /// </summary>
        /// <param name="str"></param>
        public void SetRtfTextAnalysis(string str)
        {
            (GetAnalysisControl().Controls[0] as RichBoxEdit).SetRtfText(str);
        }
        /// <summary>
        /// 设置答案AddRange
        /// </summary>
        /// <param name="str"></param>
        public void SetAddRangeAnswer(List<string> str, PanelControl panelControl)
        {
            (panelControl.Controls[1] as RichBoxEdit).AddRange(str);
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
        /// 设置题目类型
        /// </summary>
        /// <param name="Type"></param>
        public void SetcmbTypeValue(string Type)
        {
            cmbType.EditValue = Type;
        }

        /// <summary>
        /// 设置单选控件是否选择值
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
        /// 选中题目并在答案文本框上面显示(单选多选判断等)
        /// </summary>
        public void SetAnswerText(string text, PanelControl panelControl)
        {
            var ControlPro = (panelControl.Controls[1] as RichBoxEdit);
            ControlPro.SetText(text);
        }

        /// <summary>
        /// 设置答案为空值(单选题)
        /// </summary>
        /// <param name="controlAnswer"></param>
        public void SetNullTextAnswer(PanelControl panelControl)
        {
            var ControlPro = (panelControl.Controls[1] as RichBoxEdit);
            ControlPro.SetnullText();
        }

        /// <summary>
        /// 设置答案文本框的值
        /// </summary>
        public void SetAnswerText(string str)
        {
            (GetAnalysisControl().Controls[1] as RichBoxEdit).SetText(str);
        }

        /// <summary>
        /// 设置答案文本框的Rtf值
        /// </summary>
        public void SetRtfAnswerText(string Rtfstr)
        {
            (GetAnalysisControl().Controls[1] as RichBoxEdit).SetRtfText(Rtfstr);
        }
        #endregion
        #region 判断值
        /// <summary>
        /// 是否可以删除
        /// </summary>
        public void IsDelete()
        {
            var ValueType = cmbType.EditValue.ToString();
            switch (ValueType)
            {
                case "单选题":
                    {
                        var controlAnswer = (panelControlAnswer1.Controls[0] as PanelControl);
                        var controlAnswertext = Convert.ToString((controlAnswer.Controls[1] as RichBoxEdit).GetText());
                        var layoutPanelCount = (StarFishPanel.Controls.Count);
                        var Control_All = (StarFishPanel.Controls[layoutPanelCount - 1] as RichBoxSingle);
                        var check = (Control_All.Controls[0] as RadioButton).Text;
                        if (controlAnswertext == check)
                        {
                            SetNullTextAnswer(GetControlAnswer(GetAnalysisControl()));
                        }
                        break;
                    }
                case "多选题":
                    {
                        var controlAnswer = (panelControlAnswer1.Controls[0] as PanelControl);
                        var controlAnswertext = Convert.ToString((controlAnswer.Controls[1] as RichBoxEdit).GetText());
                        var layoutPanelCount = (StarFishPanel.Controls.Count);
                        var Control_All = (StarFishPanel.Controls[layoutPanelCount - 1] as RichBoxPro);
                        var check = (Control_All.Controls[0] as CheckEdit).Text;
                        if (controlAnswertext == check)
                        {
                            SetNullTextAnswer(GetControlAnswer(GetAnalysisControl()));
                        }
                        break;
                    }
                case "判断题":
                    {
                        SetNullTextAnswer(GetControlAnswer(GetAnalysisControl()));
                        break;
                    }
                case "填空题":
                    {
                        break;
                    }
                case "问答题":
                    {
                        break;
                    }
            }

        }
        #region RichBoxEdit
        /// <summary>
        /// 设置RichBoxEditRtfText值
        /// </summary>
        /// <param name="str">RtfText</param>
        public void SetRichBoxEditRtfValues(List<string> str)
        {
            var EditBoxCount = StarFishPanel.Controls.Count;

            for (int i = 0; i < EditBoxCount; i++)
            {
                (StarFishPanel.Controls[i] as RichBoxEdit).SetRtfText(str[i]);

            }
        }
        /// <summary>
        /// 设置RichBoxEditRtfText值
        /// </summary>
        /// <param name="str">RtfText</param>
        public void SetRichBoxEditTextValues(List<string> str)
        {
            var EditBoxCount = StarFishPanel.Controls.Count;

            for (int i = 0; i < EditBoxCount; i++)
            {
                (StarFishPanel.Controls[i] as RichBoxEdit).SetText(str[i]);

            }
        }
        #endregion
        #region RichBoxSingle
        /// <summary>
        /// 设置RichBoxSingle的值
        /// </summary>
        /// <param name="str"></param>
        public void SetRichBoxSingleValues(List<string> str, List<bool> bol)
        {
            var SingleBoxCount = StarFishPanel.Controls.Count;

            for (int i = 0; i < SingleBoxCount; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxSingle);
                (Control_All.Controls[1] as RichEditControl).Text = str[i];
                (Control_All.Controls[0] as RadioButton).Checked = bol[i];
            }
        }
        /// <summary>
        /// 设置RichBoxSingle的Rtf值
        /// </summary>
        /// <param name="str"></param>
        public void SetRichBoxSingleRtfValues(List<string> Rtfstr, List<bool> bol)
        {
            var SingleBoxCount = StarFishPanel.Controls.Count;

            for (int i = 0; i < SingleBoxCount; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxSingle);
                (Control_All.Controls[1] as RichEditControl).RtfText = Rtfstr[i];
                (Control_All.Controls[0] as RadioButton).Checked = bol[i];
            }
        }
        #endregion
        #region RichBoxPro
        /// <summary>
        /// 设置RichBoxPro的值
        /// </summary>
        /// <param name="str"></param>
        public void SetRichBoxProValues(List<string> str, List<bool> bol)
        {
            var SingleBoxCount = StarFishPanel.Controls.Count;

            for (int i = 0; i < SingleBoxCount; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxPro);
                (Control_All.Controls[1] as RichEditControl).Text = str[i];
                (Control_All.Controls[0] as CheckEdit).Checked = bol[i];
            }
        }
        /// <summary>
        /// 设置RichBoxPro的Rtf值
        /// </summary>
        /// <param name="str"></param>
        public void SetRichBoxProRtfValues(List<string> Rtfstr, List<bool> bol)
        {
            var SingleBoxCount = StarFishPanel.Controls.Count;

            for (int i = 0; i < SingleBoxCount; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as RichBoxPro);
                (Control_All.Controls[1] as RichEditControl).RtfText = Rtfstr[i];
                (Control_All.Controls[0] as CheckEdit).Checked = bol[i];
            }
        }
        #endregion
        #region 判断题
        /// <summary>
        /// 设置判断题题目值
        /// </summary>
        /// <param name="is_correct"></param>
        public void SetRBTrueOrFalseValues(string is_correct)
        {
            var SingleBoxCount = StarFishPanel.Controls.Count;

            for (int i = 0; i < SingleBoxCount; i++)
            {
                var Control_All = (StarFishPanel.Controls[i] as ISTrueOrFalse);
                if (is_correct == "正确")
                {
                    (Control_All.Controls[1] as RadioButton).Checked = true;
                }
                else
                {
                    (Control_All.Controls[0] as RadioButton).Checked = false;
                }
            }
        }
        #endregion
        #endregion
        #region 按钮事件
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ValueType = cmbType.EditValue.ToString();
            switch (ValueType)
            {
                case "单选题":
                    {
                        if (StarFishPanel.Controls.Count >= 26)
                        {
                            MessageBox.Show("最多只能添加26个选项");
                            return;
                        }
                        this.AddOptionSingle();
                        return;
                    }
                case "多选题":
                    {
                        if (StarFishPanel.Controls.Count >= 26)
                        {
                            MessageBox.Show("最多只能添加26个选项");
                            return;
                        }
                        this.AddOptionPro();
                        return;
                    }
                case "判断题":
                    {
                        if (StarFishPanel.Controls.Count >= 1)
                        {
                            MessageBox.Show("最多只能添加1个选项");
                            return;
                        }
                        this.AddOptionIstrue();
                        return;
                    }
                case "填空题":
                    {
                        if (StarFishPanel.Controls.Count >= 5)
                        {
                            MessageBox.Show("最多只能添加5个选项");
                            return;
                        }
                        this.AddOptionInput();
                        return;
                    }
                case "问答题":
                    {
                        if (StarFishPanel.Controls.Count >= 5)
                        {
                            MessageBox.Show("最多只能添加5个选项");
                            return;
                        }
                        this.AddOptionAsk();
                        return;
                    }

            }
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ValueType = cmbType.EditValue.ToString();
            switch (ValueType)
            {
                case "单选题":
                    {
                        if (StarFishPanel.Controls.Count <= 2)
                        {
                            MessageBox.Show("最少要保留2个选项");
                            return;
                        }
                        this.DeleteOption();
                        return;
                    }
                case "多选题":
                    {
                        if (StarFishPanel.Controls.Count <= 2)
                        {
                            MessageBox.Show("最少要保留2个选项");
                            return;
                        }
                        this.DeleteOption();
                        return;
                    }
                case "判断题":
                    {
                        if (StarFishPanel.Controls.Count <= 1)
                        {
                            MessageBox.Show("最少要保留1个选项");
                            return;
                        }
                        this.DeleteOption();
                        return;
                    }
                case "填空题":
                    {
                        if (StarFishPanel.Controls.Count <= 1)
                        {
                            MessageBox.Show("最少要保留1个选项");
                            return;
                        }
                        this.DeleteOption();
                        return;
                    }
                case "问答题":
                    {
                        if (StarFishPanel.Controls.Count <= 1)
                        {
                            MessageBox.Show("最少要保留1个选项");
                            return;
                        }
                        this.DeleteOption();
                        return;
                    }
            }

        }
        #endregion
        #region 值改变
        /// <summary>
        /// 题目类型切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_EditValueChanged(object sender, EventArgs e)
        {
            var ValueType = cmbType.EditValue.ToString();
            if (StarFishPanel.Controls.Count <= 0)
            {
                return;
            }
            else
            {
                switch (ValueType)
                {
                    case "单选题":
                        {
                            ClearAnswerControl();
                            this.Clear();
                            this.AddOptionSingle(4);
                            SetAnswerTF(false);
                            break;
                        }
                    case "多选题":
                        {
                            ClearAnswerControl();
                            this.Clear();
                            this.AddOptionPro(4);
                            SetAnswerTF(false);
                            break;
                        }
                    case "判断题":
                        {
                            ClearAnswerControl();
                            this.Clear();
                            this.AddOptionIstrue(1);
                            SetAnswerTF(false);
                            break;
                        }
                    case "填空题":
                        {
                            ClearAnswerControl();
                            this.Clear();
                            this.AddOptionInput(1);
                            SetAnswerTF(true);
                            break;
                        }
                    case "问答题":
                        {
                            ClearAnswerControl();
                            this.Clear();
                            this.AddOptionAsk(1);
                            SetAnswerTF(true);
                            break;
                        }
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

        }


        #endregion


    }
}
