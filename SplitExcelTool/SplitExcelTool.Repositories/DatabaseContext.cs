using Microsoft.EntityFrameworkCore;
using SplitExcelTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcelTool.Repositories
{
	public sealed class DatabaseContext : DbContext
	{
		private static DatabaseContext _databaseContext;

		private DatabaseContext()
		{
			Database.EnsureCreated();
		}

		public static DatabaseContext GetDatabaseContext()
		{
			if (_databaseContext == null)
			{
				_databaseContext = new DatabaseContext();
			}
			return _databaseContext;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
		{
			optionbuilder.UseSqlite(@"Data Source=Sample.db");
		}
		public DbSet<Category> Categories { get; set; }

	}
}
