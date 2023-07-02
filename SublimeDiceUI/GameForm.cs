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
    public partial class GameForm : MetroForm
    {
        private Connection connection;

        private Image[] images = new Image[60];
        private int currentImageCounter = 0;
        Timer time = new Timer();

        public GameForm(Connection connection)
        {
            InitializeComponent();
            LoadImages();
            pictureBoxProgress.Image = null;
            time.Interval = 16; // 17
            time.Tick += time_Tick;
            this.connection = connection;

            this.labelStatus.Text = $"You are logged in as: {connection.LoggedInUser.Username}.";
            this.labelBalance.Text = "¢" + connection.LoggedInUser.Balance;
            // Determine whether to show logout button or logout notice depending on user's auth type
            if (connection.LoggedInUser.AuthenticationMethod.Item1 == AuthenticationType.Password)
            {
                buttonLogout.Visible = false;
                labelLogoutNotice.Visible = true;
            }
            else
            {
                buttonLogout.Visible = true;
                labelLogoutNotice.Visible = false;
            }
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

        private void LockFormControls(bool locked)
        {
            pictureBoxProgress.Visible = locked;
            if (locked)
                time.Start();
            else
                time.Stop();
        }

        private async void buttonLogout_Click(object sender, EventArgs e)
        {
            User user = connection.LoggedInUser;
            Tuple<AuthenticationType, string> authMethod = user.AuthenticationMethod;

            // Shouldn't have access to this button if user logged in with a password.
            if (authMethod.Item1 == AuthenticationType.Password)
            {
                return;
            }

            string response = "";

            response = await connection.Logout(connection.LoggedInUser.Username, authMethod.Item2);

            ResponseStatus responseStatus = ServerResponseHandler.DisplayMessageBox(response);

            /*
            if (responseStatus == ResponseStatus.OK)
            {
                // Okay!
            }
            */
            
            // Close the form regardless of response
            this.Close();
        }
    }
}
