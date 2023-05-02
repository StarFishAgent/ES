using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;

using WinControl.MyControl;

namespace WinClient
{
    public partial class FrmExamAddSelect : XtraForm
    {
        /// <summary>
        /// 添加题目选项窗体
        /// </summary>
        public FrmExamAddSelect()
        {
            InitializeComponent();
            #region 常用代码
            //AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
            #region 窗体初始化
            Format();
            #endregion
        }
        #region 获取值
        /// <summary>
        /// 题目内容 
        /// </summary>
        string value_exam_content;
        /// <summary>
        /// 大题主键
        /// </summary>
        string value_guid;
        /// <summary>
        /// 子题guid
        /// </summary>
        string value_child_guid;
        /// <summary>
        /// 子题类型
        /// </summary>
        string value_subject_child_type;
        /// <summary>
        /// 是否编辑
        /// </summary>
        bool is_edit = false;
        /// <summary>
        /// 是否增加
        /// </summary>
        bool is_Plus = false;
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="value_guid"></param>
        /// <param name="value_exam_content"></param>
        public FrmExamAddSelect(string value_guid, string value_exam_content) : this()
        {
            this.value_guid = value_guid;
            this.value_exam_content = value_exam_content;
        }
        #endregion
        #region 单选设置值
        /// <summary>
        /// 单选设置值
        /// </summary>
        /// <param name="AllCount">控件数量</param>
        /// <param name="Content">题目内容</param>
        /// <param name="is_cottect">是否正确答案</param>
        public void SetValueSingle(int AllCount, List<string> Content, List<bool> is_cottect)
        {
            var control = (LayoutPanelAll.Controls[AllCount] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
            control.SetRichBoxSingleRtfValues(Content, is_cottect);
        }
        #endregion
        #region 多选设置值
        /// <summary>
        /// 多选设置值
        /// </summary>
        /// <param name="AllCount">控件数量</param>
        /// <param name="Content">题目内容</param>
        /// <param name="is_cottect">是否正确答案</param>
        public void SetValuePro(int AllCount, List<string> Content, List<bool> is_cottect)
        {
            var control = (LayoutPanelAll.Controls[AllCount] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
            control.SetRichBoxProRtfValues(Content, is_cottect);
        }
        #endregion
        #region 判断题设置值
        public void SetValueIsCheck(string is_cottect)
        {
            var control = (LayoutPanelAll.Controls[0] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
            control.SetRBTrueOrFalseValues(is_cottect);
        }
        #endregion
        #region 问答题填空题设置值
        public void SetValueInputAsk(int AllCount, List<string> Content)
        {
            var control = (LayoutPanelAll.Controls[AllCount] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
            control.SetRichBoxEditRtfValues(Content);
        }
        #endregion
        #region 解析设置值
        /// <summary>
        /// 设置解析值
        /// </summary>
        /// <param name="AllCount"></param>
        /// <param name="Answer"></param>
        public void SetAnalysisValue(int AllCount, string Answer)
        {
            var control = (LayoutPanelAll.Controls[AllCount] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
            control.SetRtfTextAnalysis(Answer);
        }
        /// <summary>
        /// 设置答案文本框值
        /// </summary>
        /// <param name="AllCount"></param>
        /// <param name="Answer"></param>
        public void SetAnswerValue(int AllCount, string Answer)
        {
            var GetControl = (LayoutPanelAll.Controls[AllCount] as PanelControlAll);
            GetControl.SetAnswerText(Answer);
        }
        #endregion
        #region 查询选项信息
        /// <summary>
        /// 获取子题选项选项数量
        /// </summary>
        /// <param name="value_guid"></param>
        /// <returns></returns>
        public int SelectChildOptionCount(string value_guid)
        {
            return "select * from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid".ExecuteQuery(("@subject_child_guid", value_guid)).Rows.Count;

        }
        /// <summary>
        /// 获取子题选项信息
        /// </summary>
        /// <param name="value_guid">主键</param>
        /// <returns></returns>
        public DataTable SelectChildOptionInfo(string value_guid)
        {
            return "select * from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid order by ruid asc".ExecuteQuery(("@subject_child_guid", value_guid));
        }
        /// <summary>
        /// 获取所有选项内容
        /// </summary>
        /// <param name="value_guid"></param>
        /// <returns></returns>
        public List<string> SelectContent(string value_guid)
        {
            List<string> Result = new List<string>();
            var dt_child_Option_Content = "select * from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid order by ruid asc".ExecuteQuery(("@subject_child_guid", value_guid));
            if (dt_child_Option_Content != null && dt_child_Option_Content.Rows.Count > 0)
            {
                foreach (DataRow item in dt_child_Option_Content.Rows)
                {
                    Result.Add(item["option_content"].ToString());
                }
            }
            return Result;
        }
        /// <summary>
        /// 获取所有选项内容
        /// </summary>
        /// <param name="value_guid"></param>
        /// <returns></returns>
        public List<string> SelectRtfContent(string value_guid)
        {
            List<string> Result = new List<string>();
            var dt_child_Option_Content = "select * from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid order by ruid asc".ExecuteQuery(("@subject_child_guid", value_guid));
            if (dt_child_Option_Content != null && dt_child_Option_Content.Rows.Count > 0)
            {
                foreach (DataRow item in dt_child_Option_Content.Rows)
                {
                    Result.Add(Convert.FromBase64String(item["option_content2"].ToString()).ToRtxBytesString());
                }
            }
            return Result;
        }
        /// <summary>
        /// 查找正确答案
        /// </summary>
        /// <param name="value_guid"></param>
        /// <returns></returns>
        public string SelectCorrectAnswer(string value_guid, int times)
        {
            var dt_child_Option_Content = "select * from SubjectChildInfo where subject_guid=@subject_guid order by ruid asc".ExecuteQuery(("@subject_guid", value_guid));

            return Convert.ToString(dt_child_Option_Content.Rows[times]["subject_child_answer"]);
        }
        /// <summary>
        /// 查询选项数量
        /// </summary>
        /// <param name="value_guid"></param>
        /// <returns></returns>
        public int? SelectControlsCount(string subject_child_guid)
        {
            return "select * from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid".ExecuteQuery(("@subject_child_guid", subject_child_guid)).Rows.Count;
        }
        /// <summary>
        /// 子题数量
        /// </summary>
        /// <param name="value_guid"></param>
        /// <returns></returns>
        public int? SelectChildControlCount(string value_guid)
        {
            return "select * from SubjectChildInfo where subject_guid=@subject_guid".ExecuteQuery(("@subject_guid", value_guid)).Rows.Count;
        }
        /// <summary>
        /// 子题控件信息
        /// </summary>
        /// <param name="value_guid"></param>
        /// <returns></returns>
        public DataTable SelectControlInfo(string value_guid)
        {
            return "select * from SubjectChildInfo where subject_guid=@subject_guid order by ruid asc".ExecuteQuery(("@subject_guid", value_guid));
        }
        /// <summary>
        /// 是否正确
        /// </summary>
        /// <param name="value_guid"></param>
        /// <returns></returns>
        public List<bool> SelectISCorrect(string value_guid)
        {
            List<bool> Result = new List<bool>();
            var dt_child_Option_Content = "select * from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid order by ruid asc".ExecuteQuery(("@subject_child_guid", value_guid));
            if (dt_child_Option_Content != null && dt_child_Option_Content.Rows.Count > 0)
            {
                foreach (DataRow item in dt_child_Option_Content.Rows)
                {
                    Result.Add(Convert.ToBoolean(item["is_correct"]));
                }
            }
            return Result;
        }
        #endregion
        #region 题目类型
        /// <summary>
        /// 初始化
        /// </summary>
        public void Format()
        {//子题目类型（0：单选题；1：多选题；2：判断题；3：填空题；4：问答题）
            //string[] str = new string[] { "单选题", "多选题", "判断题", "填空题", "问答题" };
            //this.cmbType.Properties.Items.AddRange(str);
            //cmbType.SelectedIndex = 0;
            //var dt = "select exam_type from ExamTypeInfo order by ruid".ExecuteQuery();
            //{
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        var dr = dt.Rows;
            //        foreach (DataRow item in dr)
            //        {
            //            this.cmbType.Properties.Items.Add(item["exam_type"]);
            //        }
            //    }
            //}
            //this.cmbType.SelectedIndex = 0;
        }
        #endregion
        #region 窗体加载完成
        /// <summary>
        /// 窗体加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAdd_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
        #endregion
        #region 保存按钮事件
        #region 检查是否符合保存条件
        /// <summary>
        /// 问答题、填空题
        /// </summary>
        /// <returns></returns>
        public bool CheckSome()
        {
            var countPanelAll = LayoutPanelAll.Controls.Count; //控件数量

            for (int count = 0; count < countPanelAll; count++)//有多少个容器控件就循环多少次
            {
                var control = (LayoutPanelAll.Controls[count] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
                var ControlValue = control.GetRichBoxText();//获取控件中的文本
                var ControlAnswerValue = control.GetTextAnswer();///答案值
                var ControlAnalysisValue = control.GetTextAnalysis();//解析值
                var ControlValueCount = ControlValue.Count;//获取值的数量
                if (ControlAnswerValue != "" && ControlAnswerValue != null && ControlAnalysisValue != "" && ControlAnalysisValue != null)
                {
                    for (int i = 0; i < ControlValueCount; i++)
                    {
                        var item = ControlValue[i];
                        if (item != "" && item != null)
                        {

                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 检查是否符合保存条件
        /// </summary>
        public bool Check()
        {
            var countPanelAll = LayoutPanelAll.Controls.Count; //控件数量
            for (int count = 0; count < countPanelAll; count++)//有多少个容器控件就循环多少次
            {
                var control = (LayoutPanelAll.Controls[count] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
                var subject_type = control.GetcmbTypeValue();//获取题目类型
                switch (subject_type)
                {
                    case "单选题":
                        {
                            var ControlValue = control.GetRichTextSingleText();//获取控件中的文本
                            var ControlAnswerValue = control.GetTextAnswer();///答案值
                            var ControlAnalysisValue = control.GetTextAnalysis();//解析值
                            var ControlValueCount = ControlValue.Count;//获取值的数量
                            if (ControlAnswerValue != "" && ControlAnswerValue != null && ControlAnalysisValue != "" && ControlAnalysisValue != null)
                            {
                                for (int i = 0; i < ControlValueCount; i++)
                                {
                                    var item = ControlValue[i];
                                    if (item != "" && item != null)
                                    {

                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "多选题":
                        {

                            var ControlValue = control.GetRichTextProText();//获取控件中的文本
                            var ControlAnswerValue = control.GetTextAnswer();///答案值
                            var ControlAnalysisValue = control.GetTextAnalysis();//解析值
                            var ControlValueCount = ControlValue.Count;//获取值的数量
                            if (ControlAnswerValue != "" && ControlAnswerValue != null && ControlAnalysisValue != "" && ControlAnalysisValue != null)
                            {
                                for (int i = 0; i < ControlValueCount; i++)
                                {
                                    var item = ControlValue[i];
                                    if (item != "" && item != null)
                                    {

                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }

                            break;
                        }
                    case "判断题":
                        {
                            var ControlAnswerValue = control.GetTextAnswer();///答案值
                            var ControlAnalysisValue = control.GetTextAnalysis();//解析值
                            if (ControlAnswerValue != "" && ControlAnswerValue != null && ControlAnalysisValue != "" && ControlAnalysisValue != null)
                            {

                            }
                            break;
                        }
                    case "填空题":
                        {
                            var ControlValue = control.GetRichBoxText();//获取控件中的文本
                            var ControlAnswerValue = control.GetTextAnswer();///答案值
                            var ControlAnalysisValue = control.GetTextAnalysis();//解析值
                            var ControlValueCount = ControlValue.Count;//获取值的数量
                            if (ControlAnswerValue != "" && ControlAnswerValue != null && ControlAnalysisValue != "" && ControlAnalysisValue != null)
                            {
                                for (int i = 0; i < ControlValueCount; i++)
                                {
                                    var item = ControlValue[i];
                                    if (item != "" && item != null)
                                    {

                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "问答题":
                        {
                            var ControlValue = control.GetRichBoxText();//获取控件中的文本
                            var ControlAnswerValue = control.GetTextAnswer();///答案值
                            var ControlAnalysisValue = control.GetTextAnalysis();//解析值
                            var ControlValueCount = ControlValue.Count;//获取值的数量
                            if (ControlAnswerValue != "" && ControlAnswerValue != null && ControlAnalysisValue != "" && ControlAnalysisValue != null)
                            {
                                for (int i = 0; i < ControlValueCount; i++)
                                {
                                    var item = ControlValue[i];
                                    if (item != "" && item != null)
                                    {

                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                }
            }
            return true;
        }
        #endregion
        #region 新增
        #region 子题信息添加事件
        /// <summary>
        /// 子题信息添加事件
        /// </summary>
        /// <param name="subject_guid">题目主键</param>
        /// <param name="child_no">子题号</param>
        /// <param name="child_answer">子题答案(Text)</param>
        /// <param name="child_answer2">子题答案2(RtfText)</param>
        /// <param name="child_analysis">子题解析(Text)</param>
        /// <param name="child_analysis2">子题解析2(RtfText)</param>
        /// <param name="subject_type">子题类型</param>
        public void InsertChildInfo(string subject_guid, string child_no, string child_answer, byte[] child_answer2, string child_analysis, byte[] child_analysis2, int? subject_type)
        {
            $@"insert into SubjectChildInfo(subject_guid,subject_child_no,subject_child_answer,subject_child_answer2,subject_child_analysis,subject_child_analysis2,subject_child_type)values(@subject_guid,@subject_child_no,@subject_child_answer,@subject_child_answer2,@subject_child_analysis,@subject_child_analysis2,@subject_child_type)".ExecuteNonQuery(("@subject_guid", subject_guid, typeof(string).FullName), ("@subject_child_no", child_no, typeof(string).FullName), ("@subject_child_answer", child_answer, typeof(string).FullName), ("@subject_child_answer2", child_answer2, typeof(byte[]).FullName), ("@subject_child_analysis", child_analysis, typeof(string).FullName), ("@subject_child_analysis2", child_analysis2, typeof(byte[]).FullName), ("@subject_child_type", subject_type, typeof(int).FullName));//
        }
        #endregion
        #region 子题选项添加事件
        /// <summary>
        /// 子题选项添加事件
        /// </summary>
        /// <param name="subject_child_guid">子题guid</param>
        /// <param name="option_no">选项代号</param>
        /// <param name="option_content">选项内容</param>
        /// <param name="option_content2">选项内容2(Rtf)</param>
        /// <param name="is_correct">是否正确</param>
        public void InsertOptionInfo(string subject_child_guid, string option_no, string option_content, byte[] option_content2, bool is_correct)
        {
            $@"insert into SubjectChildOptionInfo(subject_child_guid,option_no,option_content,option_content2,is_correct)values(@subject_child_guid,@option_no,@option_content,@option_content2,@is_correct)".ExecuteNonQuery(("@subject_child_guid", subject_child_guid, typeof(string).FullName), ("@option_no", option_no, typeof(string).FullName), ("@option_content", option_content, typeof(string).FullName), ("@option_content2", option_content2, typeof(byte[]).FullName), ("@is_correct", is_correct, typeof(bool).FullName));
        }
        #endregion
        #region 问答题·填空题
        /// <summary>
        /// 类型判断转换
        /// </summary>
        /// <param name="Subject_type">类型</param>
        /// <returns></returns>
        public int? WhitchType(string Subject_type)
        {
            switch (Subject_type)
            {
                case "单选题":
                    {
                        return 0;
                    }
                case "多选题":
                    {

                        return 1;
                    }
                case "判断题":
                    {

                        return 2;
                    }
                case "填空题":
                    {

                        return 3;
                    }
                case "问答题":
                    {

                        return 4;
                    }
            }
            return null;
        }
        /// <summary>
        /// 添加子题信息(ALL)
        /// </summary>
        /// <param name="count">子题号</param>
        /// <param name="control">控件</param>
        /// <param name="subject_type">题目类型</param>
        public void AddSomeOfInfo(int count, PanelControlAll control, string subject_type)
        {

            var no_count = count;
            no_count++;//题号
            var child_no = "0" + no_count;//子题选项代号
            var child_answer = control.GetTextAnswer();///答案值
            var child_answer2 = control.GetRtfTextAnswer();///答案值
            var child_analysis = control.GetTextAnalysis();//解析值
            var child_analysis2 = control.GetRtfTextAnalysis();//解析值
            InsertChildInfo(value_guid, child_no, child_answer, child_answer2, child_analysis, child_analysis2, WhitchType(subject_type));
        }
        public void UpdateSomeOfInfo(int count, PanelControlAll control, string subject_type)
        {

            var no_count = count;
            no_count++;//题号
            var child_no = "0" + no_count;//子题选项代号
            var child_answer = control.GetTextAnswer();///答案值
            var child_answer2 = control.GetRtfTextAnswer();///答案值
            var child_analysis = control.GetTextAnalysis();//解析值
            var child_analysis2 = control.GetRtfTextAnalysis();//解析值
            InsertChildInfo(value_guid, child_no, child_answer, child_answer2, child_analysis, child_analysis2, WhitchType(subject_type));
        }
        /// <summary>
        /// 添加问答题·填空题子题选项信息
        /// </summary>
        /// <param name="subject_type">题目类型</param>
        /// <param name="count">子题号</param>
        /// <param name="control">控件</param>
        /// <param name="AllControlCount">所有子题选项数量</param>
        public void AddAskInput(string subject_type, int count, PanelControlAll control, int AllControlCount)
        {
            AddSomeOfInfo(count, control, subject_type);
            var ControlValue = control.GetRichBoxText();//获取控件中的文本
            var ControlRtfValue = control.GetRichBoxRtfText();//获取控件中的文本
            var dt_child_info = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));
            var dr_child_info = dt_child_info.Rows[count];
            value_child_guid = Convert.ToString(dr_child_info["guid"]);
            for (int i = 0; i < AllControlCount; i++)
            {
                var item = ControlValue[i];
                var Rtfitem = ControlRtfValue[i];
                InsertOptionInfo(value_child_guid, "", item, Rtfitem, false);
            }
        }
        /// <summary>
        /// 修改问答填空
        /// </summary>
        /// <param name="subject_type">题目类型</param>
        /// <param name="count">子题号</param>
        /// <param name="control">控件</param>
        /// <param name="AllControlCount">所有子题选项数量</param>
        public void UpdateAll(string subject_type, PanelControlAll control, int? times = null)
        {
            var child_answer = control.GetTextAnswer();///答案值
            var child_answer2 = control.GetRtfTextAnswer();///答案值
            var child_analysis = control.GetTextAnalysis();//解析值
            var child_analysis2 = control.GetRtfTextAnalysis();//解析值
            var AllControlCount = control.GetStarFishPanelControlCount();
            var dt_child_info = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));
            var dr_child_info = dt_child_info.Rows[Convert.ToInt32(times)];
            var value_get_guid = Convert.ToString(dr_child_info["guid"]);
            var dt_child_option_info = "select * from SubjectChildOptionInfo where subject_child_guid=@value_subject_child_guid order by ruid asc".ExecuteQuery(("@value_subject_child_guid", value_get_guid));
            switch (subject_type)
            {
                case "单选题":
                    {

                        UpdateChildInfo(value_get_guid, child_answer, child_answer2, child_analysis, child_analysis2, WhitchType(subject_type));
                        {
                            var ControlValue = control.GetRichTextSingleText();//获取控件中的txt文本()
                            var ControlboolValue = control.GetRadioButtonCheckValue();//获取Radio控件中的Check值
                            var ControlABCDValue = control.GetRadioButtonTextValue();//获取Radio控件中的Text文本
                            var ControlRtfValue = control.GetRichTextSingleRtfText();//获取控件中的Rtf文本
                            for (int items = 0; items < AllControlCount; items++)
                            {
                                var child_guid = Convert.ToString(dt_child_option_info.Rows[items]["guid"]);
                                var item = ControlValue[items];
                                var boolitem = ControlboolValue[items];
                                var RtfText = ControlRtfValue[items];
                                var ABCD = ControlABCDValue[items];
                                UpdateOptionInfo(child_guid, ABCD, item, RtfText, boolitem);
                            }
                        }
                        break;
                    }
                case "多选题":
                    {

                        UpdateChildInfo(value_get_guid, child_answer, child_answer2, child_analysis, child_analysis2, WhitchType(subject_type));
                        {
                            var ControlValue = control.GetRichTextProText();//获取控件中的txt文本()
                            var ControlboolValue = control.GetCheckEditValue();//获取Radio控件中的Check值
                            var ControlABCDValue = control.GetCheckEditText();//获取Radio控件中的Text文本
                            var ControlRtfValue = control.GetRichTextProRtfText();//获取控件中的Rtf文本
                            for (int items = 0; items < AllControlCount; items++)
                            {
                                var child_guid = Convert.ToString(dt_child_option_info.Rows[items]["guid"]);
                                var item = ControlValue[items];
                                var boolitem = ControlboolValue[items];
                                var RtfText = ControlRtfValue[items];
                                var ABCD = ControlABCDValue[items];
                                UpdateOptionInfo(child_guid, ABCD, item, RtfText, boolitem);
                            }
                        }
                        break;
                    }
                case "判断题":
                    {
                        UpdateChildInfo(value_get_guid, child_answer, child_answer2, child_analysis, child_analysis2, WhitchType(subject_type));
                        break;
                    }
                case "问答题":
                    {

                        UpdateChildInfo(value_get_guid, child_answer, child_answer2, child_analysis, child_analysis2, WhitchType(subject_type));
                        var ControlValue = control.GetRichBoxText();//获取控件中的文本
                        var ControlRtfValue = control.GetRichBoxRtfText();//获取控件中的文本
                        value_child_guid = Convert.ToString(dr_child_info["guid"]);
                        for (int items = 0; items < AllControlCount; items++)
                        {
                            var child_guid = Convert.ToString(dt_child_option_info.Rows[items]["guid"]);
                            var item = ControlValue[items];
                            var Rtfitem = ControlRtfValue[items];
                            UpdateOptionInfo(child_guid, item, Rtfitem, false);
                        }
                        break;
                    }
                case "填空题":
                    {

                        UpdateChildInfo(value_get_guid, child_answer, child_answer2, child_analysis, child_analysis2, WhitchType(subject_type));
                        var ControlValue = control.GetRichBoxText();//获取控件中的文本
                        var ControlRtfValue = control.GetRichBoxRtfText();//获取控件中的文本

                        value_child_guid = Convert.ToString(dr_child_info["guid"]);
                        for (int items = 0; items < AllControlCount; items++)
                        {
                            var child_guid = Convert.ToString(dt_child_option_info.Rows[items]["guid"]);
                            var item = ControlValue[items];
                            var Rtfitem = ControlRtfValue[items];
                            UpdateOptionInfo(child_guid, item, Rtfitem, false);
                        }
                        break;
                    }
            }

        }
        #endregion
        #endregion
        #region 编辑
        #region 子题信息编辑
        /// <summary>
        /// 子题信息表编辑
        /// </summary>
        /// <param name="subject_child_guid">子题guid</param>
        /// <param name="subject_child_answer">子题答案</param>
        /// <param name="subject_child_answer2">子题答案Rtf</param>
        /// <param name="subject_child_analysis">子题解析</param>
        /// <param name="subject_child_analysis2">子题解析Rtf</param>
        /// <param name="subject_child_type">子题类型</param>
        public void UpdateChildInfo(string subject_child_guid, string subject_child_answer, byte[] subject_child_answer2, string subject_child_analysis, byte[] subject_child_analysis2, int? subject_child_type)
        {
            $@"update SubjectChildInfo set subject_child_answer = @subject_child_answer, subject_child_answer2 = @subject_child_answer2, subject_child_analysis = @subject_child_analysis, subject_child_analysis2 = @subject_child_analysis2, subject_child_type = @subject_child_type where guid=@subject_child_guid".ExecuteNonQuery(("@subject_child_answer", subject_child_answer, typeof(string).FullName), ("@subject_child_answer2", subject_child_answer2, typeof(byte[]).FullName), ("@subject_child_analysis", subject_child_analysis, typeof(string).FullName), ("@subject_child_analysis2", subject_child_analysis2, typeof(byte[]).FullName), ("@subject_child_type", subject_child_type, typeof(int).FullName), ("@subject_child_guid", subject_child_guid, typeof(string).FullName));
        }
        /// <summary>
        /// 添加子题选项(是否增加选项)
        /// </summary>
        /// <param name="count">第几个子题</param>
        /// <param name="control">指定控件</param>
        /// <param name="AllControlCount">第几个选项开始循环</param>
        /// <param name="AddNowOption">从第几个选项开始添加</param>
        /// <param name="subject_type">考试类型(单选,问答...)</param>
        public void AddOption(int count, PanelControlAll control, int AllControlCount, int AddNowOption, string subject_type)
        {
            var Alltimes = AddNowOption + AllControlCount;
            switch (subject_type)//获取题目类型，添加指定选项
            {
                #region 单选题
                case "单选题":
                    {
                        var ControlValue = control.GetRichTextSingleText();//获取控件中的txt文本()
                        var ControlboolValue = control.GetRadioButtonCheckValue();//获取Radio控件中的Check值
                        var ControlABCDValue = control.GetRadioButtonTextValue();//获取Radio控件中的Text文本
                        var ControlRtfValue = control.GetRichTextSingleRtfText();//获取控件中的Rtf文本
                        var dt_child_info = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));
                        var dr_child_info = dt_child_info.Rows[count];
                        value_child_guid = Convert.ToString(dr_child_info["guid"]);

                        for (int i = AllControlCount; i < Alltimes; i++)
                        {
                            var item = ControlValue[i];
                            var boolitem = ControlboolValue[i];
                            var RtfText = ControlRtfValue[i];
                            var ABCD = ControlABCDValue[i];
                            InsertOptionInfo(value_child_guid, ABCD, item, RtfText, boolitem);
                        }
                        break;
                    }
                #endregion
                #region 多选题
                case "多选题":
                    {

                        var ControlValue = control.GetRichTextProText();//获取控件中的txt文本()
                        var ControlRtfValue = control.GetRichTextProRtfText();//获取控件中的Rtf文本
                        var ControlboolValue = control.GetCheckEditValue();//获取控Radio件中的Check值
                        var ControlABCDValue = control.GetCheckEditText();//获取Radio控件中的Text文本
                        var dt_child_info_guid = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));//查询子题目guid
                        var dr_child_info_guid = dt_child_info_guid.Rows[count];
                        value_child_guid = Convert.ToString(dr_child_info_guid["guid"]);//获取子题目guid
                        for (int i = AllControlCount; i < Alltimes; i++)
                        {
                            var item = ControlValue[i];
                            var boolitem = ControlboolValue[i];
                            var RtfText = ControlRtfValue[i];
                            var ABCD = ControlABCDValue[i];
                            InsertOptionInfo(value_child_guid, ABCD, item, RtfText, boolitem);//新增
                        }
                        break;
                    }
                #endregion
                #region 判断题
                case "判断题":
                    {
                        break;
                    }
                #endregion
                #region 填空题
                case "填空题":
                    {
                        var ControlValue = control.GetRichBoxText();//获取控件中的文本
                        var ControlRtfValue = control.GetRichBoxRtfText();//获取控件中的文本
                        var dt_child_info = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));
                        var dr_child_info = dt_child_info.Rows[count];
                        value_child_guid = Convert.ToString(dr_child_info["guid"]);
                        for (int i = AllControlCount; i < Alltimes; i++)
                        {
                            var item = ControlValue[i];
                            var Rtfitem = ControlRtfValue[i];
                            InsertOptionInfo(value_child_guid, "", item, Rtfitem, false);
                        }
                        break;
                    }
                #endregion
                #region 问答题
                case "问答题":
                    {
                        var ControlValue = control.GetRichBoxText();//获取控件中的文本
                        var ControlRtfValue = control.GetRichBoxRtfText();//获取控件中的文本
                        var dt_child_info = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));
                        var dr_child_info = dt_child_info.Rows[count];
                        value_child_guid = Convert.ToString(dr_child_info["guid"]);
                        for (int i = AllControlCount; i < Alltimes; i++)
                        {
                            var item = ControlValue[i];
                            var Rtfitem = ControlRtfValue[i];
                            InsertOptionInfo(value_child_guid, "", item, Rtfitem, false);
                        }
                        break;
                    }
                    #endregion
            }//创建控件
        }
        /// <summary>
        /// 添加子题选项
        /// </summary>
        /// <param name="count">第几个子题</param>
        /// <param name="control">指定控件</param>
        /// <param name="AllControlCount">第几个选项开始循环</param>
        /// <param name="subject_type">考试类型(单选,问答...)</param>
        public void AddOption(int count, PanelControlAll control, int AllControlCount, string subject_type)
        {

            switch (subject_type)//获取题目类型，添加指定选项
            {
                #region 单选题
                case "单选题":
                    {
                        var ControlValue = control.GetRichTextSingleText();//获取控件中的txt文本()
                        var ControlboolValue = control.GetRadioButtonCheckValue();//获取Radio控件中的Check值
                        var ControlABCDValue = control.GetRadioButtonTextValue();//获取Radio控件中的Text文本
                        var ControlRtfValue = control.GetRichTextSingleRtfText();//获取控件中的Rtf文本
                        var dt_child_info = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));
                        var dr_child_info = dt_child_info.Rows[count];
                        value_child_guid = Convert.ToString(dr_child_info["guid"]);
                        for (int i = 0; i < AllControlCount; i++)
                        {
                            var item = ControlValue[i];
                            var boolitem = ControlboolValue[i];
                            var RtfText = ControlRtfValue[i];
                            var ABCD = ControlABCDValue[i];
                            InsertOptionInfo(value_child_guid, ABCD, item, RtfText, boolitem);
                        }
                        break;
                    }
                #endregion
                #region 多选题
                case "多选题":
                    {

                        var ControlValue = control.GetRichTextProText();//获取控件中的txt文本()
                        var ControlRtfValue = control.GetRichTextProRtfText();//获取控件中的Rtf文本
                        var ControlboolValue = control.GetCheckEditValue();//获取控Radio件中的Check值
                        var ControlABCDValue = control.GetCheckEditText();//获取Radio控件中的Text文本
                        var dt_child_info_guid = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));//查询子题目guid
                        var dr_child_info_guid = dt_child_info_guid.Rows[count];
                        value_child_guid = Convert.ToString(dr_child_info_guid["guid"]);//获取子题目guid
                        for (int i = 0; i < AllControlCount; i++)
                        {
                            var item = ControlValue[i];
                            var boolitem = ControlboolValue[i];
                            var RtfText = ControlRtfValue[i];
                            var ABCD = ControlABCDValue[i];
                            InsertOptionInfo(value_child_guid, ABCD, item, RtfText, boolitem);//新增
                        }
                        break;
                    }
                #endregion
                #region 判断题
                case "判断题":
                    {
                        AddSomeOfInfo(count, control, subject_type);
                        break;
                    }
                #endregion
                #region 填空题
                case "填空题":
                    {
                        AddAskInput(subject_type, count, control, AllControlCount);
                        break;
                    }
                #endregion
                #region 问答题
                case "问答题":
                    {
                        AddAskInput(subject_type, count, control, AllControlCount);
                        break;
                    }
                    #endregion
            }//创建控件


        }
        #region 子题选项编辑
        /// <summary>
        /// 问答填空题
        /// </summary>
        /// <param name="subject_child_guid">子题选项guid</param>
        /// <param name="option_content">题目内容</param>
        /// <param name="option_content2">题目内容Rtf</param>
        /// <param name="is_correct">是否正确(正确答案)</param>
        public void UpdateOptionInfo(string subject_child_guid, string option_content, byte[] option_content2, bool is_correct)
        {
            $@"update SubjectChildOptionInfo set option_content = @option_content , option_content2 = @option_content2 , is_correct = @is_correct where guid=@subject_child_guid".ExecuteNonQuery(("@option_content", option_content, typeof(string).FullName), ("@option_content2", option_content2, typeof(byte[]).FullName), ("@is_correct", is_correct, typeof(bool).FullName), ("@subject_child_guid", subject_child_guid, typeof(string).FullName));
        }
        /// <summary>
        /// 选择题
        /// </summary>
        /// <param name="subject_child_guid"></param>
        /// <param name="Option_no"></param>
        /// <param name="option_content"></param>
        /// <param name="option_content2"></param>
        /// <param name="is_correct"></param>
        public void UpdateOptionInfo(string subject_child_guid, string Option_no, string option_content, byte[] option_content2, bool is_correct)
        {
            $@"update SubjectChildOptionInfo set option_content = @option_content ,Option_no=@Option_no, option_content2 = @option_content2 , is_correct = @is_correct where guid=@subject_child_guid".ExecuteNonQuery(("@option_content", option_content, typeof(string).FullName), ("@Option_no", Option_no, typeof(string).FullName), ("@option_content2", option_content2, typeof(byte[]).FullName), ("@is_correct", is_correct, typeof(bool).FullName), ("@subject_child_guid", subject_child_guid, typeof(string).FullName));
        }
        /// <summary>
        /// 更方便的编辑子题信息 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="subject_type"></param>
        public void UpdateCMFT(PanelControlAll control, string subject_type)
        {
            var child_answer = control.GetTextAnswer();///答案值
            var child_answer2 = control.GetRtfTextAnswer();///答案值
            var child_analysis = control.GetTextAnalysis();//解析值
            var child_analysis2 = control.GetRtfTextAnalysis();//解析值
            UpdateChildInfo(value_guid, child_answer, child_answer2, child_analysis, child_analysis2, WhitchType(subject_type));
        }
        #endregion
        #endregion
        #endregion
        #region 保存按钮点击事件
        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check() == false)
            {
                MessageBox.Show("题目格式异常，请检查后再保存");
                return;
            }
            switch (is_edit)
            {
                case false://新增
                    {
                        {
                            var countPanelAll = LayoutPanelAll.Controls.Count; //控件数量

                            for (int count = 0; count < countPanelAll; count++)//有多少个容器控件就循环多少次
                            {//每一次都获取所有文本框里面的值
                                var control = (LayoutPanelAll.Controls[count] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
                                var AllControlCount = control.GetStarFishPanelControlCount();//选项数量
                                var subject_type = control.GetcmbTypeValue();//获取题目类型

                                switch (subject_type)
                                {
                                    #region 单选题
                                    case "单选题":
                                        {

                                            AddSomeOfInfo(count, control, subject_type);
                                            var ControlValue = control.GetRichTextSingleText();//获取控件中的txt文本()
                                            var ControlboolValue = control.GetRadioButtonCheckValue();//获取Radio控件中的Check值
                                            var ControlABCDValue = control.GetRadioButtonTextValue();//获取Radio控件中的Text文本
                                            var ControlRtfValue = control.GetRichTextSingleRtfText();//获取控件中的Rtf文本
                                            var dt_child_info = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));
                                            if (dt_child_info != null && dt_child_info.Rows.Count > 0)
                                            {
                                                var dr_child_info = dt_child_info.Rows[count];
                                                value_child_guid = Convert.ToString(dr_child_info["guid"]);
                                                for (int i = 0; i < AllControlCount; i++)
                                                {
                                                    var item = ControlValue[i];
                                                    var boolitem = ControlboolValue[i];
                                                    var RtfText = ControlRtfValue[i];
                                                    var ABCD = ControlABCDValue[i];
                                                    InsertOptionInfo(value_child_guid, ABCD, item, RtfText, boolitem);
                                                }
                                            }


                                            break;
                                        }
                                    #endregion
                                    #region 多选题
                                    case "多选题":
                                        {
                                            AddSomeOfInfo(count, control, subject_type);
                                            var ControlValue = control.GetRichTextProText();//获取控件中的txt文本()
                                            var ControlRtfValue = control.GetRichTextProRtfText();//获取控件中的Rtf文本
                                            var ControlboolValue = control.GetCheckEditValue();//获取控Radio件中的Check值
                                            var ControlABCDValue = control.GetCheckEditText();//获取Radio控件中的Text文本
                                            var dt_child_info_guid = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));//查询子题目guid
                                            var dr_child_info_guid = dt_child_info_guid.Rows[count];
                                            value_child_guid = Convert.ToString(dr_child_info_guid["guid"]);//获取子题目guid
                                            for (int i = 0; i < AllControlCount; i++)
                                            {
                                                var item = ControlValue[i];
                                                var boolitem = ControlboolValue[i];
                                                var RtfText = ControlRtfValue[i];
                                                var ABCD = ControlABCDValue[i];
                                                InsertOptionInfo(value_child_guid, ABCD, item, RtfText, boolitem);//新增
                                            }
                                            break;
                                        }
                                    #endregion
                                    #region 判断题
                                    case "判断题":
                                        {
                                            AddSomeOfInfo(count, control, subject_type);
                                            break;
                                        }
                                    #endregion
                                    #region 填空题
                                    case "填空题":
                                        {
                                            AddAskInput(subject_type, count, control, AllControlCount);
                                            break;
                                        }
                                    #endregion
                                    #region 问答题
                                    case "问答题":
                                        {
                                            AddAskInput(subject_type, count, control, AllControlCount);
                                            break;
                                        }
                                        #endregion
                                }
                            }
                        }
                        break;
                    }
                case true://编辑
                    {
                        var countPanelAll = LayoutPanelAll.Controls.Count; //子题控件数量
                        var countdbPanelAll = Convert.ToInt32(SelectChildControlCount(value_guid));//获取数据库子题控件数量
                        var dtControlInfo = SelectControlInfo(value_guid);//所有子题的信息
                        {
                            if (countPanelAll > countdbPanelAll)//当前选项大于数据库选项
                            {//先添加选项
                                for (int nowcount = countdbPanelAll; nowcount < countPanelAll; nowcount++)//循环添加选项
                                {
                                    var control = (LayoutPanelAll.Controls[nowcount] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
                                    var subject_type = control.GetcmbTypeValue();//获取题目类型
                                    AddSomeOfInfo(nowcount, control, subject_type);
                                    var AllControlCount = control.GetStarFishPanelControlCount();//选项数量
                                    AddOption(nowcount, control, AllControlCount, subject_type);
                                }
                            }
                            else if (countPanelAll < countdbPanelAll) //数据库子题数量大于当子题数量
                            {//删除数据库多余子题

                                var drCount = dtControlInfo.Rows.Count;//获取该题目子题数量
                                var length = drCount - countPanelAll;
                                for (int times = 0; times < length; times++)
                                {
                                    dtControlInfo = SelectControlInfo(value_guid);//所有子题的信息
                                    var drControlInfo = dtControlInfo.Rows[countPanelAll];//获取当前子题以外的子题
                                    var subject_child_guid = Convert.ToString(drControlInfo["guid"]);
                                    "delete from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid".ExecuteNonQuery(("@subject_child_guid", subject_child_guid));
                                    "delete from SubjectChildInfo where guid=@guid".ExecuteNonQuery(("@guid", subject_child_guid));
                                }

                            }
                        }
                        {//判断选项是否增加或减少
                            dtControlInfo = SelectControlInfo(value_guid);
                            for (int Ftimes = 0; Ftimes < countPanelAll; Ftimes++)//Ftime循环次数,循环处理完毕现有的选项
                            {//遍历查看是否出现新增或删除选项
                                var NowControl = (LayoutPanelAll.Controls[Ftimes] as PanelControlAll);//获取当前控件
                                var dr = dtControlInfo.Rows[Ftimes];//获取指定的行的数据
                                var guid = Convert.ToString(dr["guid"]);//获取guid
                                var NowChildOptionInfo = SelectChildOptionInfo(guid);//使用guid获取子题选项信息
                                var dbOptioncount = NowChildOptionInfo.Rows.Count;//获取当前控件数量
                                if (NowChildOptionInfo != null && dtControlInfo.Rows.Count > 0)//如果数据库中的子题选项大于0才往下执行
                                {
                                    var NowChildControlsCount = NowControl.GetStarFishPanelControlCount();//获取当前控件字体数量
                                    if (NowChildControlsCount > dbOptioncount)//当前子题选项数量大于数据库选项的数量
                                    {//执行添加子题选项
                                        var subject_type = NowControl.GetcmbTypeValue();//获取题目类型
                                        for (int addtime = 0; addtime < NowChildControlsCount - dbOptioncount; addtime++)//循环当前选项数量-数据库数量得出要新增多少个
                                        {
                                            var dboptioncount = SelectChildOptionCount(guid);

                                            AddOption(Ftimes, NowControl, dboptioncount, NowChildControlsCount - dbOptioncount, subject_type);
                                        }
                                    }
                                    else if (NowChildControlsCount < dbOptioncount)//当前子题选项数量小于数据库选项的数量
                                    {//执行删除子题选项
                                        for (int deltime = NowChildControlsCount; deltime < dbOptioncount; deltime++)
                                        {
                                            var child_option_guid = Convert.ToString(NowChildOptionInfo.Rows[deltime]["guid"]);
                                            "delete from SubjectChildOptionInfo where guid = @guid".ExecuteNonQuery(("@guid", child_option_guid));
                                        }
                                    }
                                }
                            }
                        }

                        {//执行修改逻辑
                            for (int times = 0; times < countdbPanelAll; times++)
                            {
                                var control = (LayoutPanelAll.Controls[times] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
                                var subject_type = control.GetcmbTypeValue();//获取题目类型
                                UpdateAll(subject_type, control, times);
                            }
                            break;
                        }
                    }

            }
            MessageBox.Show("保存成功");
            this.Close();
        }
        #endregion
        #endregion
        #region 新增panel
        /// <summary>
        /// 新增panel
        /// </summary>
        /// <param name="count"></param>
        public void AddPanel(int count)
        {
            numericUpDown1.Enabled = false;
            var countPanelAll = Convert.ToInt32(LayoutPanelAll.Controls.Count); //控件数量

            if (countPanelAll != count)
            {
                if (countPanelAll < count)
                {
                    //添加
                    var controlscount = count - countPanelAll;
                    for (int i = 0; i < controlscount; i++)
                    {
                        PanelControlAll panelControl = new PanelControlAll();

                        panelControl.ChangeFormHeight();
                        LayoutPanelAll.Controls.Add(panelControl);
                        panelControl.SetlblValue(count);

                        var subject_type = (LayoutPanelAll.Controls[count - 1] as PanelControlAll).GetcmbTypeValue();//获取题目类型


                        if (subject_type == "单选题")
                        {

                            panelControl.AddOptionSingle(4);

                        }
                    }

                }
                if (countPanelAll > count)
                {
                    //删除
                    var controlscount = countPanelAll - count;
                    for (int i = 0; i < controlscount; i++)
                    {
                        LayoutPanelAll.Controls.RemoveAt(count);
                    }
                }
            }
            numericUpDown1.Enabled = true;
        }
        //int AllControlsCount;//记录控件数量
        /// <summary>
        /// 加载panel(编辑)
        /// </summary>
        /// <param name="count"></param>
        /// <param name="subject_type"></param>
        /// <param name="OptionCount"></param>
        /// <param name="AllOptionCount">子题数量</param>
        public void AddPanel(int count, string subject_type, int AllOptionCount, int OptionCount = 1, string value_subject_child_analysis = "", List<string> Content = null, List<bool> value_child_is_correct = null, string value_answer = "")
        {

            PanelControlAll panelControl = new PanelControlAll();//创建控件

            panelControl.ChangeFormHeight();//设置高度
            numericUpDown1.Value++;
            LayoutPanelAll.Controls.Add(panelControl);///添加控件
            panelControl.SetlblValue(count);//设置题目编号


            switch (subject_type)
            {
                case "单选题":
                    {
                        panelControl.SetcmbTypeValue(subject_type);
                        panelControl.AddOptionSingle(OptionCount);
                        SetAnalysisValue(AllOptionCount, value_subject_child_analysis);
                        SetValueSingle(AllOptionCount, Content, value_child_is_correct);
                        SetAnswerValue(AllOptionCount, value_answer);
                        break;
                    }
                case "多选题":
                    {
                        panelControl.SetcmbTypeValue(subject_type);
                        panelControl.AddOptionPro(OptionCount);
                        SetAnalysisValue(AllOptionCount, value_subject_child_analysis);
                        SetValuePro(AllOptionCount, Content, value_child_is_correct);
                        SetAnswerValue(AllOptionCount, value_answer);
                        break;
                    }
                case "判断题":
                    {
                        panelControl.SetcmbTypeValue(subject_type);
                        panelControl.AddOptionIstrue(OptionCount);
                        SetAnalysisValue(0, value_subject_child_analysis);
                        SetAnswerValue(AllOptionCount, value_answer);
                        SetValueIsCheck(value_answer);
                        break;
                    }
                case "填空题":
                    {
                        panelControl.SetcmbTypeValue(subject_type);
                        panelControl.AddOptionInput(OptionCount);
                        SetAnswerValue(0, value_answer);
                        SetAnalysisValue(0, value_subject_child_analysis);
                        SetValueInputAsk(AllOptionCount, Content);
                        break;
                    }
                case "问答题":
                    {
                        panelControl.SetcmbTypeValue(subject_type);
                        panelControl.AddOptionAsk(OptionCount);
                        SetAnalysisValue(0, value_subject_child_analysis);
                        SetAnswerValue(0, value_answer);
                        SetValueInputAsk(AllOptionCount, Content);
                        break;
                    }
            }
        }
        #endregion
        #region 数字管理控件
        /// <summary>
        /// 值增加或减少
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var count = Convert.ToInt32(numericUpDown1.Value);
            if (is_Plus == false)
            {
            }
            else
            {
                numericUpDown1.BeginInvoke(new Action(() =>
                {
                    AddPanel(count);//某方法
                }));
            }
        }
        #endregion
        #region timer异步加载
        /// <summary>
        /// timer异步加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {

            var dt_child_info = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_child_no asc".ExecuteQuery(("@value_subject_guid", value_guid));
            if (dt_child_info != null && dt_child_info.Rows.Count > 0)
            {
                numericUpDown1.Enabled = false;
                var PanelCount = dt_child_info.Rows.Count;
                for (int AddCount = 0; AddCount < PanelCount; AddCount++)
                {
                    var dr_child_info = dt_child_info.Rows[AddCount];
                    value_subject_child_type = Convert.ToString(dr_child_info["subject_child_type"]);//Subject_Type
                    var value_subject_child_analysis = Convert.FromBase64String(dr_child_info["subject_child_analysis2"].ToString()).ToRtxBytesString();//Analysis
                    var value_answer = Convert.ToString(dr_child_info["subject_child_answer"]);
                    value_child_guid = Convert.ToString(dr_child_info["guid"]);//Guid
                    var value_child_is_correct = SelectISCorrect(value_child_guid);
                    var OptionCount = SelectChildOptionCount(value_child_guid);
                    var Content = SelectContent(value_child_guid);
                    var RtfContent = SelectRtfContent(value_child_guid);

                    switch (value_subject_child_type)
                    {
                        case "0":
                            {

                                AddPanel(1, "单选题", AddCount, OptionCount, value_subject_child_analysis, RtfContent, value_child_is_correct, value_answer);
                                break;
                            }
                        case "1":
                            {
                                AddPanel(1, "多选题", AddCount, OptionCount, value_subject_child_analysis, RtfContent, value_child_is_correct, value_answer);
                                break;
                            }
                        case "2":
                            {
                                AddPanel(1, "判断题", AddCount, 1, value_subject_child_analysis, null, null, value_answer);
                                break;
                            }
                        case "3":
                            {
                                AddPanel(1, "填空题", AddCount, OptionCount, value_subject_child_analysis, RtfContent, null, value_answer);

                                break;
                            }
                        case "4":
                            {
                                AddPanel(1, "问答题", AddCount, OptionCount, value_subject_child_analysis, RtfContent, null, value_answer);

                                break;
                            }
                    }
                    is_edit = true;

                }
            }
            else
            {
                if (is_edit == false)
                {
                    numericUpDown1.Value = 1;
                }
                AddPanel(1);//某方法
            }
            is_Plus = true;
            txtContent.SetText(value_exam_content);
            timer.Stop();
            numericUpDown1.Enabled = true;
        }

        #endregion
        #region 窗体
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmExamAddSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            var frm = new FrmExamAddSelect();
            frm.Dispose();
        }
        #endregion
    }
}
