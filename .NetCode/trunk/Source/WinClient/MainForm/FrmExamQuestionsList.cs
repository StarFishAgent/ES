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
    public partial class FrmExamQuestionsList : XtraForm
    {
        /// <summary>
        /// 题目列表窗体
        /// </summary>
        public FrmExamQuestionsList()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
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
        /// <param name="value_exam_time">考试时间</param>
        /// <param name="value_exam_name">考试名称</param>
        public FrmExamQuestionsList(string value_guid, string value_exam_time, string value_exam_name, string value_exam_type) : this()
        {
            this.value_guid = value_guid;
            this.value_exam_type = value_exam_type;
            this.value_exam_time = value_exam_time;
            this.value_exam_name = value_exam_name;
            LoadData();
        }
        #endregion
        #region 刷新
        /// <summary>
        /// 刷新
        /// </summary>
        public void LoadData()
        {
            var dt_Subject = "select * from ExamSubjectInfo where exam_guid=@exam_guid".ExecuteQuery(("@exam_guid", value_guid));
            gridControl.DataSource = dt_Subject;
        }
        #endregion
        #region 刷新按钮
        /// <summary>
        /// 刷新按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
        #endregion
        #region 删除按钮
        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var RowSelect = gridView.GetFocusedDataRow();
            if (RowSelect == null)
            {
                MessageBox.Show("请选择要删除的题目");
                return;
            }
            var dia = MessageBox.Show("是否确认删除该题目", "Warming", MessageBoxButtons.YesNo);
            if (dia == DialogResult.Yes)
            {
                var guid = gridView.GetRowCellValue(gridView.FocusedRowHandle, col_guid).ToString();

                var dt_subject_child_guid = "select guid from SubjectChildInfo where subject_guid=@subject_guid".ExecuteQuery(("@subject_guid", guid));
                if (dt_subject_child_guid != null && dt_subject_child_guid.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_subject_child_guid.Rows.Count; i++)
                    {
                        var subject_child_guid = dt_subject_child_guid.Rows[i]["guid"].ToString();

                        "delete from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid".ExecuteNonQuery(("@subject_child_guid", subject_child_guid));

                        "delete from SubjectChildInfo where guid=@guid".ExecuteNonQuery(("@guid", subject_child_guid));
                    }
                    "delete from ExamSubjectInfo where guid=@guid".ExecuteNonQuery(("@guid", guid));

                }

                "delete from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid".ExecuteNonQuery(("@subject_child_guid", guid));
                "delete from ExamSubjectInfo where guid=@guid".ExecuteNonQuery(("@guid", guid));
                MessageBox.Show("删除成功");
                LoadData();
            }
        }
        #endregion
        #region 添加题目按钮
        /// <summary>
        /// 添加题目按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var frm = new FrmExamAddTitle(value_guid, value_exam_type, value_exam_time, value_exam_name);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        #endregion
        #region 查询按钮
        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var subject_content = Convert.ToString(this.txtContent.EditValue) ?? "";
            if (string.IsNullOrEmpty(subject_content))
            {
                btnSelect.Enabled = false;
                LoadData();
                btnSelect.Enabled = true;
                return;
            }
            var dt_content_data = "select * from ExamSubjectInfo where exam_guid=@exam_guid and subject_content like @subject_content".ExecuteQuery(("@exam_guid", value_guid), ("@subject_content", "%" + subject_content + "%"));
            gridControl.DataSource = dt_content_data;
        }
        #endregion
        #region 添加选项按钮
        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQutionUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView.GetFocusedDataRow();
            if (row == null)
            {
                MessageBox.Show("请选择要操作的题目");
                return;
            }
            var value_guid = gridView.GetRowCellValue(gridView.FocusedRowHandle, col_guid).ToString();
            var value_exam_content = gridView.GetRowCellValue(gridView.FocusedRowHandle, col_subject_content).ToString();
            var frm = new FrmExamAddSelect(value_guid, value_exam_content);
            frm.Show();
            LoadData();
        }
        #endregion
    }
}
