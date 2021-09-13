using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatMapOfPeople
{
	public static class Constants
	{
		public static string ResourcesFolder = "Resources/";
		public static bool NoGPUEnabled = false;

		public static string VideoFilter = @"Video file| *.avi; *.mp4";
		public static string DataSource = @"LAPTOP-VHB0HU49\SQLEXPRESS";
		public static string PathFile = "...";
		public static string DataBase = "HeatMapDataBase"; 

		public static int SizeRectangle = 5;
		public static int MaxSizePeople = 80;
	
		public static int TimeGenerateReport = 60; //---
		public static int CountImageInReport = 10;
		public static double PeopleConfidence = 0.5;

		public static bool VideoResolutioncheckBox = false;
		public static int WidthVideo = 680;
		public static int HeightVideo = 360;

		public static int TimeAppendBD = 30;
		public static bool PLAYFLAG = false;
		public static string SettingsFileName = "Resources/Settings.json";

		public static bool ColorGraycheckBox = true;
		public static bool SelectIpCameracheckBox = false;
		public static int IDCamera = 1;

		//	public static bool addSquare = false;
		//	public static int TimeStop = 30;
		//	
		//	public static int PageFilter = 5;
	}
}
