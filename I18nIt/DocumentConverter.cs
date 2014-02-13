using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace I18nIt
{
    public class DocumentConverter
    {
        public Boolean ExportToExcel(string excelFileName,
            Dictionary<string, string> englishDictionary,
            Dictionary<string, string> localDictionary)
        {
            try
            {
                var xlsApp = new ApplicationClass();
                var workbook = xlsApp.Workbooks.Open(excelFileName,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                var worksheet = workbook.Worksheets[1] as Worksheet;
                if (worksheet == null)
                {
                    return false;
                }

                var startRow = 1;
                worksheet.Name = "translation";
                worksheet.Cells[startRow, 1] = "ID";
                worksheet.Cells[startRow, 2] = "English text";
                worksheet.Cells[startRow, 3] = "Chinese text";

                foreach (var enItem in englishDictionary)
                {
                    worksheet.Cells[++startRow, 1] = enItem.Key;
                    worksheet.Cells[startRow, 2] = enItem.Value;
                    var cnValue = "";
                    worksheet.Cells[startRow, 3] = localDictionary.TryGetValue(enItem.Key, out cnValue) ? cnValue : "";
                }


                workbook.Close(true, Type.Missing, Type.Missing);
                workbook = null;
                xlsApp.Quit();
                xlsApp = null;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
