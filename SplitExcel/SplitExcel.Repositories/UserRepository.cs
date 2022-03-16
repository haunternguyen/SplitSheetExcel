using SplitExcel.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcel.Repository
{

	public interface IUserRepository
	{
		DataSet GetUsers();
		Task ProvisionDatabase();
	}

	public class UserRepository : IUserRepository
	{
		private DataSet _userList;
		private readonly ICoreRepository _coreRepository;

		public UserRepository(ICoreRepository CoreRepository)
		{
			_coreRepository = CoreRepository;
			
		}

		public DataSet GetUsers()
		{
			_userList = _coreRepository.RetrieveData();
			return _userList;
		}

		async public Task ProvisionDatabase()
		{
			await _coreRepository.CreateDatabaseFile();
		}

	}
}
