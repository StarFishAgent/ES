
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace WinClient
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        private List<char> Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();//数组
        private void Test_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteQuery("select * from UserInfo");
           var aw= SqlHelper.GetExamResult("", dt);
        }

        public static DataTable ToDataTable(dynamic items) {
            DataTable dtDataTable = new DataTable();
            if (items.Count == 0)
                return dtDataTable;

            ((IEnumerable)items[0]).Cast<dynamic>().Select(p => p.Name).ToList().ForEach(col => { dtDataTable.Columns.Add(col); });

            ((IEnumerable)items).Cast<dynamic>().ToList().
            ForEach(data => {
                DataRow dr = dtDataTable.NewRow();
                ((IEnumerable)data).Cast<dynamic>().ToList().ForEach(Col => { dr[Col.Name] = Col.Value; });
                dtDataTable.Rows.Add(dr);
            });
            return dtDataTable;
        }
    }
}
