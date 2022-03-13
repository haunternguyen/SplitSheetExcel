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
	public class User
	{
		public string FirstName { set; get; }
		public string LastName { set; get; }
	}

	public partial class MainWindow : Window
	{
		public ObservableCollection<User> Users { get; set; }


		public MainWindow()
		{
			InitializeComponent();

			Users = new ObservableCollection<User>() { new User { FirstName = "FirstName1", LastName = "LastName1" } };

			LoadGrid();

		}

		private void BtnCreateTable_Click(object sender, RoutedEventArgs e)
		{
			//SplitEcelRepositories.CreateTable();
		}

		private void BtnInsert_Click(object sender, RoutedEventArgs e)
		{
			//string strInsert = string.Format("INSERT INTO tbl_students(fullname, birthday, email, address, phone) VALUES('{0}','{1}','{2}','{3}','{4}')", "test fullname", "test birthday", "test email", "test address", "test phone");

			//string query = strInsert;
			//SplitEcelRepositories.QueryData(query);

		}

		private void LoadGrid()
		{
			var kernel = new StandardKernel(new CoreModule());
			var userService = kernel.Get<UserService>();


			var dtSet = userService.GetUsers();

			DataTable dt = dtSet.Tables[0];
			dataGrid.ItemsSource = dt.DefaultView;
		}
	}
}
