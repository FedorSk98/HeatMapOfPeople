using HeatMapOfPeople.DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatMapOfPeople.Core
{
	class ReportBD
	{
		public int time_filter;
		DateTime lastTimebd;
		bool eventDetect;
		bool onewrite;

		public ReportBD()
		{
			time_filter = Constants.TimeAppendBD;
			lastTimebd = default(DateTime);
			eventDetect = true;
			onewrite = false;
		}

		public int ActionGap()
		{
			if (lastTimebd == default(DateTime)&& eventDetect)
			{
				lastTimebd = DateTime.Now;
				eventDetect = false;
			}
	
			if (((DateTime.Now - lastTimebd).TotalSeconds > time_filter && !eventDetect)|| !onewrite)
			{
				Log.Write("Время прошло: "+ (DateTime.Now - lastTimebd).TotalSeconds.ToString());
				lastTimebd = default(DateTime);
				eventDetect = true;
				onewrite = true;
				return 1;
			}
			return 0;
		}
	}

	
}
