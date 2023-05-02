using DevExpress.Pdf.ContentGeneration;
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

using WinClient.Properties;

using WinControl;
using WinControl.MyControl;

using ZXing;

namespace WinClient {
    public partial class FrmAnswerQ : XtraForm {
        public FrmAnswerQ() {
            InitializeComponent();

            OptionInfo.Columns.Add().ColumnName = "id";
            OptionInfo.Columns.Add().ColumnName = "guid";
            foreach (char ABCD in Alpha) {
                OptionInfo.Columns.Add().ColumnName = ABCD.ToString();
            }
        }
        bool is_con = false;
        DataTable dt_Subject_Info = new DataTable();
        DataTable dt_Subject_Child_Info = new DataTable();
        DataTable dt_Subject_Child_Option_Info = new DataTable();
        int qtimes = 0;//第几道题
        private List<char> Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();//数组
        DataTable OptionInfo = new DataTable();
        Dictionary<int, string> listABCD = new Dictionary<int, string>();

        /// <summary>
        /// 考试名称
        /// </summary>
        string exam_type_name;
        int exam_count;
        public FrmAnswerQ(string exam_type_name) : this() {
            this.exam_type_name = exam_type_name;

            SelectLoadQues(exam_type_name);

            is_con = true;
        }
        public void SelectLoadQues(string exam_type_name) {
            dt_Subject_Info = $@"select c.* from ExamTypeInfo as a inner join ExamInfo as b on b.exam_type_guid= a.guid and a.exam_type='{exam_type_name}'
inner join ExamSubjectInfo as c on c.exam_guid=b.guid order by c.ruid asc
".ExecuteQuery();//该科目下的所有题目信息
            exam_count = dt_Subject_Info.Rows.Count;
            if (dt_Subject_Info.Rows.Count == 0 || dt_Subject_Info == null) {
                MessageBox.Show("该科目下没有考试");
                is_con = false;
                return;
            }

            var Subject_guid = Convert.ToString(dt_Subject_Info.Rows[qtimes]["guid"]);

            dt_Subject_Child_Info = $@"select d.* from ExamTypeInfo as a  inner join ExamInfo as b on b.exam_type_guid= a.guid and a.exam_type='{exam_type_name}'
inner join ExamSubjectInfo as c on c.exam_guid=b.guid
inner join SubjectChildInfo as d on d.subject_guid=c.guid order by ruid asc".ExecuteQuery();//该科目下的所有子题信息

            if (dt_Subject_Child_Info.Rows.Count == 0 || dt_Subject_Child_Info == null) {
                MessageBox.Show("该科目下的不存在题目");
                is_con = false;
                return;
            }

            dt_Subject_Child_Option_Info = $@"select e.* from ExamTypeInfo as a  inner join ExamInfo as b on b.exam_type_guid= a.guid and a.exam_type='{exam_type_name}'
inner join ExamSubjectInfo as c on c.exam_guid=b.guid
inner join SubjectChildInfo as d on d.subject_guid=c.guid 
inner join SubjectChildOptionInfo as e on e.subject_child_guid=d.guid order by ruid asc".ExecuteQuery();//该科目下的所有子题选项信息

            if (dt_Subject_Child_Option_Info.Rows.Count == 0 || dt_Subject_Child_Option_Info == null) {
                MessageBox.Show("未添加题目信息");
                is_con = false;
                return;
            }
            LoadQuestion();
        }

        public void LoadQuestion() {

            richBoxController.SetRtfText(Convert.ToString(Convert.FromBase64String(dt_Subject_Info.Rows[qtimes]["subject_content2"].ToString()).ToRtxBytesString()));
            LoadOptions();
        }

        public void LoadOptions() {
            flowLayoutPanel.Controls.Clear();
            List<string> Options = new List<string>();
            AnPanelControlAll rePanelControlAll = new AnPanelControlAll();//声明一个装选项的容器控件
            flowLayoutPanel.Controls.Add(rePanelControlAll);//在容器中添加一个装选项的容器控件
            var controls = GetAnPanelControlAll();//获取装选项的容器控件
            var Child_Option = dt_Subject_Child_Option_Info.Select($@"subject_child_guid='{GetChildGuid()}'");
            for (int i = 0; i < Child_Option.Count(); i++) {
                DataRow itemDR = Child_Option[i];
                Options.Add(Convert.ToString(itemDR["option_content2"]));
            }
            var row = OptionInfo.Select($@"guid='{GetChildGuid()}'");
            if (row.Count() > 0) {
                controls.AddOptionSingle(Options, Child_Option.Count(), row[0]);
            }
            else {
                controls.AddOptionSingle(Options, Child_Option.Count());
            }
            
        }

        /// <summary>
        /// 获取子题Guid
        /// </summary>
        /// <returns></returns>
        public string GetChildGuid() {
            var Subject_guid = Convert.ToString(dt_Subject_Info.Rows[qtimes]["guid"]);
            var Child = dt_Subject_Child_Info.Select($@"subject_guid='{Subject_guid}' ");
            return Convert.ToString(Child[0]["guid"]);//获取子题目guid
        }
        /// <summary>
        /// 获取控件AnPanelControlAll
        /// </summary>
        /// <returns></returns>
        public AnPanelControlAll GetAnPanelControlAll() {
            return flowLayoutPanel.Controls[0] as AnPanelControlAll;
        }

        public void GetOptionInfo(int id) {
            var Control = GetAnPanelControlAll();
            var Results = Control.GetOptionInfo(GetChildGuid(), id, OptionInfo, listABCD);
            OptionInfo = Results.Item1;
            listABCD = Results.Item2;
        }

        #region 窗体
        /// <summary>
        /// 窗体加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAnswerQ_Load(object sender, EventArgs e) {
            if (is_con == false) {
                this.Close();
                this.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// 上一题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e) {
            btnLast.Enabled = false;
            if (qtimes == 0 || qtimes == -1) {
                btnLast.Enabled = true;
                MessageBox.Show("前面没有题目了哦");
                return;
            }
            else {
                GetOptionInfo(qtimes);
                qtimes--;
                LoadQuestion();
            }
            btnLast.Enabled = true;
        }

        /// <summary>
        /// 下一题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e) {

            btnNext.Enabled = false;
            if (exam_count - 1 == qtimes) {
                btnNext.Enabled = true;
                MessageBox.Show("这已经是最后一题了");
                return;
            }
            else {
                GetOptionInfo(qtimes);
                qtimes++;
                LoadQuestion();
            }
            btnNext.Enabled = true;
        }
    }
}
