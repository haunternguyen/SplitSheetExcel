using SplitExcelTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcelTool.Repositories
{
	public interface ICategoryRepository
	{
		Category AddCategory(Category category);
	}

	public class CategoryRepository : DatabaseRepositoryBase, ICategoryRepository
	{
		public Category AddCategory(Category category)
		{
			DataContext.Categories.Add(category);
			DataContext.SaveChanges();

			return category;
		}
	}
}
