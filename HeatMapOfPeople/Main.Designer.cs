namespace HeatMapOfPeople
{
	partial class Main
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this._videoPanel = new System.Windows.Forms.PictureBox();
			this._playButton = new System.Windows.Forms.Button();
			this._StopButton = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._statusLabel = new System.Windows.Forms.Label();
			this._messageStatusLabel = new System.Windows.Forms.Label();
			this._timerStatus = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this._videoPanel)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _videoPanel
			// 
			this._videoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._videoPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._videoPanel.Location = new System.Drawing.Point(12, 37);
			this._videoPanel.Name = "_videoPanel";
			this._videoPanel.Size = new System.Drawing.Size(860, 561);
			this._videoPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this._videoPanel.TabIndex = 0;
			this._videoPanel.TabStop = false;
			// 
			// _playButton
			// 
			this._playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._playButton.Location = new System.Drawing.Point(13, 604);
			this._playButton.Name = "_playButton";
			this._playButton.Size = new System.Drawing.Size(169, 53);
			this._playButton.TabIndex = 3;
			this._playButton.Text = "Play";
			this._playButton.UseVisualStyleBackColor = true;
			this._playButton.Click += new System.EventHandler(this._playButton_Click);
			// 
			// _StopButton
			// 
			this._StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._StopButton.Location = new System.Drawing.Point(188, 604);
			this._StopButton.Name = "_StopButton";
			this._StopButton.Size = new System.Drawing.Size(160, 53);
			this._StopButton.TabIndex = 4;
			this._StopButton.Text = "Stop";
			this._StopButton.UseVisualStyleBackColor = true;
			this._StopButton.Click += new System.EventHandler(this._StopButton_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(884, 28);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// настройкиToolStripMenuItem
			// 
			this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
			this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
			this.настройкиToolStripMenuItem.Text = "Настройки";
			this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
			// 
			// _statusLabel
			// 
			this._statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._statusLabel.AutoSize = true;
			this._statusLabel.Location = new System.Drawing.Point(12, 660);
			this._statusLabel.Name = "_statusLabel";
			this._statusLabel.Size = new System.Drawing.Size(57, 17);
			this._statusLabel.TabIndex = 6;
			this._statusLabel.Text = "Статус:";
			// 
			// _messageStatusLabel
			// 
			this._messageStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._messageStatusLabel.AutoSize = true;
			this._messageStatusLabel.Location = new System.Drawing.Point(71, 660);
			this._messageStatusLabel.Name = "_messageStatusLabel";
			this._messageStatusLabel.Size = new System.Drawing.Size(0, 17);
			this._messageStatusLabel.TabIndex = 7;
			// 
			// _timerStatus
			// 
			this._timerStatus.Tick += new System.EventHandler(this._timerStatus_Tick);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 686);
			this.Controls.Add(this._messageStatusLabel);
			this.Controls.Add(this._statusLabel);
			this.Controls.Add(this._StopButton);
			this.Controls.Add(this._playButton);
			this.Controls.Add(this._videoPanel);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HeatMapOfPeople";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this._videoPanel)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox _videoPanel;
		private System.Windows.Forms.Button _playButton;
		private System.Windows.Forms.Button _StopButton;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
		private System.Windows.Forms.Label _statusLabel;
		private System.Windows.Forms.Label _messageStatusLabel;
		private System.Windows.Forms.Timer _timerStatus;
	}
}

