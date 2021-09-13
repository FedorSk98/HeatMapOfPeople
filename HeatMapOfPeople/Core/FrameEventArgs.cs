using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatMapOfPeople.Core
{
	class FrameEventArgs: EventArgs
	{
		public Image Frame { get; }

		public FrameEventArgs(Image image)
		{
			Frame = image;
		}
	}
}
