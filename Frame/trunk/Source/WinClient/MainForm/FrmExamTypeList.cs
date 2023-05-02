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
                    "select  from  where ".ExecuteQuery();
                    "delete from ".ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
