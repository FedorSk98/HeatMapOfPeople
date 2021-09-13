using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatMapOfPeople.Configuration
{
	class Connection
	{
		public string GetConfiguratuion()
		{
			string conString = "";
			try
			{
				conString = @"Data Source=" + Constants.DataSource + ";Initial Catalog=" + Constants.DataBase + ";Integrated Security=True;";
			}
			catch (Exception)
			{

			}
			return conString;
		}
		
	}
}
