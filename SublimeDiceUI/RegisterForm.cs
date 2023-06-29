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
    public partial class RegisterForm : MetroForm
    {
        public bool SuccessfullyRegistered { get; private set; }

        private Connection connection;

        private Image[] images = new Image[60];
        private int currentImageCounter = 0;
        Timer time = new Timer();

        public RegisterForm(Connection connection)
        {
            InitializeComponent();
            LoadImages();
            pictureBoxProgress.Image = null;
            time.Interval = 16; // 17
            time.Tick += time_Tick;
            this.connection = connection;
            this.SuccessfullyRegistered = false;

            labelUsernameFooter.ForeColor = Color.FromArgb(170, 170, 170);
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

        private void LoadImages()
        {
            for (int i = 1; i <= 60; i++)
            {
                Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject("frame_" + i);
                images[i - 1] = bmp;
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonRegister_Click(this, EventArgs.Empty);
            }
        }

        private void LockFormControls(bool locked)
        {
            pictureBoxProgress.Visible = locked;
            buttonRegister.Enabled = !locked;
            if (locked)
                time.Start();
            else
                time.Stop();
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter a password.", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPasswordConfirm.Text))
            {
                MessageBox.Show("Please enter your password again in the confirmation.", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (textBoxUsername.Text.Length < 5 || textBoxUsername.Text.Length > 30)
            {
                MessageBox.Show("Please ensure that your username is between 5 and 30 characters in length.", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (textBoxPassword.Text != textBoxPasswordConfirm.Text)
            {
                MessageBox.Show("Your passwords do not match.", "Password mismatch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            LockFormControls(true);
            pictureBoxProgress.Visible = true;

            string response = "";

            response = await connection.Register(textBoxUsername.Text, textBoxPassword.Text, checkBoxRetain.Checked);

            pictureBoxProgress.Visible = false;
            LockFormControls(false);
            ResponseStatus responseStatus = ServerResponseHandler.DisplayMessageBox(response);

            if (responseStatus == ResponseStatus.OK)
            {
                // Close the form
                SuccessfullyRegistered = true;
                this.Close();
            }
        }
    }
}
