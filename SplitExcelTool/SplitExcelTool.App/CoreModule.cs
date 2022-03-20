using Ninject.Modules;
using SplitExcelTool.Repositories;
using SplitExcelTool.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcelTool.App
{
	public class CoreModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ICategoryRepository>().To<CategoryRepository>();
			Bind<ICategoryService>().To<CategoryService>();
			Bind<ISplitExcelService>().To<SplitExcelService>();
			Bind<IPatientRepository>().To<PatientRepository>();
			Bind<IPatientService>().To<PatientService>();

		}
	}
}
