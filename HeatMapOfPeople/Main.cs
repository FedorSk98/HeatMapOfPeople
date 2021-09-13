using Alturos.Yolo;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alturos.Yolo.Model;
using HeatMapOfPeople.Core;
using HeatMapOfPeople.Forms;
using HeatMapOfPeople.DataStorage;
using HeatMapOfPeople.Configuration;

namespace HeatMapOfPeople
{
	public partial class Main : Form
	{
		private Detector detector;
		ConfigurationSettings configuration;

		public Main()
		{
			Log.Write("ColorGraychecked: " + Constants.ColorGraycheckBox.ToString());
			InitializeComponent();
			detector = new Detector();
			_timerStatus.Start();
			configuration = new ConfigurationSettings();
			configuration.LoadConfiguration();
			detector.ImageOutput += ImagePanelOutput;
		}

		//private void _DetectBtn_Click(object sender, EventArgs e)
		//{
		//	detector.AnalysisVideoStream(Constants.PathFile, 0, _videoPanel);
		//}

		private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new Settings().ShowDialog();
		}

		private void _playButton_Click(object sender, EventArgs e)
		{
			файлToolStripMenuItem.Enabled = false;
			_playButton.Enabled = false;
			_messageStatusLabel.ForeColor = Color.Black;
			if (Constants.PLAYFLAG) Constants.PLAYFLAG = false;
			
			RunDetector();
			//BeginInvoke((Action)(() => { })).;
			//	BeginInvoke((Action)(() => {
			 
			//var neuroThread = Task.Factory.StartNew(detector.AnalysisVideoStream(_videoPanel, TaskCreationOptions.LongRunning);

			//	}));
		}

		async private void RunDetector()
		{
			await Task.Run(() => {
				Constants.PLAYFLAG = true;
				detector.AnalysisVideoStream();//_videoPanel);
			});
		}

		
		private void _StopButton_Click(object sender, EventArgs e)
		{
			Constants.PLAYFLAG = false;	
		}

		private void ImagePanelOutput(object s, Core.FrameEventArgs args)
		{
			_videoPanel.Image = args.Frame;
		}

		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			Constants.PLAYFLAG = false;
		}

		private void _timerStatus_Tick(object sender, EventArgs e)
		{
			_messageStatusLabel.Text = detector.ProcessExecution;
			if (!Constants.PLAYFLAG)
			{
				файлToolStripMenuItem.Enabled = true;
				_playButton.Enabled = true;
			}
		}
	}

	
}
