using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace WinClient
{
    public partial class FrmExamTypeList : XtraForm
    {
        /// <summary>
        /// 考试类型窗体
        /// </summary>
        public FrmExamTypeList()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion

        }
        #region 刷新
        public void LoadData()
        {
            var dt_exam_type_data = "select * from ExamTypeInfo".ExecuteQuery();
            gridControl.DataSource = dt_exam_type_data;
        }
        #endregion
        #region 窗体
        /// <summary>
        /// 窗体加载完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditItem_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion
        #region 网格列表
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView.DataRowCount == 0)
            {
                return;
            }
            var value_exam_type = gridView.GetRowCellValue(gridView.FocusedRowHandle, col_exam_type).ToString();
            var value_guid = gridView.GetRowCellValue(gridView.FocusedRowHandle, col_guid).ToString();
            var frm = new FrmExamNameList(value_exam_type, value_guid);
            frm.ShowDialog();
        }
        #endregion
        #region 查询按钮
        private void btnSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            var exam_type = Convert.ToString(this.txtExamType.EditValue) ?? "";
            if (string.IsNullOrEmpty(exam_type))
            {
                LoadData();
                return;
            }
            var dt_exam_type_data = "select exam_type,guid from ExamTypeInfok where exam_type like @exam_type".ExecuteQuery(("@exam_type", "%" + exam_type + "%"));//查询题目信息
            gridControl.DataSource = dt_exam_type_data;
        }
        #endregion
        #region 刷新按钮
        private void btnLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }
        #endregion
        #region 新增选项按钮
        /// <summary>
        /// 新增选项按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddType_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new FrmExamAddType();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        #endregion
        #region 删除按钮
        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var RowSelect = gridView.GetFocusedDataRow();
            if (RowSelect == null)
            {
                MessageBox.Show("请选择要删除的类型");
                return;
            }
            var dia = MessageBox.Show("是否确认删除该类型", "Warming", MessageBoxButtons.YesNo);
            if (dia == DialogResult.Yes)
            {
                var diaEnter = MessageBox.Show("删除该类型会删除所有关联的考试和题目，是否继续", "Warming", MessageBoxButtons.YesNo);
                if (diaEnter == DialogResult.Yes)
                {
                    var type_guid = gridView.GetRowCellValue(gridView.FocusedRowHandle, col_guid).ToString();
                    var dt_exam_type_guid = "select guid from ExamInfo where exam_type_guid=@exam_type_guid".ExecuteQuery(("@exam_type_guid", type_guid));
                    if (dt_exam_type_guid != null && dt_exam_type_guid.Rows.Count > 0)
                    {
                        for (int subject_count = 0; subject_count < dt_exam_type_guid.Rows.Count; subject_count++)
                        {
                            var dr_exam_type_guid = dt_exam_type_guid.Rows[subject_count];
                            var exam_type_guid = Convert.ToString(dr_exam_type_guid["guid"]);

                            var dt_subject_guid = "select guid from ExamSubjectInfo where exam_guid =@exam_guid".ExecuteQuery(("@exam_guid", exam_type_guid));//获取题目guid
                            if (dt_subject_guid != null && dt_subject_guid.Rows.Count > 0)//如果有guid
                            {
                                for (int count = 0; count < dt_subject_guid.Rows.Count; count++)//循环删除
                                {
                                    var subject_guid = dt_subject_guid.Rows[count]["guid"];//提取题目guid
                                    var dt_subject_child_guid = "select guid from SubjectChildInfo where subject_guid=@subject_guid".ExecuteQuery(("@subject_guid", subject_guid));//获取子题guid
                                    if (dt_subject_child_guid != null && dt_subject_child_guid.Rows.Count > 0)//如果子题存在guid
                                    {
                                        for (int i = 0; i < dt_subject_child_guid.Rows.Count; i++)//循环删除
                                        {
                                            var subject_child_guid = Convert.ToString(dt_subject_child_guid.Rows[i]["guid"]);//提取子题guid
                                            var dt_subject_child_option_guid = "select guid from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid".ExecuteQuery(("@subject_child_guid", subject_child_guid));//获取子题选项guid
                                            if (dt_subject_child_option_guid != null && dt_subject_child_option_guid.Rows.Count > 0)//如果子题选项guid存在
                                            {
                                                "delete from SubjectChildOptionInfo where subject_child_guid=@subject_child_guid".ExecuteNonQuery(("@subject_child_guid", subject_child_guid));//使用子题guid删除

                                                "delete from SubjectChildInfo where subject_guid=@subject_guid".ExecuteNonQuery(("@subject_guid", subject_guid));
                                            }
                                            else
                                            {
                                                "delete from SubjectChildInfo where subject_guid=@subject_guid".ExecuteNonQuery(("@subject_guid", subject_guid));
                                            }
                                            "delete from ExamSubjectInfo where guid=@guid".ExecuteNonQuery(("@guid", subject_guid));
                                        }
                                    }
                                    else
                                    {
                                        "delete from SubjectChildInfo where subject_guid=@subject_guid".ExecuteNonQuery(("@subject_guid", subject_guid));
                                        "delete from ExamSubjectInfo where guid=@guid".ExecuteNonQuery(("@guid", subject_guid));
                                    }
                                }

                                "delete from ExamInfo where guid =@guid".ExecuteNonQuery(("@guid", exam_type_guid));

                            }
                            else
                            {
                                "delete from ExamInfo where guid =@guid".ExecuteNonQuery(("@guid", exam_type_guid));

                            }

                        }
                        "delete from ExamTypeInfo where guid = @guid".ExecuteNonQuery(("@guid", type_guid));
                    }
                    else
                    {
                        "delete from ExamTypeInfo where guid = @guid".ExecuteNonQuery(("@guid", type_guid));
                    }

                }
            }
            MessageBox.Show("删除成功");
            LoadData();
        }
        #endregion
    }
}
            
        
    


