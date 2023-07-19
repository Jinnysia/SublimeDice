using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
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
        private bool isMouseOverToggleBoundary = false;

        private bool isRollOver = false;

        private string textBoxString_Multiplier = "";
        private string textBoxString_WinChance = "";
        private string textBoxString_WagerAmount = "";

        private Keys[] validNumericKeys =
        {
            Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.D0,
            Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.NumPad0,
            Keys.Enter, Keys.Return, Keys.Back, Keys.Delete
        };

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

            // Initialize text box and text box strings
            textBoxString_Multiplier = textBoxRollMultiplier.Text;
            textBoxString_WinChance = textBoxRollWinChance.Text;
            textBoxString_WagerAmount = textBoxWagerAmount.Text;

            UpdateProfitOnWin();
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

        private void pictureBoxToggleBoundary_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                pictureBoxToggleBoundary.Image = Properties.Resources.Rotate_35x_Click;

                isRollOver = !isRollOver;
                int val = trackBarNumber.Value;

                if (isRollOver)
                {
                    labelRollBoundary.Text = "Roll Over";

                    labelAxisMin.Text = "1.99";
                    labelAxisMax.Text = "97.99";

                    // First reset boundaries
                    trackBarNumber.Maximum = 10000;
                    trackBarNumber.Minimum = 0;

                    // Change value to Over
                    int newVal = 9999 - val;
                    trackBarNumber.Value = newVal;
                    trackBarNumber.Maximum = 9799;
                    trackBarNumber.Minimum = 199;

                    string newValStr = newVal.ToString();
                    textBoxRollBoundary.Text = newValStr.Insert(newValStr.Length - 2, ".");
                }
                else
                {
                    labelRollBoundary.Text = "Roll Under";

                    labelAxisMin.Text = "2.00";
                    labelAxisMax.Text = "98.00";

                    // First reset boundaries
                    trackBarNumber.Maximum = 10000;
                    trackBarNumber.Minimum = 0;

                    // Change value to Over
                    int newVal = 9999 - val;
                    trackBarNumber.Value = newVal;
                    trackBarNumber.Maximum = 9800;
                    trackBarNumber.Minimum = 200;

                    string newValStr = newVal.ToString();
                    textBoxRollBoundary.Text = newValStr.Insert(newValStr.Length - 2, ".");
                }

                buttonUnselect.Focus();
            }
        }

        private void pictureBoxToggleBoundary_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxToggleBoundary.Image = isMouseOverToggleBoundary ? Properties.Resources.Rotate_35x_Hover : Properties.Resources.Rotate_35x_Normal;
        }

        private void pictureBoxToggleBoundary_MouseHover(object sender, EventArgs e)
        {
            isMouseOverToggleBoundary = true;
            pictureBoxToggleBoundary.Image = Properties.Resources.Rotate_35x_Hover;
        }

        private void pictureBoxToggleBoundary_MouseLeave(object sender, EventArgs e)
        {
            isMouseOverToggleBoundary = false;
            pictureBoxToggleBoundary.Image = Properties.Resources.Rotate_35x_Normal;
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

            // Lock main controls
            textBoxRollMultiplier.Enabled = !locked;
            textBoxRollWinChance.Enabled = !locked;
            trackBarNumber.Enabled = !locked;
            buttonRoll.Enabled = !locked;
            buttonLogout.Enabled = !locked;
            buttonWagerDouble.Enabled = !locked;
            buttonWagerHalve.Enabled = !locked;
            textBoxWagerAmount.Enabled = !locked;
            pictureBoxFaucet.Enabled = !locked;
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

        /* Multiplier calculation
           1% House Edge
           
           UPDATED:
           Rolling a num from [0-9999]:
           y = 9900x^{-1}
           
           y=99x^{-1}
           y = Multiplier of Payout
           x = Roll Under / Win Chance
           
           
           y=(100-a)x^{-1}
           y = Multiplier of Payout
           x = Roll Under / Win Chance
           a = House Edge % * 100 (1% = 1)
           
           Win Chance: 4 decimal places
           Multiplier: 4 decimal places
           
           Roll Under 98.00 | Multiplier: 1.0102 | Win Chance: 98.00%
           Roll Over 1.99   | Multiplier: 1.0102 | Win Chance: 98.00%
           
           // Max   - Under = Over
           // 99.99 - 98.00 = 1.99
           
           Roll Under 2.00 | Multiplier: 49.5x | Win Chance: 2.00%
           Roll Under 5.00 | Multiplier: 19.8x | Win Chance: 5.00%
         */

        private void ChangeRollParameterControlDisplay(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(MetroTrackBar))
            {
                int value = trackBarNumber.Value;

                textBoxRollBoundary.Text = value.ToString().Insert(value.ToString().Length - 2, ".");

                int adjustedValue = value;
                if (isRollOver)
                {
                    adjustedValue = 9999 - value;
                }

                string winChance = adjustedValue.ToString();
                textBoxRollWinChance.Text = winChance.Insert(winChance.Length - 2, ".") + "00";

                double multiplier = GetMultiplier(adjustedValue);
                textBoxRollMultiplier.Text = multiplier.ToString("#.0000");

                // Now update internal strings
                textBoxString_Multiplier = textBoxRollMultiplier.Text;
                textBoxString_WinChance = textBoxRollWinChance.Text;
            }
            else if (sender.GetType() == typeof(MetroTextBox))
            {
                // Determine which text box
                MetroTextBox senderTb = (MetroTextBox)sender;
                if (senderTb.Name == textBoxRollMultiplier.Name)
                {
                    // Multiplier

                    int rawBoundary = GetRawBoundaryFromMultiplier(double.Parse(textBoxRollMultiplier.Text));

                    // Update win chance
                    string winChance = rawBoundary.ToString();
                    textBoxRollWinChance.Text = winChance.Insert(winChance.Length - 2, ".") + "00";

                    // Update track bar and roll over / under
                    if (isRollOver)
                    {
                        int overBoundary = 9999 - rawBoundary;
                        textBoxRollBoundary.Text = overBoundary.ToString().Insert(overBoundary.ToString().Length - 2, ".");
                        trackBarNumber.Value = overBoundary;
                    }
                    else
                    {
                        textBoxRollBoundary.Text = rawBoundary.ToString().Insert(rawBoundary.ToString().Length - 2, ".");
                        trackBarNumber.Value = rawBoundary;
                    }
                }
                else if (senderTb.Name == textBoxRollWinChance.Name)
                {
                    // Win Chance

                    int rawBoundary = 0;
                    IsValidWinChanceText(textBoxRollWinChance.Text, out rawBoundary);

                    // Update multiplier

                    double multiplier = GetMultiplier(rawBoundary);
                    textBoxRollMultiplier.Text = multiplier.ToString("#.0000");

                    // Update track bar and roll over / under
                    if (isRollOver)
                    {
                        int overBoundary = 9999 - rawBoundary;
                        textBoxRollBoundary.Text = overBoundary.ToString().Insert(overBoundary.ToString().Length - 2, ".");
                        trackBarNumber.Value = overBoundary;
                    }
                    else
                    {
                        textBoxRollBoundary.Text = rawBoundary.ToString().Insert(rawBoundary.ToString().Length - 2, ".");
                        trackBarNumber.Value = rawBoundary;
                    }
                }
            }

            // Finally, update profit on win
            UpdateProfitOnWin();
        }

        private double GetMultiplier(int rawBoundary)
        {
            return (100 - 1) * Math.Pow(rawBoundary * 1.0 / 100, -1);
        }

        private int GetRawBoundaryFromMultiplier(double multiplier)
        {
            // b = ((100 - e) / m) * 100
            // b = boundary
            // e = house edge
            // m = multiplier
            return (int)(((100 - 1) * 1.0 / multiplier) * 100);
        }

        private bool IsValidMultiplierText(string text, out double val)
        {
            val = 0;
            return double.TryParse(text, out val) && (val >= 1.0102 && val <= 49.5000);
        }

        private string GetMultiplierString(double multiplier)
        {
            return multiplier.ToString("#.0000");
        }

        private bool IsValidWinChanceText(string text, out int rawBoundary)
        {
            rawBoundary = 0;
            double x = 0;
            return double.TryParse(text, out x) && (x >= 2.0 && x <= 98.0) && int.TryParse((x * 100).ToString(), out rawBoundary);
        }

        private string GetWinChanceString(int rawBoundary)
        {
            return rawBoundary.ToString().Insert(rawBoundary.ToString().Length - 2, ".") + "00";
        }

        private bool IsValidWagerAmountText(string text, out ulong amount)
        {
            // Max wager of 100 bil
            bool result = ulong.TryParse(text, out amount);

            if (amount > 100000000000)
            {
                amount = 100000000000;
            }

            return result;
        }

        private void textBoxRollMultiplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                // Unfocus
                e.SuppressKeyPress = true; // Avoids the ding SFX on Enter press
                buttonUnselect.Focus();
            }
            /*
            if (!validNumericKeys.Contains(e.KeyCode))
            {
                e.Handled = true;
            }

            double mult = 0;
            if (IsValidMultiplierText(textBoxRollMultiplier.Text, out mult))
            {
                string multString = GetMultiplierString(mult);
                textBoxRollMultiplier.Text = multString;

                // Assign current value to cached string
                textBoxString_Multiplier = multString;
            }
            else
            {
                // Revert to old value from cached string
                textBoxRollMultiplier.Text = textBoxString_Multiplier;
            }
            */
        }

        private void textBoxRollWinChance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                // Unfocus
                e.SuppressKeyPress = true; // Avoids the ding SFX on Enter press
                buttonUnselect.Focus();
            }
        }

        private void textBoxRollMultiplier_Leave(object sender, EventArgs e)
        {
            double mult = 0;
            if (IsValidMultiplierText(textBoxRollMultiplier.Text, out mult))
            {
                string multString = GetMultiplierString(mult);
                textBoxRollMultiplier.Text = multString;

                // Assign current value to cached string
                textBoxString_Multiplier = multString;
            }
            else
            {
                // Revert to old value from cached string
                textBoxRollMultiplier.Text = textBoxString_Multiplier;
            }

            // Finally, call the update values
            ChangeRollParameterControlDisplay(sender, e);
        }

        private void textBoxRollWinChance_Leave(object sender, EventArgs e)
        {
            int rawBoundary = 0;
            if (IsValidWinChanceText(textBoxRollWinChance.Text, out rawBoundary))
            {
                string winChanceString = GetWinChanceString(rawBoundary);
                textBoxRollWinChance.Text = winChanceString;

                // Assign current value to cached string
                textBoxString_WinChance = winChanceString;
            }
            else
            {
                // Revert to old value from cached string
                textBoxRollWinChance.Text = textBoxString_WinChance;
            }

            // Finally, call the update values
            ChangeRollParameterControlDisplay(sender, e);
        }

        private void textBoxWagerAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                // Unfocus
                e.SuppressKeyPress = true; // Avoids the ding SFX on Enter press
                buttonUnselect.Focus();
            }
        }

        private void textBoxWagerAmount_Leave(object sender, EventArgs e)
        {
            // TODO: Add commas to wager amount / profit text boxes for added readability
            ulong amount = 0;
            if (IsValidWagerAmountText(textBoxWagerAmount.Text, out amount))
            {
                textBoxWagerAmount.Text = amount.ToString();

                // Assign current value to cached string
                textBoxString_WagerAmount = amount.ToString();
            }
            else
            {
                textBoxWagerAmount.Text = textBoxString_WagerAmount;
            }

            UpdateProfitOnWin();
        }

        private void UpdateProfitOnWin()
        {
            ulong curAmount = ulong.Parse(textBoxWagerAmount.Text);
            ulong profit = (ulong)(curAmount * double.Parse(textBoxRollMultiplier.Text));
            textBoxWagerProfitOnWin.Text = profit.ToString();

            buttonRoll.Text = curAmount > 0 ? "Roll and Wager" : "Roll without Risk";
        }

        private void buttonWagerHalve_Click(object sender, EventArgs e)
        {
            textBoxWagerAmount.Text = (ulong.Parse(textBoxWagerAmount.Text) / 2).ToString();
            UpdateProfitOnWin();
            buttonUnselect.Focus();
        }

        private void buttonWagerDouble_Click(object sender, EventArgs e)
        {
            string potentialText = (ulong.Parse(textBoxWagerAmount.Text) * 2).ToString();
            ulong newAmount = 0;
            IsValidWagerAmountText(potentialText, out newAmount);
            textBoxWagerAmount.Text = newAmount.ToString();
            UpdateProfitOnWin();
            buttonUnselect.Focus();
        }

        private void buttonWagerMax_Click(object sender, EventArgs e)
        {
            textBoxWagerAmount.Text = connection.LoggedInUser.Balance.ToString();
            UpdateProfitOnWin();
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            SendRoll();
        }

        private async void SendRoll()
        {
            // Lock controls
            LockFormControls(true);

            // Animate label

            // Retrieve roll result
            string response = "";
            User user = connection.LoggedInUser;
            Tuple<AuthenticationType, string> authMethod = user.AuthenticationMethod;

            Tuple<string, Roll> responseTuple = await connection.RollDice(user.Username, authMethod.Item1, authMethod.Item2, user.ClientSeed, user.Nonce, ulong.Parse(textBoxWagerAmount.Text), ushort.Parse(textBoxRollBoundary.Text.Replace(".", "")), isRollOver);
            response = responseTuple.Item1;

            // Stop animation

            // Update balance label
            this.labelStatus.Text = $"¢{connection.LoggedInUser.Balance} / {connection.LoggedInUser.Username}";

            // Unlock controls
            LockFormControls(false);

            // Check if error happened
            // Display error if it exists
            ResponseStatus responseStatus = ServerResponseHandler.GetResponseStatus(response);
            if (responseStatus != ResponseStatus.OK)
            {
                labelRollResult.Text = "xx.xx";
                // Display error
                ServerResponseHandler.DisplayMessageBox(response);
            }
            else
            {
                Roll rollResult = responseTuple.Item2;

                // Update roll result label
                labelRollResult.Text = rollResult.RolledNumberString;
            }
        }

        private void linkLabelVerify_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Fairness and Verify menu is in development.", "Coming soon!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
