using Microsoft.EntityFrameworkCore;
using Ninject;
using SplitExcelTool.Model;

namespace SplitExcelTool.Repositories
{
	public class DatabaseRepositoryBase
	{
		protected DatabaseContext _dataContext;
		public DatabaseContext DataContext
		{
			get
			{
				if (_dataContext == null)
				{
					_dataContext = DatabaseContext.GetDatabaseContext(); ;
				}
				return _dataContext;
			}
		}
	}

	
}