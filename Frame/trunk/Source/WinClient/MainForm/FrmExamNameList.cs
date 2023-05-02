using DevExpress.XtraBars;
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
    public partial class FrmExamNameList : XtraForm
    {
        /// <summary>
        /// 考试名称列表窗体
        /// </summary>
        public FrmExamNameList()
        {
            InitializeComponent();//加载UI
            Format();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
        }
        #region 题目类型
        /// <summary>
        /// 初始化
        /// </summary>
        public void Format()
        {
            {
                var dt__exam_time = "select exam_time from ExamInfo".ExecuteQuery();
                ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)cmbExamTime.Edit).Items.Add("无");
                if (dt__exam_time != null && dt__exam_time.Rows.Count > 0)
                {
                    var dr_exam_time = dt__exam_time.Rows;
                    foreach (DataRow item in dr_exam_time)
                    {
                        ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)cmbExamTime.Edit).Items.Add(item["exam_time"]);
                    }
                    cmbExamTime.EditValue = ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)cmbExamTime.Edit).Items[0];
                }

            }
        }
        #endregion
        #region 获取值
        /// <summary>
        /// exam_type 考试类型
        /// </summary>
        string value_exam_type;
        /// <summary>
        /// guid 考试类型guid
        /// </summary>
        string value_exam_type_guid;
        /// <summary>
        /// 窗体加载时间
        /// </summary>
        /// <param name="value_exam_type"></param>
        /// <param name="value_guid"></param>
        public FrmExamNameList(string value_exam_type, string value_exam_type_guid) : this()
        {
            this.value_exam_type = value_exam_type;
            this.value_exam_type_guid = value_exam_type_guid;
            LoadData();
        }
        #endregion
        #region 刷新数据源
        /// <summary>
        /// 刷新
        /// </summary>
        public void LoadData()
        {
            var dt_exam_name_data = "select guid,exam_name,exam_time from ExamInfo where exam_type_guid=@exam_type_guid".ExecuteQuery(("@exam_type_guid", value_exam_type_guid));//获取考试名称
            gridControl.DataSource = dt_exam_name_data;
        }
        #endregion
        #region 刷新按钮
        /// <summary>
        /// 刷新按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }
        #endregion
        #region 查询按钮
        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            var exam_name = Convert.ToString(this.txtExamName.EditValue) ?? "";
            var exam_time = Convert.ToString(this.cmbExamTime.EditValue) ?? "";
            if (string.IsNullOrEmpty(exam_name) && exam_time == "无")//如果没有搜索内容
            {//执行刷新一遍
                LoadData();
                return;
            }
            if (exam_time == "无" && exam_name != "")
            {
                var dt_exam_name_data = "select * from ExamInfo where exam_name like @exam_name".ExecuteQuery(("@exam_name", "%" + exam_name + "%"));//查询题目信息

                gridControl.DataSource = dt_exam_name_data;
            }
            if (exam_time != "无" && string.IsNullOrEmpty(exam_name))
            {
                var dt_exam_name_data = "select * from ExamInfo where exam_time like @exam_year".ExecuteQuery(("@exam_year", "%" + exam_time + "%"));//查询题目信息
                gridControl.DataSource = dt_exam_name_data;
            }
            if (exam_time != "无" && exam_name != "")
            {
                var dt_exam_name_data = "select * from ExamInfo where exam_name like @exam_name and exam_time like @exam_time".ExecuteQuery(("@exam_name", "%" + exam_name + "%"), ("@exam_time", "%" + exam_time + "%"));//查询题目信息
                gridControl.DataSource = dt_exam_name_data;
            }
        }
        #endregion
        #region 添加按钮
        /// <summary>
        /// 添加按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddExamInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new FrmExamAddExamNameInfo(value_exam_type_guid,value_exam_type);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        #endregion
        #region 网格列表View
        /// <summary>
        /// 双击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            var value_guid = gridView.GetRowCellValue(gridView.FocusedRowHandle, col_guid).ToString();
            var value_exam_time = gridView.GetRowCellValue(gridView.FocusedRowHandle, col_exam_time).ToString();
            var value_exam_name = gridView.GetRowCellValue(gridView.FocusedRowHandle, col_exam_name).ToString();
            var frm = new FrmExamQuestionsList(value_guid, value_exam_time, value_exam_name, value_exam_type);
            frm.Show();
        }
        #endregion
    }
}
