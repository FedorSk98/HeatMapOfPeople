using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp;
using OpenCvSharp;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace HeatMapOfPeople.Core
{
	class Report
	{
		public PdfDocument doc;
		public int page_index;
		public int page_filter;
		public int time_filter;
		public double time_add_image;
		DateTime lastTimebd;
		bool start_write_report;
		string report_filename;
		string report_path;
		bool eventDetect;
		bool onewrite;

		public Report()
		{
			page_index = 0;
			page_filter = Constants.CountImageInReport;
			Log.Write("page_filter"  + page_filter);
			time_filter = Constants.TimeGenerateReport;
			lastTimebd = default(DateTime);
			start_write_report = false;

			report_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Report");
			if (!Directory.Exists(report_path)) Directory.CreateDirectory(report_path);

			eventDetect = true;
			time_add_image = time_filter/ page_filter;
		}
		
		public void ReportsCreation(Bitmap mat)
		{
			if (lastTimebd == default(DateTime) && eventDetect)
			{
				start_write_report = true;
				report_filename = DateTime.Now.ToString() + ".pdf";
				report_filename = report_filename.Replace(':', '_');
				report_filename = report_filename.Replace(' ', '_');
				report_filename = report_path + @"\" + report_filename;
				doc = new PdfDocument();
				lastTimebd = DateTime.Now;
				onewrite = true;
				Log.Write("Старт формирования отчета: " + report_filename);
			}
			if (start_write_report && eventDetect)
			{
				if ((DateTime.Now - lastTimebd).TotalSeconds > time_add_image || onewrite)
				{
					onewrite = false;
					try
					{
						var res_tmp = OpenCvSharp.Extensions.BitmapConverter.ToMat(mat).Resize(new OpenCvSharp.Size(800, 450));
						var stream = res_tmp.ToMemoryStream(".jpeg", new ImageEncodingParam(ImwriteFlags.JpegOptimize, 50));
						XImage img = XImage.FromStream(stream);
						XFont font = new XFont("Verdana", 14, XFontStyle.Regular);
						var page = new PdfPage();
						page.Size = PageSize.A5;
						page.Orientation = PageOrientation.Landscape;
						doc.Pages.Add(page);
						XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[page_index]);
						xgr.DrawImage(img, 0, 50);
						xgr.DrawString(" Страница " + (page_index + 1).ToString() + ". Время: " + DateTime.Now.ToString(), font, XBrushes.Black,
						  new XRect(0, 0, page.Width, 50),
						  XStringFormats.CenterLeft);
						res_tmp.Dispose();
						stream.Dispose();
						Log.Write("Adding page ok. Page index=" + page_index.ToString());
						lastTimebd = DateTime.Now;
						page_index++;

						if (page_index >= page_filter)
						{
							eventDetect = false;
							lastTimebd = default(DateTime);
						}
					}
					catch (Exception ex)
					{
						Log.Write("Error stage 1: " + ex.Message + " " + ex.StackTrace);
					}
				}
			}

			if(!eventDetect)
				Log.Write("lastime bd delta " + (DateTime.Now - lastTimebd).Seconds.ToString());

			if ((start_write_report && !eventDetect && (DateTime.Now - lastTimebd).TotalSeconds >= time_filter) || !Constants.PLAYFLAG)
			{
				if ((report_filename != null) && ((page_index >= page_filter)|| !Constants.PLAYFLAG) && page_index != 0)
				{
					try
					{
						doc.Save(report_filename);
						doc.Close();
						Log.Write("Save ok - " + report_filename);
						report_filename = null;
					}
					catch (Exception ex)
					{
						Log.Write("Error stage 2: " + ex.Message + " " + ex.StackTrace);
					}
				}
				eventDetect = true;
				start_write_report = false;
				page_index = 0;
				lastTimebd = default(DateTime);
				Log.Write("counters are restarted");
			}
		}

	}
}
