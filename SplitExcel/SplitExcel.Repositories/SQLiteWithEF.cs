using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcel.Repositories
{
	//[Table("tbl_students")]
	//public class EmployeeMaster
	//{
	//	[Key]
	//	public string fullname { get; set; }
	//}

	//public class DatabaseContext : DbContext
	//{
	//	public DatabaseContext() :
	//		base(new SQLiteConnection()
	//		{
	//			ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "Data Source=MyDatabase.sqlite;Version=3;", ForeignKeys = true }.ConnectionString
	//		}, true)
	//	{
	//	}
	//	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	//	{
	//		modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
	//		base.OnModelCreating(modelBuilder);
	//	}

	//	public DbSet<EmployeeMaster> EmployeeMaster { get; set; }

	//}
	//public class Category
	//{
	//	public int CategoryID { get; set; }
	//	public string CategoryName { get; set; }

	//}
	//public class SampleDBContext : DbContext
	//{
	//	private static bool _created = false;
	//	public SampleDBContext()
	//	{
	//		if (!_created)
	//		{
	//			_created = true;
	//			//Database.EnsureDeleted();
	//			//Database.EnsureCreated();
	//		}
	//	}
	//	protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
	//	{
	//		optionbuilder.UseSqlite(@"Data Source=d:\Sample.db");
	//	}

	//	public DbSet<Category> Categories { get; set; }
	//}
}
