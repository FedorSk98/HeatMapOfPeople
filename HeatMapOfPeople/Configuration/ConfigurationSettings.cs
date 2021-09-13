using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HeatMapOfPeople.Configuration
{
	class ConfigurationSettings
	{
		public void LoadConfiguration()
		{
			try
			{
				var configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(Constants.SettingsFileName));
		
				Constants.DataSource = configuration.DataSource;
				Constants.PathFile = configuration.PathFile;
				Constants.SizeRectangle = configuration.SizeRectangle;
				Constants.MaxSizePeople = configuration.MaxSizePeople;
				Constants.TimeGenerateReport = configuration.TimeGenerateReport;
				Constants.CountImageInReport = configuration.CountImageInReport;
				Constants.ColorGraycheckBox = configuration.ColorGraycheckBox;

				Constants.VideoResolutioncheckBox = configuration.VideoResolutioncheckBox;
				Constants.WidthVideo = configuration.WidthVideo;
				Constants.HeightVideo = configuration.HeightVideo;
				Constants.TimeAppendBD = configuration.TimeAppendBD;
				Constants.SelectIpCameracheckBox = configuration.SelectIpCameracheckBox;
				Constants.IDCamera = configuration.IDCamera;
				
			}
			catch (Exception e)
			{
				Log.Write("Errror Write Setting: "+e.Message);
				File.WriteAllText(Constants.SettingsFileName, JsonConvert.SerializeObject(new Configuration()
				{
					DataSource = Constants.DataSource,
					PathFile = Constants.PathFile,
					SizeRectangle = Constants.SizeRectangle,
					MaxSizePeople = Constants.MaxSizePeople,
					TimeGenerateReport = Constants.TimeGenerateReport,
					CountImageInReport = Constants.CountImageInReport,

					VideoResolutioncheckBox = Constants.VideoResolutioncheckBox,
					WidthVideo = Constants.WidthVideo,
					HeightVideo = Constants.HeightVideo,
					TimeAppendBD = Constants.TimeAppendBD,

					ColorGraycheckBox = Constants.ColorGraycheckBox,
					SelectIpCameracheckBox = Constants.SelectIpCameracheckBox, 
					IDCamera = Constants.IDCamera

				}));
			}

		}

		public void ChangeConfiguration(Configuration configuration)
		{
			File.WriteAllText(Constants.SettingsFileName, JsonConvert.SerializeObject(configuration));
			LoadConfiguration();
		}
	}
}
