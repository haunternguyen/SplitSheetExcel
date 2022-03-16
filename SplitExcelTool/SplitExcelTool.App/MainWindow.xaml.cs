using Microsoft.Win32;
using Ninject;
using SplitExcelTool.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SplitExcelTool.App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly ISplitExcelService _splitExcelService;

		public MainWindow()
		{
			InitializeComponent();
			var kernel = new StandardKernel(new CoreModule());
			_splitExcelService = kernel.Get<ISplitExcelService>();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			string fullFileName = null;

			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = true;
				openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				if (openFileDialog.ShowDialog() == true)
				{
					fullFileName = openFileDialog.FileName;
					var fileName = System.IO.Path.GetFileName(fullFileName);
					var directoryName = fullFileName.Replace(fileName, "");
					_splitExcelService.SplitSheet(directoryName, fullFileName, fileName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.ToString());
			}
		}
	}
}
