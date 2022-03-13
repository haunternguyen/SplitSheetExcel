using SplitService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitExcelTool
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}



		private void btnChooseFile_Click(object sender, EventArgs e)
		{
			try
			{
				string fullFileName = null;
				using (var dlg = new OpenFileDialog())
				{
					dlg.CheckFileExists = false;

					dlg.ShowDialog();

					if (!string.IsNullOrEmpty(dlg.FileName))
					{
						fullFileName = dlg.FileName;
						var fileName = Path.GetFileName(fullFileName);
						var directoryName = fullFileName.Replace(fileName, "");
						SplitExcelService.Copy(directoryName, fullFileName, fileName);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.ToString());
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
