using Ninject.Modules;
using SplitExcel.Repositories;
using SplitExcel.Repository;
using SplitExcel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcel.WPF
{
	public class CoreModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IUserRepository>().To<UserRepository>();
			Bind<ICoreRepository>().To<CoreRepository>();
			Bind<IUserService>().To<UserService>();
		}
	}
}
