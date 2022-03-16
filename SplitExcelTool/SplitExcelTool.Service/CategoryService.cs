using SplitExcelTool.Model;
using SplitExcelTool.Repositories;

namespace SplitExcelTool.Service
{
	public interface ICategoryService
	{
		Category AddCategory(Category category);
	}

	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		public Category AddCategory(Category category)
		{
			return _categoryRepository.AddCategory(category);
		}
	}
}