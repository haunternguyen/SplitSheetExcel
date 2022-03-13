﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcel.Repositories
{

	public interface ICoreRepository
	{
		DataSet RetrieveData();
	}
	public class CoreRepository : ICoreRepository
	{

		private readonly SQLiteConnection _con;

		public DataSet RetrieveData()
		{
			string query = "select id, fullname as [Full Name], email as [Email], address as [Address], phone as [Phone], birthday as [Birthday] from tbl_students";
			return GetQueryData(query);
		}

		public CoreRepository()
		{
			_con = new SQLiteConnection();
		}

		private void CreateConection()
		{
			string _strConnect = "Data Source=MyDatabase.sqlite;Version=3;";
			_con.ConnectionString = _strConnect;
			_con.Open();
		}

		private void CloseConnection()
		{
			_con.Close();
		}

		private DataSet GetQueryData(string sql)
		{
			DataSet ds = new DataSet();

			CreateConection();
			SQLiteDataAdapter da = new SQLiteDataAdapter(sql, _con);

			da.Fill(ds);
			CloseConnection();
			return ds;
		}
	}
}
