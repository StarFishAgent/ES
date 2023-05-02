using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace WebServer {
    public static class ExamHelper {
        public static int CountExamResult(string ExamGuid,dynamic Answers) {
           var dt =  ToDataTable(Answers);
            return 100;
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
