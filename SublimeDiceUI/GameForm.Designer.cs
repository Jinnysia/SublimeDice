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
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFaucet)).BeginInit();
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
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 365);
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
    }
}