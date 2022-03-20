using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Spire.Xls;
using SplitExcelTool.Model;
using SplitExcelTool.Repositories;

namespace SplitExcelTool.Service
{
	public class PatientRow
	{
		public int Start { set; get; }
		public int End { set; get; }
		public int FistPatientRow { set; get; }

		public int LastPatientRow { set; get; }
	}

	public interface ISplitExcelService
	{
		public void SplitSheet(string directory, string fullUrl, string fileName);
	}

	public class SplitExcelService: ISplitExcelService
	{
		private static string _exportFileName = "";
		private readonly IPatientService _patientService;
		public SplitExcelService(IPatientService patientService)
		{
			_patientService = patientService;
		}
		public void SplitSheet(string directory, string fullUrl, string fileName)
		{
			Workbook workbook = new Workbook();
			workbook.LoadFromFile(fullUrl);

			Worksheet sheet = workbook.Worksheets[0];

			PatientRow patientRow = FindPatientRow(sheet);

			int startRow = patientRow.Start;

			int endRow = patientRow.End;

			var patients = RetrievePatientData(fullUrl);

			AddPatients(patients);

			ProccessRowByRow(startRow, endRow, sheet, workbook);

			_exportFileName = directory + fileName + DateTime.Now.ToString("dd-MM-yyyy-hh-mm") + ".xlsx";

			workbook.SaveToFile(_exportFileName, ExcelVersion.Version2013);
		}

		private void AddPatients(List<Patient> patients)
		{
			foreach(var patient in patients)
			{
				_patientService.AddPatient(patient);
			}
		}

		private List<Patient> RetrievePatientData(string fileUrl)
		{
			Workbook workbook = new Workbook();
			workbook.LoadFromFile(fileUrl);

			Worksheet summarySheet = workbook.Worksheets[0];

			PatientRow patientRow = FindPatientRow(summarySheet);

			var patientList = new List<Patient>();

			for(int i = patientRow.FistPatientRow; i<= patientRow.LastPatientRow; i++)
			{
				var patient = new Patient()
				{
					TestCode = summarySheet.Range[i, (int)PatientIndex.TestCode].Text,
					FullName = summarySheet.Range[i, (int)PatientIndex.FulllName].Text,
					Result = summarySheet.Range[i, (int)PatientIndex.Result].Text
				};
				patientList.Add(patient);
			}
			return patientList;
		}

		private PatientRow FindPatientRow(Worksheet summarySheet)
		{
			var patientRow = new PatientRow()
			{
				Start = 0,
				End = 0
			};

			bool startRemove = false;
			bool endRemove = false;

			foreach (CellRange range in summarySheet.Columns[0])
			{
				if (range.Text == "Chức năng lấy mẫu")
				{

					var column = range.Column;
					patientRow.Start = range.Row;
					startRemove = true;
				}

				if (startRemove && range.Row != patientRow.Start + 1 && (endRemove == false))
				{
					if (range.Text == null)
					{

						patientRow.End = range.Row;
						endRemove = true;
					}
				}
			}

			patientRow.FistPatientRow = patientRow.Start + 2;
			patientRow.LastPatientRow = patientRow.End - 1;
			return patientRow;
		}

		private void ProccessRowByRow(int startRow, int endRow, Worksheet summarySheet, Workbook workbook)
		{
			for (int currentRow = startRow + 2; currentRow <= endRow - 1; currentRow++)
			{
				bool isFistItem = currentRow == startRow + 2;
				bool isLastItem = currentRow == endRow - 1;

				if (isFistItem)
				{
					ProccessFirstItem(currentRow, startRow, endRow, summarySheet, workbook);
				}
				else if (isLastItem)
				{
					ProccessLastItem(currentRow, startRow, summarySheet, workbook);
				}
				else
				{
					ProccessMiddleItem(currentRow, startRow, endRow, summarySheet, workbook);
				}
			}
		}

		private void ProccessFirstItem(int currentRow, int startRow, int endRow, Worksheet summarySheet, Workbook workbook)
		{
			Worksheet calculatedSheet;

			calculatedSheet = workbook.CreateEmptySheet(currentRow.ToString());

			calculatedSheet.CopyFrom(summarySheet);
			int endRange = endRow - 1 - (startRow + 2);
			calculatedSheet.DeleteRow(startRow + 3, endRange);
		}
		private void ProccessLastItem(int currentRow, int startRow, Worksheet summarySheet, Workbook workbook)
		{
			Worksheet calculatedSheet;

			calculatedSheet = workbook.CreateEmptySheet(currentRow.ToString());
			calculatedSheet.CopyFrom(summarySheet);

			calculatedSheet.DeleteRow(startRow + 2, currentRow - (startRow + 2));
		}

		private void ProccessMiddleItem(int currentRow, int startRow, int endRow, Worksheet summarySheet, Workbook workbook)
		{
			Worksheet calculatedSheet;

			calculatedSheet = workbook.CreateEmptySheet(currentRow.ToString());

			calculatedSheet.CopyFrom(summarySheet);
			var frontRange = currentRow - (startRow + 2);
			var frontPoint = startRow + 2;

			int endPoint = endRow - 1;

			var backPoint = startRow + 3;
			var backRange = endPoint - currentRow + 1;

			calculatedSheet.DeleteRow(frontPoint, frontRange);
			calculatedSheet.DeleteRow(backPoint, backRange);
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
