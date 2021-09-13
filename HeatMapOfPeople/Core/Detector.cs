using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alturos.Yolo;
using HeatMapOfPeople.DataStorage;
using OpenCvSharp;
using PdfSharp.Pdf;
using Point = System.Drawing.Point;


namespace HeatMapOfPeople.Core
{
	class Detector
	{
		public event EventHandler<FrameEventArgs> ImageOutput;
		private readonly YoloWrapper _yoloWrapper;
		private Report report;
		private ReportBD reportBD;
		DateTime timeDelta;
		DBHeatsMap dBHeatsMap;
		public string ProcessExecution { get; private set;}
		bool databasewrite;

		public Detector()
		{
			_yoloWrapper = new YoloWrapper(YoloGetConfiguration(), Constants.NoGPUEnabled);
			ProcessExecution = "";
		}

		private YoloConfiguration YoloGetConfiguration()
		{
			var configurationYolo = new ConfigurationDetector();
			var config = configurationYolo.Detect(Constants.ResourcesFolder);
			return config;
		}

		 public void AnalysisVideoStream()//PictureBox panelVideo)
		{
			ProcessExecution = "Анализ видеопотока";
			/*dBHeatsMap = new DBHeatsMap();
			try
			{
                ProcessExecution = "Подключение к бд...";
                dBHeatsMap.Connect();
				databasewrite = true;
			}
			catch(Exception ex)
			{
				dBHeatsMap.Close();
				databasewrite = false;
				ProcessExecution = "Нет соеденения с бд!";
			}*/
			try { 
			report = new Report();
			reportBD = new ReportBD();
			var imageFrame = new Mat();
			Bitmap bitmap = null;
			HeatsMap heatsMap;
			var capture = Constants.SelectIpCameracheckBox ? new VideoCapture("rtsp://" + Constants.PathFile + "/") : new VideoCapture(Constants.PathFile);
			int sleepTime = (int)Math.Round(1000 / capture.Fps);

			if (Constants.VideoResolutioncheckBox)
			{
				heatsMap = new HeatsMap(Constants.WidthVideo, Constants.HeightVideo);
			}
			else
			{
				Constants.WidthVideo = capture.FrameWidth;
				Constants.HeightVideo = capture.FrameHeight;
				heatsMap = new HeatsMap(Constants.WidthVideo, Constants.HeightVideo);
			}
			heatsMap.CreateGrid();

                do
                {

                    timeDelta = DateTime.Now;
                    capture.Read(imageFrame);
                    if (imageFrame.Empty()) break;
                    imageFrame = imageFrame.Resize(new OpenCvSharp.Size(Constants.WidthVideo, Constants.HeightVideo));

                    var items = _yoloWrapper.Detect(imageFrame.ToBytes()).ToList();
                    var listPeopleFrame = new List<ObjectYolo>();

                    if (Constants.ColorGraycheckBox)
                    {
                        imageFrame = imageFrame.CvtColor(ColorConversionCodes.BGR2GRAY);
                        imageFrame = imageFrame.CvtColor(ColorConversionCodes.GRAY2RGB);
                    }


                    foreach (var u in items)
                    {
                        if (u.Type == "person" && u.Confidence >= Constants.PeopleConfidence)
                        {
                            listPeopleFrame.Add(new ObjectYolo(u.X, u.Y, u.Width, u.Height));
                           /// Cv2.Rectangle(imageFrame, new OpenCvSharp.Point(u.X, u.Y), new OpenCvSharp.Point(u.X + u.Width, u.Y + u.Height), Scalar.Red, 2);
                        }
                    }
                    bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageFrame);
                    bitmap = heatsMap.SquareColoring(bitmap, listPeopleFrame);
                    report.ReportsCreation(bitmap);

                    ImageOutput.Invoke(this, new FrameEventArgs(bitmap));

                  /*  if (reportBD.ActionGap() == 1)
                    {
                        dBHeatsMap.ADD(Constants.IDCamera, listPeopleFrame.Count);
                        if (dBHeatsMap.Status != null) ProcessExecution = dBHeatsMap.Status;
                    };*/

                    if ((DateTime.Now - timeDelta).Milliseconds < sleepTime)
                    {
                        Cv2.WaitKey(sleepTime - (DateTime.Now - timeDelta).Milliseconds);
                    }
                    GC.Collect();
                } while (Constants.PLAYFLAG);
        //	report.ReportsCreation(bitmap);
                ProcessExecution = "Остановлен";
			}catch(Exception ex)
			{
				ProcessExecution = $"Ошибка: {ex.Message}";
			}
			finally
			{
				Constants.PLAYFLAG = false;
				GC.Collect();
			}
		}
	}
}


