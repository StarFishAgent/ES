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
    public partial class FrmExamAddType : XtraForm
    {
        /// <summary>
        /// 添加题目类型窗体
        /// </summary>
        public FrmExamAddType()
        {
            InitializeComponent();
            #region 常用代码
            AutoScaleMode = AutoScaleMode.None;//窗体自动缩放
            FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            MaximizeBox = false;//禁止最大化
            StartPosition = FormStartPosition.CenterScreen;//窗体居中
            #endregion
            Format();
        }
        public void Format()
        {
            string[] str =new string[] { "语文","数学","英语","政治", "物理", "化学", "历史", "地理", "生物", "学习强国" } ;
            cmbExamType.Properties.Items.AddRange(str);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var exam_type = this.cmbExamType.Text.Trim();
            if (string.IsNullOrEmpty(exam_type))
            {
                MessageBox.Show("请输入要添加的类型");
                return;
            }
            {
                var dt = $@"select * from ExamTypeInfo where exam_type=@exam_type".ExecuteQuery(("@exam_type", exam_type));
                if (dt != null && dt.Rows.Count > 0)
                {
                    MessageBox.Show("该类型已存在");
                    return;
                }
                else
                {
                    "insert into ExamTypeInfo(exam_type)values(@exam_type)".ExecuteNonQuery(("@exam_type", exam_type, typeof(string).FullName));
                    MessageBox.Show("添加成功");
                    Close();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnAddYear_Click(object sender, EventArgs e)
        {
            

        }

        
    }
}
