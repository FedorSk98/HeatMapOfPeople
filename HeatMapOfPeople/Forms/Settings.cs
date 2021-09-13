using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace HeatMapOfPeople.Forms
{
	public partial class Settings : Form
	{
		private Configuration.ConfigurationSettings configuration;
		public Settings()
		{
			InitializeComponent();
			configuration = new Configuration.ConfigurationSettings();
			configuration.LoadConfiguration();
		}

		private void _okButton_Click(object sender, EventArgs e)
		{
			var setings = new Configuration.Configuration()
			{
				DataSource = _nameServerTextBox.Text, //
				PathFile = _pathFiletextBox.Text,
				SizeRectangle = (int)_sizeHeatMapNumericUpDown.Value,
				MaxSizePeople = (int)_maxSizePeopleNumericUpDown.Value,
				TimeGenerateReport = (int)_timeGenerateReportnumericUpDown.Value,
				CountImageInReport = (int)_countImageReportnumericUpDown.Value,

				VideoResolutioncheckBox = (bool)_videoResolutioncheckBox.Checked,
				WidthVideo = (int)_videoWidthnumericUpDown.Value,
				HeightVideo = (int)_videoHeightnumericUpDown.Value,
				TimeAppendBD = (int) _timeAddBD.Value,
				ColorGraycheckBox = (bool)_grayColorCheckBox.Checked,
				SelectIpCameracheckBox = (bool)_ipCameraCheckBox.Checked,
				IDCamera = (int) _idCameraNumericUpDown.Value
			};
			configuration.ChangeConfiguration(setings);
			this.Close();
		}

		private void Settings_Load(object sender, EventArgs e)
		{
			try {
				_sizeHeatMapNumericUpDown.Value = (int)Constants.SizeRectangle;
				_maxSizePeopleNumericUpDown.Value = (int)Constants.MaxSizePeople;
				_nameServerTextBox.Text = Constants.DataSource.ToString();
				_pathFiletextBox.Text = Constants.PathFile;
				_countImageReportnumericUpDown.Value = (int)Constants.CountImageInReport;
				_timeGenerateReportnumericUpDown.Value = (int)Constants.TimeGenerateReport;
				_videoWidthnumericUpDown.Value = (int)Constants.WidthVideo;
				_videoHeightnumericUpDown.Value = (int)Constants.HeightVideo;
				_timeAddBD.Value = (int)Constants.TimeAppendBD;
				_grayColorCheckBox.Checked = Constants.ColorGraycheckBox;
				_ipCameraCheckBox.Checked = Constants.SelectIpCameracheckBox;
				_idCameraNumericUpDown.Value = Constants.IDCamera;
			}
			catch (Exception ex) {
			}

			if (!Constants.VideoResolutioncheckBox)
			{
				_panelResolution.Enabled = false;
			}
			else
			{
				_videoResolutioncheckBox.Checked = true;
			}

			
		}

		private void _applyBtn_Click(object sender, EventArgs e)
		{
			var setings = new Configuration.Configuration()
			{
				DataSource = _nameServerTextBox.Text,
				PathFile = _pathFiletextBox.Text,
				SizeRectangle = (int)_sizeHeatMapNumericUpDown.Value,
				MaxSizePeople = (int)_maxSizePeopleNumericUpDown.Value,
				TimeGenerateReport = (int)_timeGenerateReportnumericUpDown.Value,
				CountImageInReport = (int)_countImageReportnumericUpDown.Value,
				VideoResolutioncheckBox = (bool)_videoResolutioncheckBox.Checked,
				WidthVideo = (int)_videoWidthnumericUpDown.Value,
				HeightVideo = (int)_videoHeightnumericUpDown.Value,
				TimeAppendBD = (int)_timeAddBD.Value,
				ColorGraycheckBox = (bool)_grayColorCheckBox.Checked,
				SelectIpCameracheckBox = (bool)_ipCameraCheckBox.Checked,
				IDCamera = (int) _idCameraNumericUpDown.Value
		};
			configuration.ChangeConfiguration(setings);
		}

		private void _cancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void _pathFilebutton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFile = new OpenFileDialog() { Filter = Constants.VideoFilter })
			{
				if (openFile.ShowDialog() == DialogResult.OK)
				{
					_pathFiletextBox.Text = openFile.FileName;
				}
			}
		}

		private void _videoResolutioncheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (_videoResolutioncheckBox.Checked == false)
			{
				_panelResolution.Enabled = false;
			}
			else
			{
				_panelResolution.Enabled = true;
			}
		}


		private void _ipCameraCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (_ipCameraCheckBox.Checked == false)
			{
				_pathFilebutton.Enabled = true;
			}
			else
			{
				_pathFilebutton.Enabled = false;
			}
		}
	}
}
