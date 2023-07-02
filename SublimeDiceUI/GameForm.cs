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
        private Timer timerProgress = new Timer();
        private Timer timerFaucetWait = new Timer();
        private int faucetWaitSeconds = 0;

        private bool isMouseOverFaucet = false;

        public GameForm(Connection connection)
        {
            InitializeComponent();
            LoadImages();

            // Unselect any button
            buttonUnselect.Location = new Point(-50, -50);
            buttonUnselect.Focus();

            // Add event handlers for faucet image
            pictureBoxFaucet.MouseHover += pictureBoxFaucet_MouseHover;
            pictureBoxFaucet.MouseLeave += pictureBoxFaucet_MouseLeave;
            pictureBoxFaucet.MouseDown += pictureBoxFaucet_MouseDown;
            pictureBoxFaucet.MouseUp += pictureBoxFaucet_MouseUp;

            pictureBoxProgress.Image = null;
            timerProgress.Interval = 16; // 17
            timerProgress.Tick += timerProgress_Tick;

            timerFaucetWait.Interval = 1000;
            timerFaucetWait.Tick += timerFaucetWait_Tick;

            // Check if faucet wait is in effect
            DateTime now = DateTime.Now;
            if (connection.CachedFaucetWaitTimer > now)
            {
                faucetWaitSeconds = (int)(connection.CachedFaucetWaitTimer - now).TotalSeconds;
                labelFaucetWaitTimer.Text = "" + faucetWaitSeconds;
                labelFaucetWaitTimer.Visible = true;
                timerFaucetWait.Start();
            }

            this.connection = connection;

            this.labelStatus.Text = $"¢{connection.LoggedInUser.Balance} / {connection.LoggedInUser.Username}";
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

        private void pictureBoxFaucet_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                pictureBoxFaucet.Image = Properties.Resources.Faucet_35x_Click;

                GetFaucet();
            }
        }

        private void pictureBoxFaucet_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxFaucet.Image = isMouseOverFaucet ? Properties.Resources.Faucet_35x_Hover : Properties.Resources.Faucet_35x_Normal;
        }

        private void pictureBoxFaucet_MouseHover(object sender, EventArgs e)
        {
            isMouseOverFaucet = true;
            pictureBoxFaucet.Image = Properties.Resources.Faucet_35x_Hover;
        }

        private void pictureBoxFaucet_MouseLeave(object sender, EventArgs e)
        {
            isMouseOverFaucet = false;
            pictureBoxFaucet.Image = Properties.Resources.Faucet_35x_Normal;
        }

        private void LoginForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            pictureBoxProgress.Visible = false;
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            pictureBoxProgress.Image = (Bitmap)images[currentImageCounter];
            currentImageCounter++;
            if (currentImageCounter >= images.Length)
            {
                currentImageCounter = 0;
            }
        }

        private void timerFaucetWait_Tick(object sender, EventArgs e)
        {
            if (!labelFaucetWaitTimer.Visible)
            {
                labelFaucetWaitTimer.Visible = true;
            }
            faucetWaitSeconds--;
            labelFaucetWaitTimer.Text = "" + faucetWaitSeconds;
            if (faucetWaitSeconds <= 0)
            {
                labelFaucetWaitTimer.Visible = false;
                timerFaucetWait.Stop();
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

        private void ChangeFaucetEventHandlers(bool locked)
        {
            if (locked)
            {
                pictureBoxFaucet.MouseHover -= pictureBoxFaucet_MouseHover;
                pictureBoxFaucet.MouseLeave -= pictureBoxFaucet_MouseLeave;
                pictureBoxFaucet.MouseDown -= pictureBoxFaucet_MouseDown;
                pictureBoxFaucet.MouseUp -= pictureBoxFaucet_MouseUp;
            }
            else
            {
                pictureBoxFaucet.MouseHover += pictureBoxFaucet_MouseHover;
                pictureBoxFaucet.MouseLeave += pictureBoxFaucet_MouseLeave;
                pictureBoxFaucet.MouseDown += pictureBoxFaucet_MouseDown;
                pictureBoxFaucet.MouseUp += pictureBoxFaucet_MouseUp;
            }
        }

        private void LockFormControls(bool locked)
        {
            pictureBoxProgress.Visible = locked;
            ChangeFaucetEventHandlers(locked);
            if (locked)
                timerProgress.Start();
            else
                timerProgress.Stop();
        }

        private async void GetFaucet()
        {
            User user = connection.LoggedInUser;
            Tuple<AuthenticationType, string> authMethod = user.AuthenticationMethod;

            Tuple<string, int> responseTuple = await connection.FaucetRequest(connection.LoggedInUser.Username, authMethod.Item1, authMethod.Item2);

            string response = responseTuple.Item1;

            int waitTimer = responseTuple.Item2;
            if (waitTimer > 0)
            {
                faucetWaitSeconds = waitTimer;
                if (!timerFaucetWait.Enabled)
                {
                    timerFaucetWait.Start();
                }
            }
            else
            {

            }

            // Update balance
            UpdateBalanceLabel();

            ResponseStatus responseStatus = ServerResponseHandler.DisplayMessageBox(response);
        }

        private void UpdateBalanceLabel()
        {
            this.labelStatus.Text = $"¢{connection.LoggedInUser.Balance} / {connection.LoggedInUser.Username}";
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
