using SplitExcel.Repositories;
using SplitExcel.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcel.Service
{
	public interface IUserService
	{
		DataSet GetUsers();
		Task ProvisionDatabase();
	}

	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository UserRepository)
		{
			_userRepository = UserRepository;
		}
		public DataSet GetUsers()
		{
			return _userRepository.GetUsers();
		}
		async public Task ProvisionDatabase()
		{
			await _userRepository.ProvisionDatabase();
		}
	}
}
