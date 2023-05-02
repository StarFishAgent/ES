using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient
{
    public partial class FrmExamAddExamNameInfo : XtraForm
    {
        /// <summary>
        /// 添加考试信息窗体
        /// </summary>
        public FrmExamAddExamNameInfo()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
            if (cmbExamType.Text == "")
            {
                Format();
            }
        }
        #region 接收值
        /// <summary>
        /// 考试类型guid
        /// </summary>
        string value_exam_type_guid;
        /// <summary>
        /// 考试类型
        /// </summary>
        string value_exam_type;
        /// <summary>
        /// 接收值
        /// </summary>
        /// <param name="value_exam_type"></param>
        public FrmExamAddExamNameInfo(string value_exam_type_guid, string value_exam_type) : this()
        {
            this.value_exam_type_guid = value_exam_type_guid;
            this.value_exam_type = value_exam_type;
            this.cmbExamType.Text = value_exam_type;
            if (this.cmbExamType.Text == value_exam_type)
            {
                this.cmbExamType.Enabled = false;
            }

        }
        #endregion
        #region 题目类型
        /// <summary>
        /// 初始化
        /// </summary>
        public void Format()
        {
            var dt_exam_type_data = "select exam_type from ExamTypeInfo".ExecuteQuery();
            if (dt_exam_type_data != null && dt_exam_type_data.Rows.Count > 0)
            {
                int count = dt_exam_type_data.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    var dr_exam_type = dt_exam_type_data.Rows[i];

                    this.cmbExamType.Properties.Items.Add(dr_exam_type["exam_type"]);
                }
                cmbExamType.SelectedIndex = 0;
            }
        }
        #endregion
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddYear_Click(object sender, EventArgs e)
        {
            var exam_year = this.cmbExamYear.Text.Trim();
            var exam_name = this.txtExamName.Text.Trim();
            var exam_type = this.cmbExamType.Text.Trim();
            if (string.IsNullOrEmpty(exam_name))
            {
                MessageBox.Show("请输入考试名称");
                return;
            }
            if (string.IsNullOrEmpty(exam_year))
            {
                MessageBox.Show("请选择年份信息");
                return;
            }
            {
                if (cmbExamType.Enabled == false)
                {
                    "insert into ExamInfo(exam_time,exam_type_guid,exam_name)values(@exam_time,@exam_type_guid,@exam_name)".ExecuteNonQuery(("@exam_time", exam_year, typeof(string).FullName), ("@exam_type_guid", value_exam_type_guid, typeof(string).FullName), ("@exam_name", exam_name, typeof(string).FullName));
                    MessageBox.Show("添加成功");
                    Close();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (string.IsNullOrEmpty(exam_type))
                    {
                        MessageBox.Show("请选择考试类型");
                        return;
                    }
                    var dt_exam_type_info = "select guid,exam_type from ExamTypeInfo where exam_type=@exam_type".ExecuteQuery(("@exam_type", exam_type));
                    if (dt_exam_type_info != null && dt_exam_type_info.Rows.Count > 0)
                    {
                        var dr_exam_type_info = dt_exam_type_info.Rows[0];
                        var exam_type_guid = Convert.ToString(dr_exam_type_info["guid"]);
                        "insert into ExamInfo(exam_time,exam_type_guid,exam_name)values(@exam_time,@exam_type_guid,@exam_name)".ExecuteNonQuery(("@exam_time", exam_year, typeof(string).FullName), ("@exam_type_guid", exam_type_guid, typeof(string).FullName), ("@exam_name", exam_name, typeof(string).FullName));
                        MessageBox.Show("添加成功");
                        Close();
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }
    }
}
