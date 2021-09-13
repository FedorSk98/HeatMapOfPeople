using HeatMapOfPeople.DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatMapOfPeople.Core
{
	class SquareHeatsMap
	{
		public int X1 { get; set; }
		public int Y1 { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public int Weight { get; set; }

		public SquareHeatsMap()
		{
			Weight = 0;
		}

		public int IsIntersection(List<ObjectYolo> list)
		{
			foreach (var listpeole in list)
			{
				if (
					(listpeole.CenterX + 1>= X1 || listpeole.CenterX >= X1 || listpeole.CenterX - 1 >= X1) && 
					(listpeole.CenterX - 1 <= (X1 + (X1 + Width)) / 2 || listpeole.CenterX + 1 <= (X1 + (X1 + Width)) / 2 || listpeole.CenterX <= (X1 + (X1 + Width)) / 2 )&& //
					(listpeole.CenterY - 1 >= Y1||listpeole.CenterY + 1 >= Y1 || listpeole.CenterY >= Y1) && 
					(listpeole.CenterY - 1 <= (Y1 + (Y1 + Height)) / 2 || listpeole.CenterY + 1 <= (Y1 + (Y1 + Height)) / 2 || listpeole.CenterY <= (Y1 + (Y1 + Height)) / 2)  //
					)
				{
					Weight += 1;
				}
			}
			return Weight;
		}
	}
}
