using HeatMapOfPeople.Configuration;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatMapOfPeople.DataStorage
{
	class DBHeatsMap
	{
		private SqlConnection _sqlConnection;
		public string Status { get; private set; }

		public void Connect()
		{
			_sqlConnection = new SqlConnection(new Connection().GetConfiguratuion());
			_sqlConnection.Open();
		}

		public void ADD(int idcam, int count)
		{
			try
			{
				string query = "INSERT INTO ResultOfPeople (DATEDETECT, TIMEDETECT, COUNTPEOPLE, IDCAMERA) VALUES('" + DateTime.Now.ToShortDateString() +
					"', '" + DateTime.Now.ToLongTimeString() + "', " + count + ", " + idcam + ");";
				SqlCommand sqlAdd = new SqlCommand(query, _sqlConnection);
				sqlAdd.ExecuteNonQuery();
				Status = null;
			}
			catch(Exception ex)
			{
				Status = "Ошибка добавления записи в базу данных!";
			}
		}

		public void Close()
		{
			_sqlConnection.Close();
		}
	}
}
