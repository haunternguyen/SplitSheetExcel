using Moq;
using Ninject;
using SplitExcelTool;
using SplitExcelTool.Model;
using SplitExcelTool.Repositories;
using SplitExcelTool.Service;
using static SplitExcelTool.Repositories.DatabaseRepositoryBase;

//CategoryRepository category = new CategoryRepository();
//category.AddCategory(new Category() { CategoryName = "99" } );

//var kernel = new StandardKernel(new CoreModule());
//var categoryService = kernel.Get<CategoryService>();
//var category = categoryService.AddCategory(new Category() { CategoryName = "9999" });
//Console.ReadLine();

//var expected = new Category { CategoryID = 102, CategoryName = "9999" };

//var categoryReposityMock = new Mock<ICategoryRepository>();
//categoryReposityMock.Setup(pr => pr.GetCategory(102))
//.Returns(new Category { CategoryID = 102, CategoryName = "9999" });

//var categoryService = new CategoryService(categoryReposityMock.Object);
//var actual = categoryService.AddCategory(expected);

var categoryName = DateTime.Now.ToString("MM/dd/yyyy H:mm");
var expected = new Category { CategoryName = categoryName };

//var categoryReposityMock = new Mock<ICategoryRepository>();
//categoryReposityMock.Setup(pr => pr.AddCategoryMock(expected))
//.Returns(expected);


var kernel = new StandardKernel(new CoreModule());
var categoryRepository = kernel.Get<ICategoryRepository>();

var categoryService = new CategoryService(categoryRepository);
//var actual = categoryService.AddCategoryMock(expected);


var test = 1;

//Assert.AreEqual(expected.CategoryName, actual.CategoryName);