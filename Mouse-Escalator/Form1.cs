﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Mouse_Escalator
{
    public partial class Form1 : Form
    {
        FileStream resultFile;
        Series locationSeries = new Series("位置");
        Series speedSeries = new Series("速度");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            locationSeries.ChartType = SeriesChartType.Line;
            locationSeries.BorderWidth = 2;
            //locationSeries.Points.DataBindY(value);
            locationChart.ChartAreas[0].AxisX.IsMarginVisible = false;
            locationChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            locationChart.ChartAreas[0].AxisX.Interval = 10;
            locationChart.ChartAreas[0].AxisY.Maximum = 10;
            locationChart.ChartAreas[0].AxisY.Interval = 1;
            locationChart.Series.Add(locationSeries);
            locationChart.Titles.Add("位置");

            speedSeries.ChartType = SeriesChartType.Line;
            speedSeries.BorderWidth = 2;
            //speedSeries.Points.DataBindY(value);
            speedChart.ChartAreas[0].AxisX.IsMarginVisible = false;
            speedChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            speedChart.ChartAreas[0].AxisX.Interval = 10;
            speedChart.ChartAreas[0].AxisY.Maximum = 35;
            speedChart.ChartAreas[0].AxisY.Interval = 5;
            speedChart.Series.Add(speedSeries);
            speedChart.Titles.Add("速度");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                resultFile = (System.IO.FileStream)resultFileDialog.OpenFile();
                resultFilePath.ForeColor = Color.Black;
            }
            catch
            {
                resultFilePath.ForeColor = Color.Red;
                resultFilePath.Text = "File path error";
                return;
            }
            minSpeed.Enabled = false;
            maxSpeed.Enabled = false;
            startButton.Enabled = false;
            stopButton.Enabled = true;
            trainTime.Enabled = false;
            fileSelectButton.Enabled = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            minSpeed.Enabled = true;
            maxSpeed.Enabled = true;
            startButton.Enabled = true;
            stopButton.Enabled = false;
            trainTime.Enabled = true;
            fileSelectButton.Enabled = true;
        }

        private void fileSelectButton_Click(object sender, EventArgs e)
        {
            resultFileDialog.ShowDialog();
        }

        private void resulfFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            resultFilePath.Text = resultFileDialog.FileName;
        }
    }
}
