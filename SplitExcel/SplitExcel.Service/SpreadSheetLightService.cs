using Microsoft.Office.Interop.Excel;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcel.Service
{
	public class SpreadSheetLightService
	{
		public static void proccessData()
		{
			//Application application = new Application();
			//string surceFile = @"D:\External\ExcelData\KQ BN 07.03.22.xls";
			//string targetFile = @"D:\External\ExcelData\test.xls";
			//Workbook workbook = application.Workbooks.Open(surceFile);
			//Workbook workbook1 = application.Workbooks.Open(targetFile);
			//Worksheet worksheet = (Worksheet)workbook.Worksheets["BM danh sach KQ"];

			//worksheet.Copy(workbook1.Worksheets[1]);

			//workbook1.Save();
			//workbook.Close();
			//workbook1.Close();
			//application.Quit();

			//Console.WriteLine("End of program");
			//Console.ReadLine();
			CreateExcelFile();
		}

		public static void CreateExcelFile()
		{
			Application xlApp = new Application();

			if (xlApp == null)
			{
				Console.Write("Excel is not properly installed!!");
				return;
			}


			string surceFile = @"D:\External\ExcelData\KQ BN 07.03.22.xls";
			Workbook workbook = xlApp.Workbooks.Open(surceFile);


			Workbook xlWorkBook;
			xlWorkBook = xlApp.Workbooks.Add(1);

			Worksheet worksheet = (Worksheet)workbook.Worksheets["BM danh sach KQ"];

			worksheet.Copy(xlWorkBook.Worksheets[1]);

			//xlWorkBook.Save();
			workbook.Close();
			//xlWorkBook.Close();


			object misValue = System.Reflection.Missing.Value;
			copyWorkSheet(xlWorkBook, worksheet);
			xlWorkBook.SaveAs(@"D:\External\ExcelData\ExcelDatacsharp-xls", XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

			xlWorkBook.Close(true, misValue, misValue);

			xlApp.Quit();



			//Marshal.ReleaseComObject(xlWorkSheet);

			Marshal.ReleaseComObject(xlWorkBook);

			Marshal.ReleaseComObject(xlApp);



			Console.Write("Excel file created , you can find the file d:\\csharp-xls");
		}

		public static void copyWorkSheet(Workbook xlWorkBook, Worksheet sourceWorkSheet)
		{

			Worksheet worksheet1 = (Worksheet)xlWorkBook.Worksheets[1];

			int count = xlWorkBook.Worksheets.Count;

			xlWorkBook.Sheets[2].Delete();
			//Excel.Worksheet worksheet3 = (Worksheet)Application.ActiveWorkbook.Worksheets[3]);
			//worksheet1.Copy(worksheet3);
			for (int i = 0; i < 1; i++)
			{
				//Worksheet newWorksheet;
				//newWorksheet = xlWorkBook.ActiveSheet;


				//if (i == 0)
				//{
				//	xlWorkBook.Sheets[1].Delete();
				//}


				//newWorksheet = xlWorkBook.Worksheets.Add(After: xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);

				//newWorksheet = xlWorkBook.Sheets[xlWorkBook.Sheets.Count];

				//newWorksheet.Name = "StudentRepoertCard" + i.ToString();
				worksheet1.Copy(After: xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);

				//worksheet1.Rows[]

				//worksheet1.Name = "test " +i.ToString();

				//newWorksheet.Cells[1, 1] = "ID";

				//newWorksheet.Cells[1, 2] = "Name";

				//newWorksheet.Cells[2, 1] = "1";

				//newWorksheet.Cells[2, 2] = "One";

				//newWorksheet.Cells[3, 1] = "2";

				//newWorksheet.Cells[3, 2] = "Two";


				//Marshal.ReleaseComObject(newWorksheet);

			}
		}
	}
}
