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
            this.btnSettings = new System.Windows.Forms.Button();
            this.chatRoomListView = new MaterialSkin.Controls.MaterialListView();
            this.btnWhisper = new MaterialSkin.Controls.MaterialButton();
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
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // messageTBox
            // 
            this.messageTBox.AnimateReadOnly = false;
            this.messageTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageTBox.Depth = 0;
            this.messageTBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            // ChatListBox
            // 
            this.ChatListBox.BackColor = System.Drawing.Color.White;
            this.ChatListBox.BorderColor = System.Drawing.Color.LightGray;
            this.ChatListBox.Depth = 0;
            this.ChatListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ChatListBox.Location = new System.Drawing.Point(259, 67);
            this.ChatListBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChatListBox.Name = "ChatListBox";
            this.ChatListBox.SelectedIndex = -1;
            this.ChatListBox.SelectedItem = null;
            this.ChatListBox.Size = new System.Drawing.Size(534, 320);
            this.ChatListBox.TabIndex = 3;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImage = global::PRIMA.Properties.Resources.cog_35;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(6, 67);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(35, 35);
            this.btnSettings.TabIndex = 12;
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // chatRoomListView
            // 
            this.chatRoomListView.AutoSizeTable = false;
            this.chatRoomListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chatRoomListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatRoomListView.Depth = 0;
            this.chatRoomListView.FullRowSelect = true;
            this.chatRoomListView.HideSelection = false;
            this.chatRoomListView.Location = new System.Drawing.Point(6, 111);
            this.chatRoomListView.MinimumSize = new System.Drawing.Size(200, 100);
            this.chatRoomListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chatRoomListView.MouseState = MaterialSkin.MouseState.OUT;
            this.chatRoomListView.Name = "chatRoomListView";
            this.chatRoomListView.OwnerDraw = true;
            this.chatRoomListView.Size = new System.Drawing.Size(232, 327);
            this.chatRoomListView.TabIndex = 11;
            this.chatRoomListView.UseCompatibleStateImageBehavior = false;
            this.chatRoomListView.View = System.Windows.Forms.View.Details;
            // 
            // btnWhisper
            // 
            this.btnWhisper.AutoSize = false;
            this.btnWhisper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnWhisper.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnWhisper.Depth = 0;
            this.btnWhisper.HighEmphasis = true;
            this.btnWhisper.Icon = null;
            this.btnWhisper.Location = new System.Drawing.Point(145, 67);
            this.btnWhisper.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnWhisper.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnWhisper.Size = new System.Drawing.Size(90, 35);
            this.btnWhisper.TabIndex = 10;
            this.btnWhisper.Text = "Add";
            this.btnWhisper.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnWhisper.UseAccentColor = false;
            this.btnWhisper.UseVisualStyleBackColor = true;
            // 
            // FormApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.chatRoomListView);
            this.Controls.Add(this.btnWhisper);
            this.Controls.Add(this.ChatListBox);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.messageTBox);
            this.Controls.Add(this.btnSend);
            this.Name = "FormApplication";
            this.Text = "PRIMA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormApplication_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnSend;
        private MaterialSkin.Controls.MaterialTextBox messageTBox;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialListBox ChatListBox;
        private System.Windows.Forms.Button btnSettings;
        private MaterialSkin.Controls.MaterialListView chatRoomListView;
        private MaterialSkin.Controls.MaterialButton btnWhisper;
    }
}