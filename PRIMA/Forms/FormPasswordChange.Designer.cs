namespace PRIMA.Forms
{
    partial class FormPasswordChange
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
            this.OldPasswordTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.OldPasswordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.ChangePasswordButton = new MaterialSkin.Controls.MaterialButton();
            this.NewPasswordTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.NewPasswordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.ConfirmPasswordTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.ConfirmPasswordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.leavePasswordChangeButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // OldPasswordTextBox
            // 
            this.OldPasswordTextBox.AnimateReadOnly = false;
            this.OldPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.OldPasswordTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OldPasswordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.OldPasswordTextBox.Depth = 0;
            this.OldPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.OldPasswordTextBox.HideSelection = true;
            this.OldPasswordTextBox.LeadingIcon = null;
            this.OldPasswordTextBox.Location = new System.Drawing.Point(93, 127);
            this.OldPasswordTextBox.MaxLength = 32767;
            this.OldPasswordTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.OldPasswordTextBox.Name = "OldPasswordTextBox";
            this.OldPasswordTextBox.PasswordChar = '●';
            this.OldPasswordTextBox.PrefixSuffixText = null;
            this.OldPasswordTextBox.ReadOnly = false;
            this.OldPasswordTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OldPasswordTextBox.SelectedText = "";
            this.OldPasswordTextBox.SelectionLength = 0;
            this.OldPasswordTextBox.SelectionStart = 0;
            this.OldPasswordTextBox.ShortcutsEnabled = true;
            this.OldPasswordTextBox.Size = new System.Drawing.Size(189, 48);
            this.OldPasswordTextBox.TabIndex = 10;
            this.OldPasswordTextBox.TabStop = false;
            this.OldPasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OldPasswordTextBox.TrailingIcon = null;
            this.OldPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // OldPasswordLabel
            // 
            this.OldPasswordLabel.AutoSize = true;
            this.OldPasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.OldPasswordLabel.Depth = 0;
            this.OldPasswordLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.OldPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OldPasswordLabel.Location = new System.Drawing.Point(90, 105);
            this.OldPasswordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.OldPasswordLabel.Name = "OldPasswordLabel";
            this.OldPasswordLabel.Size = new System.Drawing.Size(99, 19);
            this.OldPasswordLabel.TabIndex = 9;
            this.OldPasswordLabel.Text = "Old Password";
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChangePasswordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ChangePasswordButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ChangePasswordButton.Depth = 0;
            this.ChangePasswordButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChangePasswordButton.HighEmphasis = true;
            this.ChangePasswordButton.Icon = null;
            this.ChangePasswordButton.Location = new System.Drawing.Point(114, 351);
            this.ChangePasswordButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ChangePasswordButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ChangePasswordButton.Size = new System.Drawing.Size(80, 36);
            this.ChangePasswordButton.TabIndex = 8;
            this.ChangePasswordButton.Text = "Change";
            this.ChangePasswordButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ChangePasswordButton.UseAccentColor = false;
            this.ChangePasswordButton.UseVisualStyleBackColor = false;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // NewPasswordTextBox
            // 
            this.NewPasswordTextBox.AnimateReadOnly = false;
            this.NewPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.NewPasswordTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NewPasswordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.NewPasswordTextBox.Depth = 0;
            this.NewPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NewPasswordTextBox.HideSelection = true;
            this.NewPasswordTextBox.LeadingIcon = null;
            this.NewPasswordTextBox.Location = new System.Drawing.Point(93, 203);
            this.NewPasswordTextBox.MaxLength = 32767;
            this.NewPasswordTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NewPasswordTextBox.Name = "NewPasswordTextBox";
            this.NewPasswordTextBox.PasswordChar = '●';
            this.NewPasswordTextBox.PrefixSuffixText = null;
            this.NewPasswordTextBox.ReadOnly = false;
            this.NewPasswordTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NewPasswordTextBox.SelectedText = "";
            this.NewPasswordTextBox.SelectionLength = 0;
            this.NewPasswordTextBox.SelectionStart = 0;
            this.NewPasswordTextBox.ShortcutsEnabled = true;
            this.NewPasswordTextBox.Size = new System.Drawing.Size(189, 48);
            this.NewPasswordTextBox.TabIndex = 12;
            this.NewPasswordTextBox.TabStop = false;
            this.NewPasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NewPasswordTextBox.TrailingIcon = null;
            this.NewPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // NewPasswordLabel
            // 
            this.NewPasswordLabel.AutoSize = true;
            this.NewPasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.NewPasswordLabel.Depth = 0;
            this.NewPasswordLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NewPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NewPasswordLabel.Location = new System.Drawing.Point(90, 181);
            this.NewPasswordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewPasswordLabel.Name = "NewPasswordLabel";
            this.NewPasswordLabel.Size = new System.Drawing.Size(106, 19);
            this.NewPasswordLabel.TabIndex = 11;
            this.NewPasswordLabel.Text = "New Password";
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.AnimateReadOnly = false;
            this.ConfirmPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ConfirmPasswordTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ConfirmPasswordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ConfirmPasswordTextBox.Depth = 0;
            this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ConfirmPasswordTextBox.HideSelection = true;
            this.ConfirmPasswordTextBox.LeadingIcon = null;
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(93, 280);
            this.ConfirmPasswordTextBox.MaxLength = 32767;
            this.ConfirmPasswordTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.PasswordChar = '●';
            this.ConfirmPasswordTextBox.PrefixSuffixText = null;
            this.ConfirmPasswordTextBox.ReadOnly = false;
            this.ConfirmPasswordTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ConfirmPasswordTextBox.SelectedText = "";
            this.ConfirmPasswordTextBox.SelectionLength = 0;
            this.ConfirmPasswordTextBox.SelectionStart = 0;
            this.ConfirmPasswordTextBox.ShortcutsEnabled = true;
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(189, 48);
            this.ConfirmPasswordTextBox.TabIndex = 14;
            this.ConfirmPasswordTextBox.TabStop = false;
            this.ConfirmPasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ConfirmPasswordTextBox.TrailingIcon = null;
            this.ConfirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ConfirmPasswordLabel
            // 
            this.ConfirmPasswordLabel.AutoSize = true;
            this.ConfirmPasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ConfirmPasswordLabel.Depth = 0;
            this.ConfirmPasswordLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ConfirmPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ConfirmPasswordLabel.Location = new System.Drawing.Point(90, 258);
            this.ConfirmPasswordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            this.ConfirmPasswordLabel.Size = new System.Drawing.Size(132, 19);
            this.ConfirmPasswordLabel.TabIndex = 13;
            this.ConfirmPasswordLabel.Text = "Confirm Password";
            // 
            // leavePasswordChangeButton
            // 
            this.leavePasswordChangeButton.AutoSize = false;
            this.leavePasswordChangeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.leavePasswordChangeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.leavePasswordChangeButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.leavePasswordChangeButton.Depth = 0;
            this.leavePasswordChangeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.leavePasswordChangeButton.HighEmphasis = true;
            this.leavePasswordChangeButton.Icon = null;
            this.leavePasswordChangeButton.Location = new System.Drawing.Point(202, 351);
            this.leavePasswordChangeButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.leavePasswordChangeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.leavePasswordChangeButton.Name = "leavePasswordChangeButton";
            this.leavePasswordChangeButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.leavePasswordChangeButton.Size = new System.Drawing.Size(80, 36);
            this.leavePasswordChangeButton.TabIndex = 15;
            this.leavePasswordChangeButton.Text = "Leave";
            this.leavePasswordChangeButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.leavePasswordChangeButton.UseAccentColor = false;
            this.leavePasswordChangeButton.UseVisualStyleBackColor = false;
            this.leavePasswordChangeButton.Click += new System.EventHandler(this.leavePasswordChangeButton_Click);
            // 
            // FormPasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 414);
            this.Controls.Add(this.leavePasswordChangeButton);
            this.Controls.Add(this.ConfirmPasswordTextBox);
            this.Controls.Add(this.ConfirmPasswordLabel);
            this.Controls.Add(this.NewPasswordTextBox);
            this.Controls.Add(this.NewPasswordLabel);
            this.Controls.Add(this.OldPasswordTextBox);
            this.Controls.Add(this.OldPasswordLabel);
            this.Controls.Add(this.ChangePasswordButton);
            this.Name = "FormPasswordChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormPasswordChange";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 OldPasswordTextBox;
        private MaterialSkin.Controls.MaterialLabel OldPasswordLabel;
        private MaterialSkin.Controls.MaterialButton ChangePasswordButton;
        private MaterialSkin.Controls.MaterialTextBox2 NewPasswordTextBox;
        private MaterialSkin.Controls.MaterialLabel NewPasswordLabel;
        private MaterialSkin.Controls.MaterialTextBox2 ConfirmPasswordTextBox;
        private MaterialSkin.Controls.MaterialLabel ConfirmPasswordLabel;
        private MaterialSkin.Controls.MaterialButton leavePasswordChangeButton;
    }
}