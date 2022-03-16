using Moq;
using NUnit.Framework;
using SplitExcelTool.Model;
using SplitExcelTool.Repositories;
using SplitExcelTool.Service;

[TestFixture]
public class CategoryServiceTests
{
	[Test]
	public void ShouldBeAbleToCallPersonServiceAndGetPersonUseMoq()
	{
		var expected = new Category { CategoryName = "Test Category 1" };
		var categoryReposityMock = new Mock<ICategoryRepository>();
		categoryReposityMock.Setup(pr => pr.AddCategory(new Category { CategoryName = "Test Category 1" }))
		.Returns(new Category() { CategoryName = "Test Category 1" } );

		var categoryService = new CategoryService(categoryReposityMock.Object);
		var actual = categoryService.AddCategory(expected);

		Assert.AreEqual(expected.CategoryName, actual.CategoryName);
	}
}
