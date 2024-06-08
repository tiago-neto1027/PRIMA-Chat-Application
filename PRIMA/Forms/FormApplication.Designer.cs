namespace PRIMA
{
    partial class FormApplication
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
            this.btnSend = new MaterialSkin.Controls.MaterialButton();
            this.messageTBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.messagesListBox = new MaterialSkin.Controls.MaterialListBox();
            this.btnWhisper = new MaterialSkin.Controls.MaterialButton();
            this.chatsListBox = new MaterialSkin.Controls.MaterialListBox();
            this.settingsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.settingsButton = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.darkModeSwitch = new MaterialSkin.Controls.MaterialSwitch();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonChangeEmail = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.optionsLogoutButton = new MaterialSkin.Controls.MaterialButton();
            this.settingsMenuTimer = new System.Windows.Forms.Timer(this.components);
            this.usernameDisplay = new System.Windows.Forms.Label();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = false;
            this.btnSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSend.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSend.Depth = 0;
            this.btnSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSend.HighEmphasis = true;
            this.btnSend.Icon = null;
            this.btnSend.Location = new System.Drawing.Point(721, 393);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSend.Name = "btnSend";
            this.btnSend.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSend.Size = new System.Drawing.Size(72, 48);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSend.UseAccentColor = false;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // messageTBox
            // 
            this.messageTBox.AnimateReadOnly = false;
            this.messageTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.messageTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageTBox.Depth = 0;
            this.messageTBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.messageTBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.messageTBox.LeadingIcon = null;
            this.messageTBox.Location = new System.Drawing.Point(258, 393);
            this.messageTBox.MaxLength = 50;
            this.messageTBox.MouseState = MaterialSkin.MouseState.OUT;
            this.messageTBox.Multiline = false;
            this.messageTBox.Name = "messageTBox";
            this.messageTBox.Size = new System.Drawing.Size(456, 50);
            this.messageTBox.TabIndex = 1;
            this.messageTBox.Text = "";
            this.messageTBox.TrailingIcon = null;
            this.messageTBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageTBox_KeyDown);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(242, 67);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(10, 374);
            this.materialDivider1.TabIndex = 2;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // messagesListBox
            // 
            this.messagesListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.messagesListBox.BorderColor = System.Drawing.Color.LightGray;
            this.messagesListBox.Depth = 0;
            this.messagesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.messagesListBox.Location = new System.Drawing.Point(258, 67);
            this.messagesListBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.messagesListBox.Name = "messagesListBox";
            this.messagesListBox.SelectedIndex = -1;
            this.messagesListBox.SelectedItem = null;
            this.messagesListBox.Size = new System.Drawing.Size(534, 320);
            this.messagesListBox.TabIndex = 3;
            // 
            // btnWhisper
            // 
            this.btnWhisper.AutoSize = false;
            this.btnWhisper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnWhisper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnWhisper.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnWhisper.Depth = 0;
            this.btnWhisper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnWhisper.HighEmphasis = true;
            this.btnWhisper.Icon = null;
            this.btnWhisper.Location = new System.Drawing.Point(55, 408);
            this.btnWhisper.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnWhisper.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnWhisper.Size = new System.Drawing.Size(179, 35);
            this.btnWhisper.TabIndex = 10;
            this.btnWhisper.Text = "Add Chat";
            this.btnWhisper.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnWhisper.UseAccentColor = false;
            this.btnWhisper.UseVisualStyleBackColor = false;
            // 
            // chatsListBox
            // 
            this.chatsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.chatsListBox.BorderColor = System.Drawing.Color.LightGray;
            this.chatsListBox.Depth = 0;
            this.chatsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chatsListBox.Location = new System.Drawing.Point(54, 67);
            this.chatsListBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.chatsListBox.Name = "chatsListBox";
            this.chatsListBox.SelectedIndex = -1;
            this.chatsListBox.SelectedItem = null;
            this.chatsListBox.Size = new System.Drawing.Size(182, 332);
            this.chatsListBox.TabIndex = 13;
            this.chatsListBox.SelectedIndexChanged += new MaterialSkin.Controls.MaterialListBox.SelectedIndexChangedEventHandler(this.chatsListBox_SelectedIndexChanged);
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.Color.White;
            this.settingsPanel.Controls.Add(this.settingsButton);
            this.settingsPanel.Controls.Add(this.panel1);
            this.settingsPanel.Controls.Add(this.panel2);
            this.settingsPanel.Controls.Add(this.panel3);
            this.settingsPanel.Controls.Add(this.panel4);
            this.settingsPanel.Controls.Add(this.panel5);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.settingsPanel.Location = new System.Drawing.Point(3, 64);
            this.settingsPanel.MaximumSize = new System.Drawing.Size(235, 0);
            this.settingsPanel.MinimumSize = new System.Drawing.Size(45, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(45, 383);
            this.settingsPanel.TabIndex = 14;
            // 
            // settingsButton
            // 
            this.settingsButton.Image = global::PRIMA.Properties.Resources.icons8_settings_50;
            this.settingsButton.InitialImage = global::PRIMA.Properties.Resources.icons8_settings_50;
            this.settingsButton.Location = new System.Drawing.Point(3, 3);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(35, 35);
            this.settingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settingsButton.TabIndex = 0;
            this.settingsButton.TabStop = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.darkModeSwitch);
            this.panel1.Location = new System.Drawing.Point(3, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 55);
            this.panel1.TabIndex = 1;
            // 
            // darkModeSwitch
            // 
            this.darkModeSwitch.AutoSize = true;
            this.darkModeSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.darkModeSwitch.Depth = 0;
            this.darkModeSwitch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.darkModeSwitch.Location = new System.Drawing.Point(48, 2);
            this.darkModeSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.darkModeSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.darkModeSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            this.darkModeSwitch.Name = "darkModeSwitch";
            this.darkModeSwitch.Ripple = true;
            this.darkModeSwitch.Size = new System.Drawing.Size(178, 37);
            this.darkModeSwitch.TabIndex = 0;
            this.darkModeSwitch.Text = "Light/Dark Mode";
            this.darkModeSwitch.UseVisualStyleBackColor = false;
            this.darkModeSwitch.CheckedChanged += new System.EventHandler(this.darkModeSwitch_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonChangePassword);
            this.panel2.Location = new System.Drawing.Point(3, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 55);
            this.panel2.TabIndex = 15;
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.buttonChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangePassword.Font = new System.Drawing.Font("Arial", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangePassword.Location = new System.Drawing.Point(-15, -19);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Padding = new System.Windows.Forms.Padding(66, 0, 0, 0);
            this.buttonChangePassword.Size = new System.Drawing.Size(261, 83);
            this.buttonChangePassword.TabIndex = 0;
            this.buttonChangePassword.Text = "Change Password";
            this.buttonChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChangePassword.UseVisualStyleBackColor = false;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            this.buttonChangePassword.MouseEnter += new System.EventHandler(this.buttonChangePassword_MouseEnter);
            this.buttonChangePassword.MouseLeave += new System.EventHandler(this.buttonChangePassword_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonChangeEmail);
            this.panel3.Location = new System.Drawing.Point(3, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 55);
            this.panel3.TabIndex = 16;
            // 
            // buttonChangeEmail
            // 
            this.buttonChangeEmail.BackColor = System.Drawing.Color.Transparent;
            this.buttonChangeEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeEmail.Font = new System.Drawing.Font("Arial", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeEmail.Location = new System.Drawing.Point(-14, -16);
            this.buttonChangeEmail.Name = "buttonChangeEmail";
            this.buttonChangeEmail.Padding = new System.Windows.Forms.Padding(66, 0, 0, 0);
            this.buttonChangeEmail.Size = new System.Drawing.Size(261, 83);
            this.buttonChangeEmail.TabIndex = 0;
            this.buttonChangeEmail.Text = "Change Email";
            this.buttonChangeEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChangeEmail.UseVisualStyleBackColor = false;
            this.buttonChangeEmail.Click += new System.EventHandler(this.buttonChangeEmail_Click);
            this.buttonChangeEmail.MouseEnter += new System.EventHandler(this.buttonChangeEmail_MouseEnter);
            this.buttonChangeEmail.MouseLeave += new System.EventHandler(this.buttonChangeEmail_MouseLeave);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(3, 227);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(232, 93);
            this.panel4.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.optionsLogoutButton);
            this.panel5.Location = new System.Drawing.Point(3, 326);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(232, 54);
            this.panel5.TabIndex = 18;
            // 
            // optionsLogoutButton
            // 
            this.optionsLogoutButton.AutoSize = false;
            this.optionsLogoutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.optionsLogoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.optionsLogoutButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.optionsLogoutButton.Depth = 0;
            this.optionsLogoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.optionsLogoutButton.HighEmphasis = true;
            this.optionsLogoutButton.Icon = null;
            this.optionsLogoutButton.Location = new System.Drawing.Point(78, 3);
            this.optionsLogoutButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.optionsLogoutButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.optionsLogoutButton.Name = "optionsLogoutButton";
            this.optionsLogoutButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.optionsLogoutButton.Size = new System.Drawing.Size(72, 48);
            this.optionsLogoutButton.TabIndex = 15;
            this.optionsLogoutButton.Text = "Log Out";
            this.optionsLogoutButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.optionsLogoutButton.UseAccentColor = false;
            this.optionsLogoutButton.UseVisualStyleBackColor = false;
            this.optionsLogoutButton.Click += new System.EventHandler(this.optionsLogoutButton_Click);
            // 
            // settingsMenuTimer
            // 
            this.settingsMenuTimer.Interval = 10;
            this.settingsMenuTimer.Tick += new System.EventHandler(this.settingsMenuTimer_Tick);
            // 
            // usernameDisplay
            // 
            this.usernameDisplay.AutoSize = true;
            this.usernameDisplay.BackColor = System.Drawing.Color.Transparent;
            this.usernameDisplay.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameDisplay.ForeColor = System.Drawing.Color.White;
            this.usernameDisplay.Location = new System.Drawing.Point(254, 34);
            this.usernameDisplay.Name = "usernameDisplay";
            this.usernameDisplay.Size = new System.Drawing.Size(58, 21);
            this.usernameDisplay.TabIndex = 15;
            this.usernameDisplay.Text = "User:";
            // 
            // FormApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usernameDisplay);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.chatsListBox);
            this.Controls.Add(this.btnWhisper);
            this.Controls.Add(this.messagesListBox);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.messageTBox);
            this.Controls.Add(this.btnSend);
            this.Name = "FormApplication";
            this.Sizable = false;
            this.Text = "PRIMA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormApplication_FormClosing);
            this.settingsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnSend;
        private MaterialSkin.Controls.MaterialTextBox messageTBox;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialListBox messagesListBox;
        private MaterialSkin.Controls.MaterialButton btnWhisper;
        private MaterialSkin.Controls.MaterialListBox chatsListBox;
        private System.Windows.Forms.FlowLayoutPanel settingsPanel;
        private System.Windows.Forms.PictureBox settingsButton;
        private System.Windows.Forms.Timer settingsMenuTimer;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialSwitch darkModeSwitch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonChangeEmail;
        private MaterialSkin.Controls.MaterialButton optionsLogoutButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label usernameDisplay;
    }
}