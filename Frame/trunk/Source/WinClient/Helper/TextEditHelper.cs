using DevExpress.XtraBars;
using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinClient
{
   public static class TextEditHelper
    {
        public static void SetWatermark(this TextEdit textEdit, string watermark)
        {
            textEdit.Properties.NullValuePromptShowForEmptyValue = true;
            textEdit.Properties.NullValuePrompt = watermark;
        }
        public static void ClearWatermark(this TextEdit textEdit)
        {
            if (textEdit.Properties.NullValuePromptShowForEmptyValue)
                textEdit.Properties.NullValuePrompt = string.Empty;
        }
    }
}
