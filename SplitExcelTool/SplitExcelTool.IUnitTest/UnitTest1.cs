using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SplitExcelTool.Model;
using SplitExcelTool.Repositories;
using SplitExcelTool.Service;
using Xunit.Sdk;

namespace SplitExcelTool.IUnitTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var expected = new Category { CategoryID = 102, CategoryName = "9999" };
			var expectedMock = new Category { CategoryID = 102, CategoryName = "2222" };

			var categoryReposityMock = new Mock<ICategoryRepository>();
			categoryReposityMock.Setup(pr => pr.AddCategory(expected))
			.Returns(expectedMock);

			var categoryService = new CategoryService(categoryReposityMock.Object);
			var actual = categoryService.AddCategory(expected);

			Assert.AreEqual(expected.CategoryName, actual.CategoryName);
		}

		[TestMethod]
		public void ShoudGetCorrectPatientsByTestCode()
		{
			var expected = new Patient
			{
				TestCode = "U07B012202198",
				FullName = "PHAN THANH THANH",
				Result = "ÂM TÍNH"
			};

			var expectedMock = new Patient
			{
				TestCode = "U07B012202198",
				FullName = "PHAN THANH THANH 2",
				Result = "ÂM TÍNH"
			};

			var patientReposityMock = new Mock<IPatientRepository>();
			patientReposityMock.Setup(pr => pr.GetPatientByTestCode(expectedMock.TestCode))
			.Returns(expectedMock);

			var patientService = new PatientService(patientReposityMock.Object);
			var actual = patientService.GetPatientByTestCode(expected.TestCode);

			Assert.AreEqual(expected.FullName, actual.FullName);
		}
	}
}