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
            this.labelBalance = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).BeginInit();
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
            this.pictureBoxProgress.Location = new System.Drawing.Point(11, 321);
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
            this.labelStatus.Text = "You are logged in as: {Username}.";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(395, 333);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 2;
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
            // labelBalance
            // 
            this.labelBalance.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelBalance.Location = new System.Drawing.Point(263, 286);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(207, 25);
            this.labelBalance.TabIndex = 4;
            this.labelBalance.Text = "¢0";
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelBalance.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 365);
            this.Controls.Add(this.labelBalance);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.PictureBox pictureBoxProgress;
        private MetroFramework.Controls.MetroLabel labelStatus;
        private MetroFramework.Controls.MetroButton buttonLogout;
        private MetroFramework.Controls.MetroLabel labelLogoutNotice;
        private MetroFramework.Controls.MetroLabel labelBalance;
    }
}