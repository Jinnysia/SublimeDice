using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace SublimeDiceUI
{
    public partial class LoginFormCopy : MetroForm
    {
        private Image[] images = new Image[60];
        // private Image[] newImages = new Image[1200];
        // private const int maxRotations = 20;
        private int currentImageCounter = 0;
        // private int currentRotateCounter = 0;
        System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();

        public LoginFormCopy()
        {
            InitializeComponent();
            LoadImages();
            time.Interval = 16; // 17
            time.Start();
            time.Tick += time_Tick;
        }

        private void LoginForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            pictureBoxProgress.Visible = false;
        }

        private void time_Tick(object sender, EventArgs e)
        {
            pictureBoxProgress.Image = (Bitmap)images[currentImageCounter];
            currentImageCounter++;
            if (currentImageCounter >= images.Length)
            {
                currentImageCounter = 0;
            }
        }

        /*
        private float GetRotateAngle(int currentImage, int currentRotate)
        {
            float angleSegments = 360.0f / images.Length / maxRotations;
            return (angleSegments * images.Length * currentRotate) + (angleSegments * (currentImage + 1));
        }

        private Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }
        */

        private void LoadImages()
        {
            for (int i = 1; i <= 60; i++)
            {
                Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject("frame_" + i);
                images[i - 1] = bmp;
            }
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, EventArgs.Empty);
            }
        }

        private void LockButtons(bool locked)
        {
            buttonLogin.Enabled = !locked;
            buttonRegister.Enabled = !locked;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Invalid username.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter a password.", "Invalid password.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            LockButtons(true);
            pictureBoxProgress.Visible = true;

            MessageBox.Show("User: " + textBoxUsername.Text + Environment.NewLine + "Pass: " + textBoxPassword.Text);

            pictureBoxProgress.Visible = false;
            LockButtons(false);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Register is not implemented.");
        }
    }
}
