using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace Canteen_Management_System.UI
{
    public partial class QRLogin : Form
    {
        public QRLogin()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        private void QRLogin_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo filterInfo in filterInfoCollection)
            {
                cboDevice.Items.Add(filterInfo.Name);
                cboDevice.SelectedIndex = 0;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();

        }

       /* private void QRLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
        }
       */
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox.Image);
                if(result != null)
                {
                    RegistrationBox.Text = result.ToString();
                   
                    timer1.Stop();
                    if (captureDevice.IsRunning)
                    {
                        captureDevice.Stop();
                    }
                }

            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            bool state = da.Login(RegistrationBox.Text, PasswordBox.Text);
            if (state == true)
            {
              
                pictureBox.Image = null;
                RegistrationBox.Text = "";
                PasswordBox.Text = "";
                frmMenu menu = new frmMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Please login to continue");
            }

        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void PasswordButton_Click(object sender, EventArgs e)
        {
            Password p = new Password();
            p.RegistrationBox1.Text = RegistrationBox.Text;
            p.ShowDialog();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }


        }
    }
}
