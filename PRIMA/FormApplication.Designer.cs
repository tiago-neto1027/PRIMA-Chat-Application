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
            this.btnSend = new MaterialSkin.Controls.MaterialButton();
            this.messageTBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.ChatListBox = new MaterialSkin.Controls.MaterialListBox();
            this.btnWhisper = new MaterialSkin.Controls.MaterialButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleLightDarkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usernameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatRoomListView = new MaterialSkin.Controls.MaterialListView();
            this.messageComboBox = new MaterialSkin.Controls.MaterialComboBox();
            this.userLabel = new MaterialSkin.Controls.MaterialLabel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = false;
            this.btnSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSend.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSend.Depth = 0;
            this.btnSend.HighEmphasis = true;
            this.btnSend.Icon = null;
            this.btnSend.Location = new System.Drawing.Point(961, 484);
            this.btnSend.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSend.Name = "btnSend";
            this.btnSend.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSend.Size = new System.Drawing.Size(96, 59);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSend.UseAccentColor = false;
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // messageTBox
            // 
            this.messageTBox.AnimateReadOnly = false;
            this.messageTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageTBox.Depth = 0;
            this.messageTBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.messageTBox.LeadingIcon = null;
            this.messageTBox.Location = new System.Drawing.Point(344, 484);
            this.messageTBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.messageTBox.MaxLength = 50;
            this.messageTBox.MouseState = MaterialSkin.MouseState.OUT;
            this.messageTBox.Multiline = false;
            this.messageTBox.Name = "messageTBox";
            this.messageTBox.Size = new System.Drawing.Size(608, 50);
            this.messageTBox.TabIndex = 1;
            this.messageTBox.Text = "";
            this.messageTBox.TrailingIcon = null;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(323, 82);
            this.materialDivider1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(13, 460);
            this.materialDivider1.TabIndex = 2;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // ChatListBox
            // 
            this.ChatListBox.BackColor = System.Drawing.Color.White;
            this.ChatListBox.BorderColor = System.Drawing.Color.LightGray;
            this.ChatListBox.Depth = 0;
            this.ChatListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ChatListBox.Location = new System.Drawing.Point(345, 117);
            this.ChatListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatListBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChatListBox.Name = "ChatListBox";
            this.ChatListBox.SelectedIndex = -1;
            this.ChatListBox.SelectedItem = null;
            this.ChatListBox.Size = new System.Drawing.Size(712, 359);
            this.ChatListBox.TabIndex = 3;
            // 
            // btnWhisper
            // 
            this.btnWhisper.AutoSize = false;
            this.btnWhisper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnWhisper.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnWhisper.Depth = 0;
            this.btnWhisper.HighEmphasis = true;
            this.btnWhisper.Icon = null;
            this.btnWhisper.Location = new System.Drawing.Point(9, 484);
            this.btnWhisper.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnWhisper.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnWhisper.Size = new System.Drawing.Size(304, 55);
            this.btnWhisper.TabIndex = 5;
            this.btnWhisper.Text = "Whisper";
            this.btnWhisper.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnWhisper.UseAccentColor = false;
            this.btnWhisper.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.accountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(4, 79);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1059, 38);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleLightDarkModeToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(100, 34);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // toggleLightDarkModeToolStripMenuItem
            // 
            this.toggleLightDarkModeToolStripMenuItem.Name = "toggleLightDarkModeToolStripMenuItem";
            this.toggleLightDarkModeToolStripMenuItem.Size = new System.Drawing.Size(331, 34);
            this.toggleLightDarkModeToolStripMenuItem.Text = "Toggle Light/Dark Mode";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(331, 34);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(331, 34);
            this.disconnectToolStripMenuItem.Text = "Exit";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateInfoToolStripMenuItem});
            this.accountToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(104, 34);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // updateInfoToolStripMenuItem
            // 
            this.updateInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usernameToolStripMenuItem,
            this.nameToolStripMenuItem,
            this.passwordToolStripMenuItem,
            this.emailToolStripMenuItem});
            this.updateInfoToolStripMenuItem.Name = "updateInfoToolStripMenuItem";
            this.updateInfoToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.updateInfoToolStripMenuItem.Text = "Update Info";
            // 
            // usernameToolStripMenuItem
            // 
            this.usernameToolStripMenuItem.Name = "usernameToolStripMenuItem";
            this.usernameToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.usernameToolStripMenuItem.Text = "Username";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.nameToolStripMenuItem.Text = "Name";
            // 
            // passwordToolStripMenuItem
            // 
            this.passwordToolStripMenuItem.Name = "passwordToolStripMenuItem";
            this.passwordToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.passwordToolStripMenuItem.Text = "Password";
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.emailToolStripMenuItem.Text = "Email";
            // 
            // chatRoomListView
            // 
            this.chatRoomListView.AutoSizeTable = false;
            this.chatRoomListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chatRoomListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatRoomListView.Depth = 0;
            this.chatRoomListView.FullRowSelect = true;
            this.chatRoomListView.HideSelection = false;
            this.chatRoomListView.Location = new System.Drawing.Point(4, 191);
            this.chatRoomListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatRoomListView.MinimumSize = new System.Drawing.Size(267, 123);
            this.chatRoomListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chatRoomListView.MouseState = MaterialSkin.MouseState.OUT;
            this.chatRoomListView.Name = "chatRoomListView";
            this.chatRoomListView.OwnerDraw = true;
            this.chatRoomListView.Size = new System.Drawing.Size(309, 286);
            this.chatRoomListView.TabIndex = 8;
            this.chatRoomListView.UseCompatibleStateImageBehavior = false;
            this.chatRoomListView.View = System.Windows.Forms.View.Details;
            // 
            // messageComboBox
            // 
            this.messageComboBox.AutoResize = false;
            this.messageComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.messageComboBox.Depth = 0;
            this.messageComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.messageComboBox.DropDownHeight = 174;
            this.messageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.messageComboBox.DropDownWidth = 121;
            this.messageComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.messageComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.messageComboBox.FormattingEnabled = true;
            this.messageComboBox.IntegralHeight = false;
            this.messageComboBox.ItemHeight = 43;
            this.messageComboBox.Location = new System.Drawing.Point(9, 123);
            this.messageComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.messageComboBox.MaxDropDownItems = 4;
            this.messageComboBox.MouseState = MaterialSkin.MouseState.OUT;
            this.messageComboBox.Name = "messageComboBox";
            this.messageComboBox.Size = new System.Drawing.Size(303, 49);
            this.messageComboBox.StartIndex = 0;
            this.messageComboBox.TabIndex = 4;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Depth = 0;
            this.userLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.userLabel.Location = new System.Drawing.Point(344, 86);
            this.userLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(36, 19);
            this.userLabel.TabIndex = 9;
            this.userLabel.Text = "User:";
            // 
            // FormApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.chatRoomListView);
            this.Controls.Add(this.btnWhisper);
            this.Controls.Add(this.messageComboBox);
            this.Controls.Add(this.ChatListBox);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.messageTBox);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormApplication";
            this.Padding = new System.Windows.Forms.Padding(4, 79, 4, 4);
            this.Text = "PRIMA";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnSend;
        private MaterialSkin.Controls.MaterialTextBox messageTBox;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialListBox ChatListBox;
        private MaterialSkin.Controls.MaterialButton btnWhisper;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleLightDarkModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private MaterialSkin.Controls.MaterialListView chatRoomListView;
        private MaterialSkin.Controls.MaterialComboBox messageComboBox;
        private MaterialSkin.Controls.MaterialLabel userLabel;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usernameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
    }
}