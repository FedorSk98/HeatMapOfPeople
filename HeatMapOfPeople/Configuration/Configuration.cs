using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatMapOfPeople.Configuration
{
	class Configuration
	{
		public string DataSource { get; set; }
		public string PathFile { get; set; }
		public int SizeRectangle { get; set; }
		public int MaxSizePeople { get; set; }
		public int TimeGenerateReport { get; set; }
		public int CountImageInReport{ get; set; }

		public  bool VideoResolutioncheckBox { get; set; }
		public  bool SelectIpCameracheckBox { get; set; }
		public int WidthVideo { get; set; }
		public int HeightVideo { get; set; }
		public int TimeAppendBD { get; set; }
		public bool ColorGraycheckBox { get; set; }
		public int IDCamera { get; set; }
	}
}
