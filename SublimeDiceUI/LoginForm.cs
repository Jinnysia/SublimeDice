﻿using System;
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
    public partial class LoginForm : MetroForm
    {
        private Connection connection;

        private Image[] images = new Image[60];
        private int currentImageCounter = 0;
        Timer time = new Timer();

        public LoginForm(Connection connection)
        {
            InitializeComponent();
            LoadImages();
            time.Interval = 16; // 17
            time.Tick += time_Tick;
            this.connection = connection;
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

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, EventArgs.Empty);
            }
        }

        private void LockFormControls(bool locked)
        {
            pictureBoxProgress.Visible = locked;
            buttonLogin.Enabled = !locked;
            buttonRegister.Enabled = !locked;
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
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

            // TODO: Check for invalid characters in password / username (also in register)

            LockFormControls(true);
            pictureBoxProgress.Visible = true;

            string response = await connection.Login(textBoxUsername.Text, AuthenticationType.Password, textBoxPassword.Text, checkBoxRetain.Checked);

            pictureBoxProgress.Visible = false;
            ResponseStatus responseStatus = ServerResponseHandler.DisplayMessageBox(response);
            LockFormControls(false);

            if (responseStatus == ResponseStatus.OK)
            {
                // Close the form
                this.Close();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Register is not implemented.");
        }
    }
}
