using Ninject;
using SplitExcel.Repositories;
using SplitExcel.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace SplitExcel.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IUserService _userService;

		public MainWindow()
		{
			InitializeComponent();

			var kernel = new StandardKernel(new CoreModule());
			_userService = kernel.Get<IUserService>();
			_userService.ProvisionDatabase();

			LoadGrid();

		}

		async private void BtnCreateTable_Click(object sender, RoutedEventArgs e)
		{
			await _userService.ProvisionDatabase();
		}

		private void BtnInsert_Click(object sender, RoutedEventArgs e)
		{
			//string strInsert = string.Format("INSERT INTO tbl_students(fullname, birthday, email, address, phone) VALUES('{0}','{1}','{2}','{3}','{4}')", "test fullname", "test birthday", "test email", "test address", "test phone");

			//string query = strInsert;
			//SplitEcelRepositories.QueryData(query);
			Test();

		}

		private void LoadGrid()
		{
			var dtSet = _userService.GetUsers();

			DataTable dt = dtSet.Tables[0];
			dataGrid.ItemsSource = dt.DefaultView;
		}

		public void Test()
		{
			try
			{
				//DatabaseContext context = new DatabaseContext();
				//Console.WriteLine("Enter Employee name");
				//string name = Console.ReadLine();
				//Console.WriteLine("Enter Salary");
				//double salary = Convert.ToDouble(Console.ReadLine());
				//Console.WriteLine("Enter Designation");
				//string designation = Console.ReadLine();
				//EmployeeMaster employee = new EmployeeMaster()
				//{
				//	fullname = "Full name 1"
				//};
				//context.EmployeeMaster.Add(employee);
				//context.SaveChanges();
			}
			catch(Exception ex)
			{
				var test = ex;
			}
			
		}

		private void BtnInsert_Click_1(object sender, RoutedEventArgs e)
		{
			Test();
		}
	}
}
