using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatMapOfPeople.Core
{
	class ObjectYolo
	{
		private readonly int x;
		private readonly int y;
		private readonly int width;
		private readonly int height;

		public ObjectYolo(int x, int y, int width, int height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public int Height
		{
			get
			{
				return height;
			}
		}
		public int Width
		{
			get
			{
				return width;
			}
		}
		public int CenterX
		{
			get
			{
				return (x + (x + width)) / 2;
			}
		}
		public int CenterY
		{
			get
			{
				return (y + (y + height)) / 2;
			}
		}
	}
}
