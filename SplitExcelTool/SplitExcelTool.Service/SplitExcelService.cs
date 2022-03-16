using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Spire.Xls;

namespace SplitExcelTool.Service
{

	public interface ISplitExcelService
	{
		public void SplitSheet(string directory, string fullUrl, string fileName);
	}

	public class SplitExcelService: ISplitExcelService
	{
		private static string _exportFileName = "";

		public void SplitSheet(string directory, string fullUrl, string fileName)
		{
			Workbook workbook = new Workbook();
			workbook.LoadFromFile(fullUrl);

			Worksheet sheet = workbook.Worksheets[0];

			int columnCount = sheet.Columns.Count();

			int startRow = 0;

			int endRow = 0;

			bool startRemove = false;
			bool endRemove = false;
			foreach (CellRange range in sheet.Columns[0])
			{
				if (range.Text == "Chức năng lấy mẫu")
				{

					var column = range.Column;
					startRow = range.Row;
					startRemove = true;
				}

				if (startRemove && range.Row != startRow + 1 && (endRemove == false))
				{
					if (range.Text == null)
					{

						endRow = range.Row;
						endRemove = true;
					}

				}

			}

			for (int currentRow = startRow + 2; currentRow <= endRow - 1; currentRow++)
			{
				Worksheet calculatedSheet = null;

				if (currentRow == startRow + 2)
				{
					calculatedSheet = workbook.CreateEmptySheet(currentRow.ToString());

					calculatedSheet.CopyFrom(sheet);
					calculatedSheet.DeleteRow(startRow + 3, endRow - 1 - startRow + 3);
				}
				else if (currentRow == endRow - 1)
				{
					calculatedSheet = workbook.CreateEmptySheet(currentRow.ToString());
					calculatedSheet.CopyFrom(sheet);

					calculatedSheet.DeleteRow(startRow + 2, currentRow - (startRow + 2));
				}
				else
				{
					calculatedSheet = workbook.CreateEmptySheet(currentRow.ToString());

					calculatedSheet.CopyFrom(sheet);
					var frontRange = currentRow - (startRow + 2);
					var frontPoint = startRow + 2;

					int endPoint = endRow - 1;

					var backPoint = startRow + 3;
					var backRange = endPoint - currentRow + 1;

					calculatedSheet.DeleteRow(frontPoint, frontRange);
					calculatedSheet.DeleteRow(backPoint, backRange);
				}
			}

			_exportFileName = directory + fileName + DateTime.Now.ToString("dd-MM-yyyy-hh-mm") + ".xlsx";

			workbook.SaveToFile(_exportFileName, ExcelVersion.Version2013);

			RemoveLastSheet();
		}

		private void RemoveLastSheet()
		{
			var xlApp = new Microsoft.Office.Interop.Excel.Application();

			if (xlApp == null)
			{
				return;
			}

			string filePath = _exportFileName;
			var xlWorkBook = xlApp.Workbooks.Open(filePath);

			var worksheets = xlWorkBook.Worksheets;
			xlApp.DisplayAlerts = false;
			worksheets[1].Delete();
			worksheets[worksheets.Count].Delete();
			xlApp.DisplayAlerts = true;

			xlWorkBook.Save();

			xlWorkBook.Close();

			Marshal.ReleaseComObject(worksheets);
			Marshal.ReleaseComObject(xlWorkBook);
			Marshal.ReleaseComObject(xlApp);
			//System.Diagnostics.Process.Start(_exportFileName);
		}
	}
}
