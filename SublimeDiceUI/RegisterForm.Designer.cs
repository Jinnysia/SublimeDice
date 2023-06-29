namespace SublimeDiceUI
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.pictureBoxProgress = new System.Windows.Forms.PictureBox();
            this.labelHeader = new MetroFramework.Controls.MetroLabel();
            this.labelUsername = new MetroFramework.Controls.MetroLabel();
            this.textBoxUsername = new MetroFramework.Controls.MetroTextBox();
            this.textBoxPassword = new MetroFramework.Controls.MetroTextBox();
            this.checkBoxRetain = new MetroFramework.Controls.MetroCheckBox();
            this.buttonRegister = new MetroFramework.Controls.MetroButton();
            this.labelUsernameFooter = new MetroFramework.Controls.MetroLabel();
            this.labelPasswordConfirmFooter = new MetroFramework.Controls.MetroLabel();
            this.textBoxPasswordConfirm = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.labelPassword = new MetroFramework.Controls.MetroLabel();
            this.labelPasswordFooter = new MetroFramework.Controls.MetroLabel();
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
            this.pictureBoxProgress.Location = new System.Drawing.Point(9, 239);
            this.pictureBoxProgress.Name = "pictureBoxProgress";
            this.pictureBoxProgress.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProgress.TabIndex = 0;
            this.pictureBoxProgress.TabStop = false;
            this.pictureBoxProgress.Visible = false;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(23, 60);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(134, 19);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Welcome to Sublime.";
            this.labelHeader.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(23, 97);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(68, 19);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username";
            this.labelUsername.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // textBoxUsername
            // 
            // 
            // 
            // 
            this.textBoxUsername.CustomButton.Image = null;
            this.textBoxUsername.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.textBoxUsername.CustomButton.Name = "";
            this.textBoxUsername.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxUsername.CustomButton.TabIndex = 1;
            this.textBoxUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxUsername.CustomButton.UseSelectable = true;
            this.textBoxUsername.CustomButton.Visible = false;
            this.textBoxUsername.Lines = new string[0];
            this.textBoxUsername.Location = new System.Drawing.Point(97, 97);
            this.textBoxUsername.MaxLength = 30;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.PasswordChar = '\0';
            this.textBoxUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxUsername.SelectedText = "";
            this.textBoxUsername.SelectionLength = 0;
            this.textBoxUsername.SelectionStart = 0;
            this.textBoxUsername.ShortcutsEnabled = true;
            this.textBoxUsername.Size = new System.Drawing.Size(156, 23);
            this.textBoxUsername.TabIndex = 3;
            this.textBoxUsername.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBoxUsername.UseSelectable = true;
            this.textBoxUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // textBoxPassword
            // 
            // 
            // 
            // 
            this.textBoxPassword.CustomButton.Image = null;
            this.textBoxPassword.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.textBoxPassword.CustomButton.Name = "";
            this.textBoxPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxPassword.CustomButton.TabIndex = 1;
            this.textBoxPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxPassword.CustomButton.UseSelectable = true;
            this.textBoxPassword.CustomButton.Visible = false;
            this.textBoxPassword.Lines = new string[0];
            this.textBoxPassword.Location = new System.Drawing.Point(97, 143);
            this.textBoxPassword.MaxLength = 32767;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxPassword.SelectedText = "";
            this.textBoxPassword.SelectionLength = 0;
            this.textBoxPassword.SelectionStart = 0;
            this.textBoxPassword.ShortcutsEnabled = true;
            this.textBoxPassword.Size = new System.Drawing.Size(156, 23);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBoxPassword.UseSelectable = true;
            this.textBoxPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // checkBoxRetain
            // 
            this.checkBoxRetain.AutoSize = true;
            this.checkBoxRetain.Location = new System.Drawing.Point(71, 244);
            this.checkBoxRetain.Name = "checkBoxRetain";
            this.checkBoxRetain.Size = new System.Drawing.Size(125, 15);
            this.checkBoxRetain.TabIndex = 7;
            this.checkBoxRetain.Text = "Remember my info";
            this.checkBoxRetain.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkBoxRetain.UseSelectable = true;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(199, 239);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(54, 23);
            this.buttonRegister.TabIndex = 12;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonRegister.UseSelectable = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // labelUsernameFooter
            // 
            this.labelUsernameFooter.AutoSize = true;
            this.labelUsernameFooter.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelUsernameFooter.Location = new System.Drawing.Point(31, 123);
            this.labelUsernameFooter.Name = "labelUsernameFooter";
            this.labelUsernameFooter.Size = new System.Drawing.Size(150, 15);
            this.labelUsernameFooter.TabIndex = 8;
            this.labelUsernameFooter.Text = "5-30 characters [a-zA-Z0-9].";
            this.labelUsernameFooter.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelPasswordConfirmFooter
            // 
            this.labelPasswordConfirmFooter.AutoSize = true;
            this.labelPasswordConfirmFooter.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelPasswordConfirmFooter.Location = new System.Drawing.Point(31, 215);
            this.labelPasswordConfirmFooter.Name = "labelPasswordConfirmFooter";
            this.labelPasswordConfirmFooter.Size = new System.Drawing.Size(99, 15);
            this.labelPasswordConfirmFooter.TabIndex = 13;
            this.labelPasswordConfirmFooter.Text = "Type it once more.";
            this.labelPasswordConfirmFooter.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // textBoxPasswordConfirm
            // 
            // 
            // 
            // 
            this.textBoxPasswordConfirm.CustomButton.Image = null;
            this.textBoxPasswordConfirm.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.textBoxPasswordConfirm.CustomButton.Name = "";
            this.textBoxPasswordConfirm.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxPasswordConfirm.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxPasswordConfirm.CustomButton.TabIndex = 1;
            this.textBoxPasswordConfirm.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxPasswordConfirm.CustomButton.UseSelectable = true;
            this.textBoxPasswordConfirm.CustomButton.Visible = false;
            this.textBoxPasswordConfirm.Lines = new string[0];
            this.textBoxPasswordConfirm.Location = new System.Drawing.Point(97, 189);
            this.textBoxPasswordConfirm.MaxLength = 32767;
            this.textBoxPasswordConfirm.Name = "textBoxPasswordConfirm";
            this.textBoxPasswordConfirm.PasswordChar = '•';
            this.textBoxPasswordConfirm.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxPasswordConfirm.SelectedText = "";
            this.textBoxPasswordConfirm.SelectionLength = 0;
            this.textBoxPasswordConfirm.SelectionStart = 0;
            this.textBoxPasswordConfirm.ShortcutsEnabled = true;
            this.textBoxPasswordConfirm.Size = new System.Drawing.Size(156, 23);
            this.textBoxPasswordConfirm.TabIndex = 6;
            this.textBoxPasswordConfirm.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBoxPasswordConfirm.UseSelectable = true;
            this.textBoxPasswordConfirm.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxPasswordConfirm.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPasswordConfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 189);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(57, 19);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Confirm";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(23, 143);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(63, 19);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            this.labelPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labelPasswordFooter
            // 
            this.labelPasswordFooter.AutoSize = true;
            this.labelPasswordFooter.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelPasswordFooter.Location = new System.Drawing.Point(31, 169);
            this.labelPasswordFooter.Name = "labelPasswordFooter";
            this.labelPasswordFooter.Size = new System.Drawing.Size(82, 15);
            this.labelPasswordFooter.TabIndex = 9;
            this.labelPasswordFooter.Text = "Make it strong.";
            this.labelPasswordFooter.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 283);
            this.Controls.Add(this.labelPasswordConfirmFooter);
            this.Controls.Add(this.textBoxPasswordConfirm);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.labelPasswordFooter);
            this.Controls.Add(this.labelUsernameFooter);
            this.Controls.Add(this.checkBoxRetain);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBoxProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Register";
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
        private MetroFramework.Controls.MetroLabel labelHeader;
        private MetroFramework.Controls.MetroLabel labelUsername;
        private MetroFramework.Controls.MetroTextBox textBoxUsername;
        private MetroFramework.Controls.MetroTextBox textBoxPassword;
        private MetroFramework.Controls.MetroCheckBox checkBoxRetain;
        private MetroFramework.Controls.MetroButton buttonRegister;
        private MetroFramework.Controls.MetroLabel labelUsernameFooter;
        private MetroFramework.Controls.MetroLabel labelPasswordConfirmFooter;
        private MetroFramework.Controls.MetroTextBox textBoxPasswordConfirm;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel labelPassword;
        private MetroFramework.Controls.MetroLabel labelPasswordFooter;
    }
}