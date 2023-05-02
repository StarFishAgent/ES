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

namespace WinControl {
    public partial class AnRichBoxSingle : UserControl {
        public AnRichBoxSingle() {
            InitializeComponent();
            radioButton1.AutoCheck = false;
        }
        public void SetRtfText(string RtfText) {
            richEditControl.RtfText = Convert.FromBase64String(RtfText).ToRtxBytesString();
        }

        private void radioButton1_Click(object sender, EventArgs e) {
            if (radioButton1.Checked == true) {
                radioButton1.Checked = false;
            }
            else {
                SetRadioButtonChecked(Helper.GetPanel);
                radioButton1.Checked = true;
            }
        }

        /// <summary>
        /// 设置单选控件是否选择值
        /// </summary>
        /// <param name="StarFishPanel"></param>
        public void SetRadioButtonChecked(FlowLayoutPanel FlowPanel) {
            var count = FlowPanel.Controls.Count;//控件数量

            for (int i = 0; i < count; i++) {

                var ControlPro = (FlowPanel.Controls[i] as AnRichBoxSingle);

                (ControlPro.Controls[0] as RadioButton).Checked = false;
            }
        }

        private List<char> Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();//数组

        /// <summary>
        /// 获取单选控件选择的值
        /// </summary>
        /// <param name="guid">题目主键</param>
        /// <param name="id">序号(第几题)</param>
        /// <param name="OptionInfo">选项的True或False</param>
        /// <param name="listABCD">获取选中的ABCD</param>
        /// <returns></returns>
        public (DataTable, Dictionary<int, string>) GetRadioButtonCheckedValue(FlowLayoutPanel AnPanel, string guid, int id, DataTable OptionInfo, Dictionary<int, string> listABCD) {
            var count = AnPanel.Controls.Count;//控件数量
            var dtCount = OptionInfo.Rows.Count;
            DataRow dr = OptionInfo.NewRow();
            for (int i = 0; i < dtCount; i++) {
                DataRow drs = OptionInfo.Rows[i];
                if (Convert.ToInt32(drs["id"]) == id) {
                    dr = drs;
                    OptionInfo.Rows.RemoveAt(i);
                    break;
                }
            }
            dr["guid"] = guid;
            dr["id"] = id;
            for (int i = 0; i < count; i++) {
                var ControlPro = (AnPanel.Controls[i] as AnRichBoxSingle);
                var ControlRadioBtn = (ControlPro.Controls[0] as RadioButton);
                var TrueOrFalse = ControlRadioBtn.Checked;
                if (TrueOrFalse == true) {
                    listABCD[id] = ControlRadioBtn.Text;
                }
                dr[$"{Alpha[i]}"] = TrueOrFalse;
            }
            OptionInfo.Rows.Add(dr);
            return (OptionInfo, listABCD);
        }
    }
}
