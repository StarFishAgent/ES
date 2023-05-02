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

namespace WinClient.AddInfo
{
    public partial class FrmExamAddAnswer : XtraForm
    {
        public FrmExamAddAnswer()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
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
        /// 大题主键
        /// </summary>
        string value_exam_content;
        /// <summary>
        /// 题目内容
        /// </summary>
        string value_guid;
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="value_guid"></param>
        /// <param name="value_exam_content"></param>
        public FrmExamAddAnswer(string value_guid, string value_exam_content) : this()
        {
            this.value_guid = value_guid;
            this.value_exam_content = value_exam_content;
            var dt_child_info = "select * from SubjectChildInfo where subject_guid=@value_subject_guid order by subject_no asc".ExecuteQuery(("@value_subject_guid", value_guid));
            if (dt_child_info != null && dt_child_info.Rows.Count > 0)
            {
                var child_count = dt_child_info.Rows.Count;
            }
            else
            {

            }
            txtContent.SetText(value_exam_content);
        }
        #endregion
        #region 题目类型
        /// <summary>
        /// 初始化
        /// </summary>
        public void Format()
        {//子题目类型（0：单选题；1：多选题；2：判断题；3：填空题；4：问答题）
            string[] str = new string[] { "单选题", "多选题", "判断题", "填空题", "问答题" };
            this.cmbType.Properties.Items.AddRange(str);
            cmbType.SelectedIndex = 0;
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
            
        }
        #endregion
        #region 保存按钮点击事件
        /// <summary>
        /// 子题信息新增事件
        /// </summary>
        /// <param name="subject_guid">题目主键</param>
        /// <param name="child_no">子题号</param>
        /// <param name="child_answer">子题答案(Text)</param>
        /// <param name="child_answer2">子题答案2(RtfText)</param>
        /// <param name="child_analysis">子题解析(Text)</param>
        /// <param name="child_analysis2">子题解析2(RtfText)</param>
        /// <param name="subject_type">子题类型</param>
        public void Insert(string subject_guid, int child_no, string child_answer, byte[] child_answer2, string child_analysis, byte[] child_analysis2, int subject_type)
        {
            $@"insert into SubjectChildInfo(subject_guid,subject_child_no,subject_child_answer,subject_child_answer2,subject_child_analysis,subject_child_analysis2,subject_child_type)values(@subject_guid,@subject_child_no,@subject_child_answer,@subject_child_answer2,@subject_child_analysis,@subject_child_analysis2,@subject_child_type)".ExecuteNonQuery(("@subject_guid", subject_guid, typeof(string).FullName), ("@subject_child_no", child_no, typeof(int).FullName), ("@subject_child_answer", child_answer, typeof(string).FullName), ("@subject_child_answer2", child_answer2, typeof(byte[]).FullName), ("@subject_child_analysis", child_analysis, typeof(string).FullName), ("@subject_child_analysis2", child_analysis2, typeof(byte[]).FullName), ("@subject_child_type", subject_type, typeof(int).FullName));//
        }
        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //var countPanelAll = LayoutPanelAll.Controls.Count; //控件数量

            //for (int count = 0; count < countPanelAll; count++)//有多少个容器控件就循环多少次
            //{//每一次都获取所有文本框里面的值
            //    var control = (LayoutPanelAll.Controls[count] as PanelControlAll);//获取panelcontrol里面有多少个PanelControlAll控件
            //    var subject_type = control.GetcmbTypeValue();//获取题目类型
            //    if (subject_type == "单选题")
            //    {
            //        var subject_type_int = 0;
            //        int subject_no = count++;

            //        //Insert(value_guid,subject_no,);
            //        var ControlValue = control.GetRichTextSingleText();//获取控件中的文本
            //        var ControlboolValue = control.GetRadioButtonValue();//获取控件中的文本
            //        var ControlRtfValue = control.GetRichTextSingleRtfText();
            //        var ControlValueCount = ControlValue.Count;//获取值的数量

            //        for (int i = 0; i < ControlValueCount; i++)
            //        {
            //            var item = ControlValue[i];
            //            var boolitem = ControlboolValue[i];
            //            var RtfText = ControlRtfValue[i];
            //            if (item == "" || item == null)
            //            {
            //                MessageBox.Show("某选项为空值，请检查后再保存");
            //                return;
            //            }
            //            else
            //            {
            //                $@"insert into ".ExecuteNonQuery();

            //            }
            //        }
            //    }
            //    if (subject_type == "多选题")
            //    {
            //        var ControlValue = control.GetRichTextSingleText();//获取控件中的文本
            //        var ControlboolValue = control.GetRadioButtonValue();//获取控件中的文本
            //        var ControlRtfValue = control.GetRichTextProRtfText();
            //        var ControlValueCount = ControlValue.Count;//获取值的数量

            //        for (int i = 0; i < ControlValueCount; i++)
            //        {
            //            var item = ControlValue[i];
            //            var boolitem = ControlboolValue[i];
            //            var RtfText = ControlRtfValue[i];
            //            if (item == "" || item == null)
            //            {
            //                MessageBox.Show("某选项为空值，请检查后再保存");
            //                return;
            //            }
            //            else
            //            {
            //                $@"insert into ".ExecuteNonQuery();

            //            }
            //        }

            //    }

            //}






        }
        #endregion
        #region 转换题目类型
        /// <summary>
        /// 转换题目类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        #endregion
        #region 新增panel
        /// <summary>
        /// 新增panel
        /// </summary>
        /// <param name="count"></param>
        public void AddPanel(int count)
        {
            var countPanelAll = Convert.ToInt32(LayoutPanelAll.Controls.Count); //控件数量

            //if (countPanelAll != count)
            //{
            //    if (countPanelAll < count)
            //    {
            //        //添加
            //        var controlscount = count - countPanelAll;
            //        for (int i = 0; i < controlscount; i++)
            //        {
            //            PanelControlAll panelControl = new PanelControlAll();
            //            panelControl.Height = 2000;
            //            LayoutPanelAll.Controls.Add(panelControl);
            //            panelControl.SetlblValue(count);
            //            if (cmbType.Text == "单选题")
            //            {
            //                panelControl.AddOptionSingle(4);
            //            }
            //            if (cmbType.Text == "多选题")
            //            {
            //                panelControl.AddOptionPro(4);
            //            }
            //        }
            //    }
            //    if (countPanelAll > count)
            //    {
            //        //删除
            //        var controlscount = countPanelAll - count;
            //        for (int i = 0; i < controlscount; i++)
            //        {
            //            LayoutPanelAll.Controls.RemoveAt(count);
            //        }
            //    }
            //}
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
            AddPanel(count);
        }
        #endregion

        private void FrmExamAddAnswer_Load(object sender, EventArgs e)
        {
            this.AddPanel(1);
        }
    }
}
