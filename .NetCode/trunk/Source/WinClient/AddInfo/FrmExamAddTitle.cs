﻿using DevExpress.XtraEditors;
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

namespace WinClient
{
    public partial class FrmExamAddTitle : XtraForm
    {
        /// <summary>
        /// 添加题目窗体
        /// </summary>
        public FrmExamAddTitle()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
        }
        public bool IsExistContent(string subject_content/*,byte[] subject_content2*/)
        {

            var dt_is_exist = "select subject_content,subject_content2 from ExamSubjectInfo where subject_content=@subject_content ".ExecuteQuery(("@subject_content", subject_content)/*,("@subject_content2", subject_content2)*/);//and subject_content2=@subject_content2
            if (dt_is_exist != null && dt_is_exist.Rows.Count > 0)
            {
                return true;
            }
            return false; ;
        }
        #region 窗体传值
        /// <summary>
        /// 主键
        /// </summary>
        string value_guid;
        /// <summary>
        /// 考试时间
        /// </summary>
        string value_exam_time;
        /// <summary>
        /// 考试名称
        /// </summary>
        string value_exam_name;
        /// <summary>
        /// 考试类型
        /// </summary>
        string value_exam_type;
        /// <summary>
        /// 接收值
        /// </summary>
        /// <param name="value_guid">主键</param>
        /// <param name="value_exam_type">考试时间</param>
        /// <param name="value_exam_time">考试名称</param>
        /// <param name="value_exam_name">考试类型</param>
        public FrmExamAddTitle(string value_guid, string value_exam_type, string value_exam_time, string value_exam_name) : this()
        {
            this.value_guid = value_guid;
            this.value_exam_type = value_exam_type;
            this.value_exam_time = value_exam_time;
            this.value_exam_name = value_exam_name;
            txtExamName.Text = value_exam_name;
            txtExamTime.Text = value_exam_time;
            txtExamType.Text = value_exam_type;
        }
        #endregion
        #region 题目类型
        /// <summary>
        /// 初始化
        /// </summary>
        public void Format()
        {

        }
        #endregion
        #region 窗体
        /// <summary>
        /// 窗体加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAddTitle_Load(object sender, EventArgs e)
        {
            Format();
        }
        #endregion
        #region 新增按钮
        /// <summary>
        /// 新增完毕后
        /// </summary>
        public void Result()
        {
            MessageBox.Show("添加成功");
            Close();
            DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 新增按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {

            var subject_content = richBoxEdit1.GetText().Trim();//题目
            var subject_content2 = richBoxEdit1.GetRtfText().Trim().ToRtxBytes() ?? null;//题目的byte

            if (string.IsNullOrEmpty(subject_content))
            {
                MessageBox.Show("请输入试题内容");
                return;
            }
            {
                var dt = "select subject_no from ExamSubjectInfo order by subject_no desc".ExecuteQuery();//查询用于获取题目序号
                if (dt != null && dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];
                    var strid = "";
                    var id = Convert.ToInt32(dr["subject_no"]);//题目序号
                    if (id < 9)
                    {
                        id++;
                        strid = "0" + id;
                    }
                    else
                    {
                        id++;
                        strid = id.ToString();
                    }
                    //if (IsExistContent(subject_content/*, subject_content2*/) == true)
                    //{
                    //    if (MessageBox.Show("该题目已存在是否继续添加", "Tips", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //    {
                    //        "insert into ExamSubjectInfo(exam_guid,subject_no,subject_content,subject_content2)values(@exam_guid,@subject_no,@subject_content,@subject_content2)".ExecuteNonQuery(("@exam_guid", value_guid, typeof(string).FullName), ("@subject_no", strid, typeof(int).FullName), ("@subject_content", subject_content, typeof(string).FullName), ("@subject_content2", subject_content2, typeof(byte[]).FullName));
                    //    }
                    //    else
                    //    {
                    //        return;
                    //    }
                        
                    //}
                    //else
                    //{
                        "insert into ExamSubjectInfo(exam_guid,subject_no,subject_content,subject_content2)values(@exam_guid,@subject_no,@subject_content,@subject_content2)".ExecuteNonQuery(("@exam_guid", value_guid, typeof(string).FullName), ("@subject_no", strid, typeof(int).FullName), ("@subject_content", subject_content, typeof(string).FullName), ("@subject_content2", subject_content2, typeof(byte[]).FullName));
                    //}
                }
                else if (dt != null && dt.Rows.Count == 0)
                {
                    string id = "01";//题目序号
                    "insert into ExamSubjectInfo(exam_guid,subject_no,subject_content,subject_content2)values(@exam_guid,@subject_no,@subject_content,@subject_content2)".ExecuteNonQuery(("@exam_guid", value_guid, typeof(string).FullName), ("@subject_no", id, typeof(int).FullName), ("@subject_content", subject_content, typeof(string).FullName), ("@subject_content2", subject_content2, typeof(byte[]).FullName));
                }
                Result();
            }
        }
        #endregion
        #region 清除按钮
        /// <summary>
        /// 清除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnclear_Click(object sender, EventArgs e)
        {
            richBoxEdit1.SetText("");
        }
        #endregion
        #region 取消按钮
        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        OpenFileDialog dia = new OpenFileDialog();
        private void btnScan_Click(object sender, EventArgs e)
        {
            if (dia.ShowDialog() == DialogResult.OK)
            {
                richBoxEdit1.SetText(dia.FileName.Scan());
            }
        }
    }
}
