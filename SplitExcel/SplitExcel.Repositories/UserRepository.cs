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
	}

	public class UserRepository : IUserRepository
	{
		private readonly DataSet _userList;
		private readonly ICoreRepository _coreRepository;

		public UserRepository(ICoreRepository CoreRepository)
		{
			_coreRepository = CoreRepository;
			_userList = _coreRepository.RetrieveData();
		}

		public DataSet GetUsers()
		{
			return _userList;
		}
	}
}
