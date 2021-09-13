using HeatMapOfPeople.DataStorage;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeatMapOfPeople.Core
{

	// new class / ----
	class HeatsMap
	{
		private readonly int widthFrame;
		private readonly int heightFrame;
		private int countX;
		private int countY;
		private int sizeRectangle;
		List<SquareHeatsMap> listSquare;

		public HeatsMap(int width, int height)
		{
			widthFrame = width;
			heightFrame = height;
			sizeRectangle = Constants.SizeRectangle;
			countX = widthFrame % sizeRectangle == 0 ? widthFrame / sizeRectangle : (int)(widthFrame / sizeRectangle) + 1;
			countY = heightFrame % sizeRectangle == 0 ? heightFrame / sizeRectangle : (int)(heightFrame / sizeRectangle) + 1;
			listSquare = new List<SquareHeatsMap>();
		}

		public void CreateGrid()
		{
			int numbersquare = 0;
			for (int i = 0; i <= countX; i++)
			{
				for (int j = 0; j <= countY; j++)
				{
					numbersquare++;
					listSquare.Add(new SquareHeatsMap() {
						X1 = (sizeRectangle * (i - 1)),
						Width = sizeRectangle,
						Y1 = (sizeRectangle * (j - 1)),
						Height = sizeRectangle
					});
				}
			}
		}

		public Bitmap SquareColoring(Bitmap bitmat, List<ObjectYolo> listyolo)
		{
			Graphics tempGraphicsImage = Graphics.FromImage(bitmat);
			Color fillColor;
			foreach (var list in listSquare)
			{
				var weight = list.IsIntersection(listyolo);

				fillColor = Color.FromArgb(0, 0, 0, 0);

				if (list.Weight > 0 && list.Weight < (Constants.MaxSizePeople/8))
				{
					fillColor = Color.FromArgb(255, 0, 0, 253);
				}
				else if (list.Weight >= (Constants.MaxSizePeople / 8) && list.Weight < (Constants.MaxSizePeople / 8)*2)
				{
					fillColor = Color.FromArgb(255, 0, 135, 255);
				}
				else if (list.Weight >= (Constants.MaxSizePeople / 8) * 2 && list.Weight < (Constants.MaxSizePeople / 8) * 3)
				{
					fillColor = Color.FromArgb(255, 0, 255, 171);
				}
				else if (list.Weight >= (Constants.MaxSizePeople / 8) * 3 && list.Weight < (Constants.MaxSizePeople / 8) * 4)
				{
					fillColor = Color.FromArgb(255, 0, 255, 31);
				}
				else if (list.Weight >= (Constants.MaxSizePeople / 8) * 4 && list.Weight < (Constants.MaxSizePeople / 8) * 5)
				{
					fillColor = Color.FromArgb(255, 173, 255, 0);
				}
				else if (list.Weight >= (Constants.MaxSizePeople / 8) * 5 && list.Weight < (Constants.MaxSizePeople / 8) * 6)
				{
					fillColor = Color.FromArgb(255, 237, 255, 2); 
				}
				else if (list.Weight >= (Constants.MaxSizePeople / 8) * 6 && list.Weight < (Constants.MaxSizePeople / 8) * 7)
				{
					fillColor = Color.FromArgb(255, 255, 134, 0);
				}
				else if (list.Weight >= (Constants.MaxSizePeople / 8) * 7)
				{
					fillColor = Color.FromArgb(255, 252, 0, 0);
				}

				tempGraphicsImage.FillRectangle(new SolidBrush(fillColor), list.X1, list.Y1, list.Width, list.Height);
			}
			return bitmat;
		}
	}
}
