﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CvCapture capture;
        IplImage src;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                capture = CvCapture.FromCamera(CaptureDevice.DShow, 0);
                capture.SetCaptureProperty(CaptureProperty.FrameWidth, 640);
                capture.SetCaptureProperty(CaptureProperty.FrameHeight, 480);
            }
            catch
            {
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            src = capture.QueryFrame();
            pictureBoxIpl1.ImageIpl = src;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cv.ReleaseImage(src);
            if (src != null) src.Dispose();
        }
        private void pictureBoxIpl1_Click(object sender, EventArgs e)
        {

        }
    }
}
