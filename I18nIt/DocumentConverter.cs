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
                var workbook = xlsApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                var worksheet = workbook.Worksheets[1] as Worksheet;
                if (worksheet == null)
                {
                    return false;
                }

                var startRow = 1;
                worksheet.Name = "Text";
                worksheet.Cells[startRow, 1] = "Sl. No.";
                worksheet.Cells[startRow, 2] = "ID";
                worksheet.Cells[startRow, 3] = "Current message Text";
                worksheet.Cells[startRow, 4] = "Suggested Message by LENOVO in English";
                worksheet.Cells[startRow, 5] = "Translation in Chinese Language provided by LENOVO";
                worksheet.Cells[startRow, 6] = "Remarks";


                foreach (var enItem in englishDictionary)
                {
                    worksheet.Cells[++startRow, 1] = startRow -1;
                    worksheet.Cells[startRow, 2] = enItem.Key;
                    worksheet.Cells[startRow, 3] = enItem.Value;
                    worksheet.Cells[startRow, 4] = "";
                    var cnValue = "";
                    worksheet.Cells[startRow, 5] = localDictionary.TryGetValue(enItem.Key, out cnValue) ? cnValue : "";
                    worksheet.Cells[startRow, 6] = "";
                }

                workbook.Saved = true;
                workbook.SaveCopyAs(excelFileName);
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

        public bool ImportFromExcel(string importFile, string translateFile)
        {
            try
            {
                var xlsApp = new ApplicationClass();
                var workbook = xlsApp.Workbooks.Open(importFile,
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

                var cache = StringResourceCache.GetInstance();
                var startRow = 1;
                var rowsCount = worksheet.UsedRange.Rows.Count;
                for (var i = 0; i < rowsCount; i++)
                {
                    var id = worksheet.Cells[++startRow, 2] as Range;
                    var cnValue = worksheet.Cells[startRow, 5] as Range;
                    cache.Update(translateFile, id.Text as string, cnValue.Text as string);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
