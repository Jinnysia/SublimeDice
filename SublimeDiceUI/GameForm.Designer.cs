namespace SublimeDiceUI
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.pictureBoxProgress = new System.Windows.Forms.PictureBox();
            this.labelStatus = new MetroFramework.Controls.MetroLabel();
            this.buttonLogout = new MetroFramework.Controls.MetroButton();
            this.labelLogoutNotice = new MetroFramework.Controls.MetroLabel();
            this.pictureBoxFaucet = new System.Windows.Forms.PictureBox();
            this.buttonUnselect = new MetroFramework.Controls.MetroButton();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.labelFaucetWaitTimer = new MetroFramework.Controls.MetroLabel();
            this.linkLabelVerify = new MetroFramework.Controls.MetroLink();
            this.trackBarNumber = new MetroFramework.Controls.MetroTrackBar();
            this.textBoxRollBoundary = new MetroFramework.Controls.MetroTextBox();
            this.pictureBoxToggleBoundary = new System.Windows.Forms.PictureBox();
            this.textBoxRollMultiplier = new MetroFramework.Controls.MetroTextBox();
            this.labelRollMultiplierSymbol = new MetroFramework.Controls.MetroLabel();
            this.textBoxRollWinChance = new MetroFramework.Controls.MetroTextBox();
            this.labelRollWinChancePercentage = new MetroFramework.Controls.MetroLabel();
            this.labelRollBoundary = new MetroFramework.Controls.MetroLabel();
            this.labelMultiplier = new MetroFramework.Controls.MetroLabel();
            this.labelWinChance = new MetroFramework.Controls.MetroLabel();
            this.labelAxisMin = new MetroFramework.Controls.MetroLabel();
            this.labelAxisMax = new MetroFramework.Controls.MetroLabel();
            this.labelBoundary = new MetroFramework.Controls.MetroLabel();
            this.labelWagerAmount = new MetroFramework.Controls.MetroLabel();
            this.textBoxWagerAmount = new MetroFramework.Controls.MetroTextBox();
            this.labelCurrencyWagerAmount = new MetroFramework.Controls.MetroLabel();
            this.labelCurrencyWagerProfit = new MetroFramework.Controls.MetroLabel();
            this.labelWagerProfitOnWin = new MetroFramework.Controls.MetroLabel();
            this.textBoxWagerProfitOnWin = new MetroFramework.Controls.MetroTextBox();
            this.buttonWagerHalve = new MetroFramework.Controls.MetroButton();
            this.buttonWagerDouble = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFaucet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToggleBoundary)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pictureBoxProgress
            // 
            this.pictureBoxProgress.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxProgress.Image")));
            this.pictureBoxProgress.Location = new System.Drawing.Point(52, 321);
            this.pictureBoxProgress.Name = "pictureBoxProgress";
            this.pictureBoxProgress.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProgress.TabIndex = 0;
            this.pictureBoxProgress.TabStop = false;
            this.pictureBoxProgress.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(201, 311);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(269, 23);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "¢0 / {Username}";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(395, 333);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonLogout.UseSelectable = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelLogoutNotice
            // 
            this.labelLogoutNotice.AutoSize = true;
            this.labelLogoutNotice.Location = new System.Drawing.Point(250, 335);
            this.labelLogoutNotice.Name = "labelLogoutNotice";
            this.labelLogoutNotice.Size = new System.Drawing.Size(220, 19);
            this.labelLogoutNotice.TabIndex = 3;
            this.labelLogoutNotice.Text = "You will be logged out upon exiting.";
            this.labelLogoutNotice.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pictureBoxFaucet
            // 
            this.pictureBoxFaucet.Image = global::SublimeDiceUI.Properties.Resources.Faucet_35x_Normal;
            this.pictureBoxFaucet.Location = new System.Drawing.Point(11, 321);
            this.pictureBoxFaucet.Name = "pictureBoxFaucet";
            this.pictureBoxFaucet.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxFaucet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxFaucet.TabIndex = 6;
            this.pictureBoxFaucet.TabStop = false;
            // 
            // buttonUnselect
            // 
            this.buttonUnselect.Location = new System.Drawing.Point(164, 26);
            this.buttonUnselect.Name = "buttonUnselect";
            this.buttonUnselect.Size = new System.Drawing.Size(75, 23);
            this.buttonUnselect.TabIndex = 0;
            this.buttonUnselect.Text = "Unselect";
            this.buttonUnselect.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonUnselect.UseSelectable = true;
            // 
            // labelFaucetWaitTimer
            // 
            this.labelFaucetWaitTimer.AutoSize = true;
            this.labelFaucetWaitTimer.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelFaucetWaitTimer.Location = new System.Drawing.Point(25, 342);
            this.labelFaucetWaitTimer.Name = "labelFaucetWaitTimer";
            this.labelFaucetWaitTimer.Size = new System.Drawing.Size(25, 15);
            this.labelFaucetWaitTimer.TabIndex = 7;
            this.labelFaucetWaitTimer.Text = "300";
            this.labelFaucetWaitTimer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.labelFaucetWaitTimer.Visible = false;
            // 
            // linkLabelVerify
            // 
            this.linkLabelVerify.AutoSize = true;
            this.linkLabelVerify.Location = new System.Drawing.Point(89, 335);
            this.linkLabelVerify.Name = "linkLabelVerify";
            this.linkLabelVerify.Size = new System.Drawing.Size(99, 23);
            this.linkLabelVerify.TabIndex = 8;
            this.linkLabelVerify.Text = "Fairness / Verify";
            this.linkLabelVerify.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.linkLabelVerify.UseSelectable = true;
            // 
            // trackBarNumber
            // 
            this.trackBarNumber.BackColor = System.Drawing.Color.Transparent;
            this.trackBarNumber.Location = new System.Drawing.Point(23, 88);
            this.trackBarNumber.Maximum = 9800;
            this.trackBarNumber.Minimum = 200;
            this.trackBarNumber.Name = "trackBarNumber";
            this.trackBarNumber.Size = new System.Drawing.Size(434, 23);
            this.trackBarNumber.TabIndex = 9;
            this.trackBarNumber.Text = "Number";
            this.trackBarNumber.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.trackBarNumber.Value = 4950;
            this.trackBarNumber.ValueChanged += new System.EventHandler(this.ChangeRollParameterControlDisplay);
            // 
            // textBoxRollBoundary
            // 
            // 
            // 
            // 
            this.textBoxRollBoundary.CustomButton.Image = null;
            this.textBoxRollBoundary.CustomButton.Location = new System.Drawing.Point(94, 1);
            this.textBoxRollBoundary.CustomButton.Name = "";
            this.textBoxRollBoundary.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxRollBoundary.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxRollBoundary.CustomButton.TabIndex = 1;
            this.textBoxRollBoundary.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxRollBoundary.CustomButton.UseSelectable = true;
            this.textBoxRollBoundary.CustomButton.Visible = false;
            this.textBoxRollBoundary.Enabled = false;
            this.textBoxRollBoundary.Lines = new string[] {
        "49.50"};
            this.textBoxRollBoundary.Location = new System.Drawing.Point(23, 136);
            this.textBoxRollBoundary.MaxLength = 32767;
            this.textBoxRollBoundary.Name = "textBoxRollBoundary";
            this.textBoxRollBoundary.PasswordChar = '\0';
            this.textBoxRollBoundary.ReadOnly = true;
            this.textBoxRollBoundary.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxRollBoundary.SelectedText = "";
            this.textBoxRollBoundary.SelectionLength = 0;
            this.textBoxRollBoundary.SelectionStart = 0;
            this.textBoxRollBoundary.ShortcutsEnabled = true;
            this.textBoxRollBoundary.Size = new System.Drawing.Size(116, 23);
            this.textBoxRollBoundary.TabIndex = 10;
            this.textBoxRollBoundary.Text = "49.50";
            this.textBoxRollBoundary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRollBoundary.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBoxRollBoundary.UseSelectable = true;
            this.textBoxRollBoundary.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxRollBoundary.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBoxToggleBoundary
            // 
            this.pictureBoxToggleBoundary.Image = global::SublimeDiceUI.Properties.Resources.Rotate_35x_Normal;
            this.pictureBoxToggleBoundary.Location = new System.Drawing.Point(140, 136);
            this.pictureBoxToggleBoundary.Name = "pictureBoxToggleBoundary";
            this.pictureBoxToggleBoundary.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxToggleBoundary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxToggleBoundary.TabIndex = 11;
            this.pictureBoxToggleBoundary.TabStop = false;
            this.pictureBoxToggleBoundary.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxToggleBoundary_MouseDown);
            this.pictureBoxToggleBoundary.MouseLeave += new System.EventHandler(this.pictureBoxToggleBoundary_MouseLeave);
            this.pictureBoxToggleBoundary.MouseHover += new System.EventHandler(this.pictureBoxToggleBoundary_MouseHover);
            this.pictureBoxToggleBoundary.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxToggleBoundary_MouseUp);
            // 
            // textBoxRollMultiplier
            // 
            // 
            // 
            // 
            this.textBoxRollMultiplier.CustomButton.Image = null;
            this.textBoxRollMultiplier.CustomButton.Location = new System.Drawing.Point(94, 1);
            this.textBoxRollMultiplier.CustomButton.Name = "";
            this.textBoxRollMultiplier.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxRollMultiplier.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxRollMultiplier.CustomButton.TabIndex = 1;
            this.textBoxRollMultiplier.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxRollMultiplier.CustomButton.UseSelectable = true;
            this.textBoxRollMultiplier.CustomButton.Visible = false;
            this.textBoxRollMultiplier.Lines = new string[] {
        "2.0000"};
            this.textBoxRollMultiplier.Location = new System.Drawing.Point(174, 136);
            this.textBoxRollMultiplier.MaxLength = 32767;
            this.textBoxRollMultiplier.Name = "textBoxRollMultiplier";
            this.textBoxRollMultiplier.PasswordChar = '\0';
            this.textBoxRollMultiplier.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxRollMultiplier.SelectedText = "";
            this.textBoxRollMultiplier.SelectionLength = 0;
            this.textBoxRollMultiplier.SelectionStart = 0;
            this.textBoxRollMultiplier.ShortcutsEnabled = true;
            this.textBoxRollMultiplier.Size = new System.Drawing.Size(116, 23);
            this.textBoxRollMultiplier.TabIndex = 12;
            this.textBoxRollMultiplier.Text = "2.0000";
            this.textBoxRollMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRollMultiplier.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBoxRollMultiplier.UseSelectable = true;
            this.textBoxRollMultiplier.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxRollMultiplier.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRollMultiplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRollMultiplier_KeyDown);
            this.textBoxRollMultiplier.Leave += new System.EventHandler(this.textBoxRollMultiplier_Leave);
            // 
            // labelRollMultiplierSymbol
            // 
            this.labelRollMultiplierSymbol.AutoSize = true;
            this.labelRollMultiplierSymbol.Location = new System.Drawing.Point(291, 138);
            this.labelRollMultiplierSymbol.Name = "labelRollMultiplierSymbol";
            this.labelRollMultiplierSymbol.Size = new System.Drawing.Size(15, 19);
            this.labelRollMultiplierSymbol.TabIndex = 13;
            this.labelRollMultiplierSymbol.Text = "x";
            this.labelRollMultiplierSymbol.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // textBoxRollWinChance
            // 
            // 
            // 
            // 
            this.textBoxRollWinChance.CustomButton.Image = null;
            this.textBoxRollWinChance.CustomButton.Location = new System.Drawing.Point(94, 1);
            this.textBoxRollWinChance.CustomButton.Name = "";
            this.textBoxRollWinChance.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxRollWinChance.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxRollWinChance.CustomButton.TabIndex = 1;
            this.textBoxRollWinChance.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxRollWinChance.CustomButton.UseSelectable = true;
            this.textBoxRollWinChance.CustomButton.Visible = false;
            this.textBoxRollWinChance.Lines = new string[] {
        "49.5000"};
            this.textBoxRollWinChance.Location = new System.Drawing.Point(315, 136);
            this.textBoxRollWinChance.MaxLength = 32767;
            this.textBoxRollWinChance.Name = "textBoxRollWinChance";
            this.textBoxRollWinChance.PasswordChar = '\0';
            this.textBoxRollWinChance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxRollWinChance.SelectedText = "";
            this.textBoxRollWinChance.SelectionLength = 0;
            this.textBoxRollWinChance.SelectionStart = 0;
            this.textBoxRollWinChance.ShortcutsEnabled = true;
            this.textBoxRollWinChance.Size = new System.Drawing.Size(116, 23);
            this.textBoxRollWinChance.TabIndex = 14;
            this.textBoxRollWinChance.Text = "49.5000";
            this.textBoxRollWinChance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRollWinChance.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBoxRollWinChance.UseSelectable = true;
            this.textBoxRollWinChance.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxRollWinChance.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRollWinChance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRollWinChance_KeyDown);
            this.textBoxRollWinChance.Leave += new System.EventHandler(this.textBoxRollWinChance_Leave);
            // 
            // labelRollWinChancePercentage
            // 
            this.labelRollWinChancePercentage.AutoSize = true;
            this.labelRollWinChancePercentage.Location = new System.Drawing.Point(432, 138);
            this.labelRollWinChancePercentage.Name = "labelRollWinChancePercentage";
            this.labelRollWinChancePercentage.Size = new System.Drawing.Size(20, 19);
            this.labelRollWinChancePercentage.TabIndex = 15;
            this.labelRollWinChancePercentage.Text = "%";
            this.labelRollWinChancePercentage.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelRollBoundary
            // 
            this.labelRollBoundary.AutoSize = true;
            this.labelRollBoundary.Location = new System.Drawing.Point(23, 114);
            this.labelRollBoundary.Name = "labelRollBoundary";
            this.labelRollBoundary.Size = new System.Drawing.Size(71, 19);
            this.labelRollBoundary.TabIndex = 16;
            this.labelRollBoundary.Text = "Roll Under";
            this.labelRollBoundary.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelMultiplier
            // 
            this.labelMultiplier.AutoSize = true;
            this.labelMultiplier.Location = new System.Drawing.Point(174, 114);
            this.labelMultiplier.Name = "labelMultiplier";
            this.labelMultiplier.Size = new System.Drawing.Size(64, 19);
            this.labelMultiplier.TabIndex = 17;
            this.labelMultiplier.Text = "Multiplier";
            this.labelMultiplier.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelWinChance
            // 
            this.labelWinChance.AutoSize = true;
            this.labelWinChance.Location = new System.Drawing.Point(315, 114);
            this.labelWinChance.Name = "labelWinChance";
            this.labelWinChance.Size = new System.Drawing.Size(79, 19);
            this.labelWinChance.TabIndex = 18;
            this.labelWinChance.Text = "Win Chance";
            this.labelWinChance.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelAxisMin
            // 
            this.labelAxisMin.AutoSize = true;
            this.labelAxisMin.Location = new System.Drawing.Point(23, 66);
            this.labelAxisMin.Name = "labelAxisMin";
            this.labelAxisMin.Size = new System.Drawing.Size(33, 19);
            this.labelAxisMin.TabIndex = 19;
            this.labelAxisMin.Text = "2.00";
            this.labelAxisMin.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelAxisMax
            // 
            this.labelAxisMax.Location = new System.Drawing.Point(404, 66);
            this.labelAxisMax.Name = "labelAxisMax";
            this.labelAxisMax.Size = new System.Drawing.Size(53, 19);
            this.labelAxisMax.TabIndex = 20;
            this.labelAxisMax.Text = "98.00";
            this.labelAxisMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelAxisMax.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelBoundary
            // 
            this.labelBoundary.AutoSize = true;
            this.labelBoundary.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelBoundary.Location = new System.Drawing.Point(192, 60);
            this.labelBoundary.Name = "labelBoundary";
            this.labelBoundary.Size = new System.Drawing.Size(86, 25);
            this.labelBoundary.TabIndex = 21;
            this.labelBoundary.Text = "Boundary";
            this.labelBoundary.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelWagerAmount
            // 
            this.labelWagerAmount.AutoSize = true;
            this.labelWagerAmount.Location = new System.Drawing.Point(23, 180);
            this.labelWagerAmount.Name = "labelWagerAmount";
            this.labelWagerAmount.Size = new System.Drawing.Size(79, 19);
            this.labelWagerAmount.TabIndex = 23;
            this.labelWagerAmount.Text = "Bet Amount";
            this.labelWagerAmount.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // textBoxWagerAmount
            // 
            // 
            // 
            // 
            this.textBoxWagerAmount.CustomButton.Image = null;
            this.textBoxWagerAmount.CustomButton.Location = new System.Drawing.Point(131, 1);
            this.textBoxWagerAmount.CustomButton.Name = "";
            this.textBoxWagerAmount.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.textBoxWagerAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxWagerAmount.CustomButton.TabIndex = 1;
            this.textBoxWagerAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxWagerAmount.CustomButton.UseSelectable = true;
            this.textBoxWagerAmount.CustomButton.Visible = false;
            this.textBoxWagerAmount.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.textBoxWagerAmount.Lines = new string[] {
        "0"};
            this.textBoxWagerAmount.Location = new System.Drawing.Point(25, 202);
            this.textBoxWagerAmount.MaxLength = 32767;
            this.textBoxWagerAmount.Name = "textBoxWagerAmount";
            this.textBoxWagerAmount.PasswordChar = '\0';
            this.textBoxWagerAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxWagerAmount.SelectedText = "";
            this.textBoxWagerAmount.SelectionLength = 0;
            this.textBoxWagerAmount.SelectionStart = 0;
            this.textBoxWagerAmount.ShortcutsEnabled = true;
            this.textBoxWagerAmount.Size = new System.Drawing.Size(163, 33);
            this.textBoxWagerAmount.TabIndex = 22;
            this.textBoxWagerAmount.Text = "0";
            this.textBoxWagerAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxWagerAmount.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBoxWagerAmount.UseSelectable = true;
            this.textBoxWagerAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxWagerAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxWagerAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWagerAmount_KeyDown);
            this.textBoxWagerAmount.Leave += new System.EventHandler(this.textBoxWagerAmount_Leave);
            // 
            // labelCurrencyWagerAmount
            // 
            this.labelCurrencyWagerAmount.AutoSize = true;
            this.labelCurrencyWagerAmount.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelCurrencyWagerAmount.Location = new System.Drawing.Point(190, 205);
            this.labelCurrencyWagerAmount.Name = "labelCurrencyWagerAmount";
            this.labelCurrencyWagerAmount.Size = new System.Drawing.Size(21, 25);
            this.labelCurrencyWagerAmount.TabIndex = 24;
            this.labelCurrencyWagerAmount.Text = "¢";
            this.labelCurrencyWagerAmount.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelCurrencyWagerProfit
            // 
            this.labelCurrencyWagerProfit.AutoSize = true;
            this.labelCurrencyWagerProfit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelCurrencyWagerProfit.Location = new System.Drawing.Point(190, 272);
            this.labelCurrencyWagerProfit.Name = "labelCurrencyWagerProfit";
            this.labelCurrencyWagerProfit.Size = new System.Drawing.Size(21, 25);
            this.labelCurrencyWagerProfit.TabIndex = 27;
            this.labelCurrencyWagerProfit.Text = "¢";
            this.labelCurrencyWagerProfit.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelWagerProfitOnWin
            // 
            this.labelWagerProfitOnWin.AutoSize = true;
            this.labelWagerProfitOnWin.Location = new System.Drawing.Point(23, 247);
            this.labelWagerProfitOnWin.Name = "labelWagerProfitOnWin";
            this.labelWagerProfitOnWin.Size = new System.Drawing.Size(87, 19);
            this.labelWagerProfitOnWin.TabIndex = 26;
            this.labelWagerProfitOnWin.Text = "Profit on Win";
            this.labelWagerProfitOnWin.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // textBoxWagerProfitOnWin
            // 
            // 
            // 
            // 
            this.textBoxWagerProfitOnWin.CustomButton.Image = null;
            this.textBoxWagerProfitOnWin.CustomButton.Location = new System.Drawing.Point(131, 1);
            this.textBoxWagerProfitOnWin.CustomButton.Name = "";
            this.textBoxWagerProfitOnWin.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.textBoxWagerProfitOnWin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxWagerProfitOnWin.CustomButton.TabIndex = 1;
            this.textBoxWagerProfitOnWin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxWagerProfitOnWin.CustomButton.UseSelectable = true;
            this.textBoxWagerProfitOnWin.CustomButton.Visible = false;
            this.textBoxWagerProfitOnWin.Enabled = false;
            this.textBoxWagerProfitOnWin.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.textBoxWagerProfitOnWin.Lines = new string[] {
        "0"};
            this.textBoxWagerProfitOnWin.Location = new System.Drawing.Point(25, 269);
            this.textBoxWagerProfitOnWin.MaxLength = 32767;
            this.textBoxWagerProfitOnWin.Name = "textBoxWagerProfitOnWin";
            this.textBoxWagerProfitOnWin.PasswordChar = '\0';
            this.textBoxWagerProfitOnWin.ReadOnly = true;
            this.textBoxWagerProfitOnWin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxWagerProfitOnWin.SelectedText = "";
            this.textBoxWagerProfitOnWin.SelectionLength = 0;
            this.textBoxWagerProfitOnWin.SelectionStart = 0;
            this.textBoxWagerProfitOnWin.ShortcutsEnabled = true;
            this.textBoxWagerProfitOnWin.Size = new System.Drawing.Size(163, 33);
            this.textBoxWagerProfitOnWin.TabIndex = 25;
            this.textBoxWagerProfitOnWin.Text = "0";
            this.textBoxWagerProfitOnWin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxWagerProfitOnWin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBoxWagerProfitOnWin.UseSelectable = true;
            this.textBoxWagerProfitOnWin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxWagerProfitOnWin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonWagerHalve
            // 
            this.buttonWagerHalve.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.buttonWagerHalve.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.buttonWagerHalve.Location = new System.Drawing.Point(120, 176);
            this.buttonWagerHalve.Name = "buttonWagerHalve";
            this.buttonWagerHalve.Size = new System.Drawing.Size(31, 23);
            this.buttonWagerHalve.TabIndex = 28;
            this.buttonWagerHalve.Text = "½";
            this.buttonWagerHalve.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonWagerHalve.UseSelectable = true;
            this.buttonWagerHalve.Click += new System.EventHandler(this.buttonWagerHalve_Click);
            // 
            // buttonWagerDouble
            // 
            this.buttonWagerDouble.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.buttonWagerDouble.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.buttonWagerDouble.Location = new System.Drawing.Point(157, 176);
            this.buttonWagerDouble.Name = "buttonWagerDouble";
            this.buttonWagerDouble.Size = new System.Drawing.Size(31, 23);
            this.buttonWagerDouble.TabIndex = 29;
            this.buttonWagerDouble.Text = "2x";
            this.buttonWagerDouble.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonWagerDouble.UseSelectable = true;
            this.buttonWagerDouble.Click += new System.EventHandler(this.buttonWagerDouble_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 365);
            this.Controls.Add(this.buttonWagerDouble);
            this.Controls.Add(this.buttonWagerHalve);
            this.Controls.Add(this.labelCurrencyWagerProfit);
            this.Controls.Add(this.labelWagerProfitOnWin);
            this.Controls.Add(this.textBoxWagerProfitOnWin);
            this.Controls.Add(this.labelCurrencyWagerAmount);
            this.Controls.Add(this.labelWagerAmount);
            this.Controls.Add(this.textBoxWagerAmount);
            this.Controls.Add(this.labelBoundary);
            this.Controls.Add(this.labelAxisMax);
            this.Controls.Add(this.labelAxisMin);
            this.Controls.Add(this.labelWinChance);
            this.Controls.Add(this.labelMultiplier);
            this.Controls.Add(this.labelRollBoundary);
            this.Controls.Add(this.labelRollWinChancePercentage);
            this.Controls.Add(this.textBoxRollWinChance);
            this.Controls.Add(this.labelRollMultiplierSymbol);
            this.Controls.Add(this.textBoxRollMultiplier);
            this.Controls.Add(this.pictureBoxToggleBoundary);
            this.Controls.Add(this.textBoxRollBoundary);
            this.Controls.Add(this.trackBarNumber);
            this.Controls.Add(this.linkLabelVerify);
            this.Controls.Add(this.labelFaucetWaitTimer);
            this.Controls.Add(this.buttonUnselect);
            this.Controls.Add(this.pictureBoxFaucet);
            this.Controls.Add(this.labelLogoutNotice);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.pictureBoxProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Sublime Dice";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFaucet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToggleBoundary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.PictureBox pictureBoxProgress;
        private MetroFramework.Controls.MetroLabel labelStatus;
        private MetroFramework.Controls.MetroButton buttonLogout;
        private MetroFramework.Controls.MetroLabel labelLogoutNotice;
        private System.Windows.Forms.PictureBox pictureBoxFaucet;
        private MetroFramework.Controls.MetroButton buttonUnselect;
        private System.Windows.Forms.ToolTip toolTipMain;
        private MetroFramework.Controls.MetroLabel labelFaucetWaitTimer;
        private MetroFramework.Controls.MetroLink linkLabelVerify;
        private MetroFramework.Controls.MetroTrackBar trackBarNumber;
        private MetroFramework.Controls.MetroTextBox textBoxRollBoundary;
        private System.Windows.Forms.PictureBox pictureBoxToggleBoundary;
        private MetroFramework.Controls.MetroTextBox textBoxRollMultiplier;
        private MetroFramework.Controls.MetroLabel labelRollMultiplierSymbol;
        private MetroFramework.Controls.MetroTextBox textBoxRollWinChance;
        private MetroFramework.Controls.MetroLabel labelRollWinChancePercentage;
        private MetroFramework.Controls.MetroLabel labelRollBoundary;
        private MetroFramework.Controls.MetroLabel labelMultiplier;
        private MetroFramework.Controls.MetroLabel labelWinChance;
        private MetroFramework.Controls.MetroLabel labelAxisMin;
        private MetroFramework.Controls.MetroLabel labelAxisMax;
        private MetroFramework.Controls.MetroLabel labelBoundary;
        private MetroFramework.Controls.MetroLabel labelWagerAmount;
        private MetroFramework.Controls.MetroTextBox textBoxWagerAmount;
        private MetroFramework.Controls.MetroLabel labelCurrencyWagerAmount;
        private MetroFramework.Controls.MetroLabel labelCurrencyWagerProfit;
        private MetroFramework.Controls.MetroLabel labelWagerProfitOnWin;
        private MetroFramework.Controls.MetroTextBox textBoxWagerProfitOnWin;
        private MetroFramework.Controls.MetroButton buttonWagerHalve;
        private MetroFramework.Controls.MetroButton buttonWagerDouble;
    }
}