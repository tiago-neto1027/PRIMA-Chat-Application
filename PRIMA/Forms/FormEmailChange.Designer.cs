﻿namespace PRIMA.Forms
{
    partial class FormEmailChange
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
            this.ChangeEmailButton = new MaterialSkin.Controls.MaterialButton();
            this.PasswordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.NewEmailLabel = new MaterialSkin.Controls.MaterialLabel();
            this.OldEmailLabel = new MaterialSkin.Controls.MaterialLabel();
            this.PasswordTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.NewEmailTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.leaveEmailChangeButton = new MaterialSkin.Controls.MaterialButton();
            this.OldEmailBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.SuspendLayout();
            // 
            // ChangeEmailButton
            // 
            this.ChangeEmailButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChangeEmailButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ChangeEmailButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ChangeEmailButton.Depth = 0;
            this.ChangeEmailButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChangeEmailButton.HighEmphasis = true;
            this.ChangeEmailButton.Icon = null;
            this.ChangeEmailButton.Location = new System.Drawing.Point(122, 347);
            this.ChangeEmailButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ChangeEmailButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangeEmailButton.Name = "ChangeEmailButton";
            this.ChangeEmailButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ChangeEmailButton.Size = new System.Drawing.Size(80, 36);
            this.ChangeEmailButton.TabIndex = 2;
            this.ChangeEmailButton.Text = "Change";
            this.ChangeEmailButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ChangeEmailButton.UseAccentColor = false;
            this.ChangeEmailButton.UseVisualStyleBackColor = false;
            this.ChangeEmailButton.Click += new System.EventHandler(this.ChangeEmailButton_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.PasswordLabel.Depth = 0;
            this.PasswordLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PasswordLabel.Location = new System.Drawing.Point(83, 167);
            this.PasswordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(71, 19);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // NewEmailLabel
            // 
            this.NewEmailLabel.AutoSize = true;
            this.NewEmailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.NewEmailLabel.Depth = 0;
            this.NewEmailLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NewEmailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NewEmailLabel.Location = new System.Drawing.Point(83, 255);
            this.NewEmailLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewEmailLabel.Name = "NewEmailLabel";
            this.NewEmailLabel.Size = new System.Drawing.Size(76, 19);
            this.NewEmailLabel.TabIndex = 4;
            this.NewEmailLabel.Text = "New Email";
            // 
            // OldEmailLabel
            // 
            this.OldEmailLabel.AutoSize = true;
            this.OldEmailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.OldEmailLabel.Depth = 0;
            this.OldEmailLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.OldEmailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OldEmailLabel.Location = new System.Drawing.Point(83, 82);
            this.OldEmailLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.OldEmailLabel.Name = "OldEmailLabel";
            this.OldEmailLabel.Size = new System.Drawing.Size(69, 19);
            this.OldEmailLabel.TabIndex = 5;
            this.OldEmailLabel.Text = "Old Email";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.AnimateReadOnly = false;
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.PasswordTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PasswordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PasswordTextBox.Depth = 0;
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PasswordTextBox.HideSelection = true;
            this.PasswordTextBox.LeadingIcon = null;
            this.PasswordTextBox.Location = new System.Drawing.Point(86, 189);
            this.PasswordTextBox.MaxLength = 32767;
            this.PasswordTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '●';
            this.PasswordTextBox.PrefixSuffixText = null;
            this.PasswordTextBox.ReadOnly = false;
            this.PasswordTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PasswordTextBox.SelectedText = "";
            this.PasswordTextBox.SelectionLength = 0;
            this.PasswordTextBox.SelectionStart = 0;
            this.PasswordTextBox.ShortcutsEnabled = true;
            this.PasswordTextBox.Size = new System.Drawing.Size(189, 48);
            this.PasswordTextBox.TabIndex = 0;
            this.PasswordTextBox.TabStop = false;
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PasswordTextBox.TrailingIcon = null;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // NewEmailTextBox
            // 
            this.NewEmailTextBox.AnimateReadOnly = false;
            this.NewEmailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.NewEmailTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NewEmailTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.NewEmailTextBox.Depth = 0;
            this.NewEmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NewEmailTextBox.HideSelection = true;
            this.NewEmailTextBox.LeadingIcon = null;
            this.NewEmailTextBox.Location = new System.Drawing.Point(86, 278);
            this.NewEmailTextBox.MaxLength = 32767;
            this.NewEmailTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NewEmailTextBox.Name = "NewEmailTextBox";
            this.NewEmailTextBox.PasswordChar = '\0';
            this.NewEmailTextBox.PrefixSuffixText = null;
            this.NewEmailTextBox.ReadOnly = false;
            this.NewEmailTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NewEmailTextBox.SelectedText = "";
            this.NewEmailTextBox.SelectionLength = 0;
            this.NewEmailTextBox.SelectionStart = 0;
            this.NewEmailTextBox.ShortcutsEnabled = true;
            this.NewEmailTextBox.Size = new System.Drawing.Size(189, 48);
            this.NewEmailTextBox.TabIndex = 1;
            this.NewEmailTextBox.TabStop = false;
            this.NewEmailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NewEmailTextBox.TrailingIcon = null;
            this.NewEmailTextBox.UseSystemPasswordChar = false;
            this.NewEmailTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewEmailTextBox_KeyDown);
            // 
            // leaveEmailChangeButton
            // 
            this.leaveEmailChangeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.leaveEmailChangeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.leaveEmailChangeButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.leaveEmailChangeButton.Depth = 0;
            this.leaveEmailChangeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.leaveEmailChangeButton.HighEmphasis = true;
            this.leaveEmailChangeButton.Icon = null;
            this.leaveEmailChangeButton.Location = new System.Drawing.Point(210, 347);
            this.leaveEmailChangeButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.leaveEmailChangeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.leaveEmailChangeButton.Name = "leaveEmailChangeButton";
            this.leaveEmailChangeButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.leaveEmailChangeButton.Size = new System.Drawing.Size(65, 36);
            this.leaveEmailChangeButton.TabIndex = 3;
            this.leaveEmailChangeButton.Text = "Leave";
            this.leaveEmailChangeButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.leaveEmailChangeButton.UseAccentColor = false;
            this.leaveEmailChangeButton.UseVisualStyleBackColor = false;
            this.leaveEmailChangeButton.Click += new System.EventHandler(this.leaveEmailChangeButton_Click);
            // 
            // OldEmailBox
            // 
            this.OldEmailBox.AnimateReadOnly = false;
            this.OldEmailBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.OldEmailBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OldEmailBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.OldEmailBox.Depth = 0;
            this.OldEmailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.OldEmailBox.HideSelection = true;
            this.OldEmailBox.LeadingIcon = null;
            this.OldEmailBox.Location = new System.Drawing.Point(86, 104);
            this.OldEmailBox.MaxLength = 32767;
            this.OldEmailBox.MouseState = MaterialSkin.MouseState.OUT;
            this.OldEmailBox.Name = "OldEmailBox";
            this.OldEmailBox.PasswordChar = '\0';
            this.OldEmailBox.PrefixSuffixText = null;
            this.OldEmailBox.ReadOnly = false;
            this.OldEmailBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OldEmailBox.SelectedText = "";
            this.OldEmailBox.SelectionLength = 0;
            this.OldEmailBox.SelectionStart = 0;
            this.OldEmailBox.ShortcutsEnabled = true;
            this.OldEmailBox.Size = new System.Drawing.Size(189, 48);
            this.OldEmailBox.TabIndex = 9;
            this.OldEmailBox.TabStop = false;
            this.OldEmailBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OldEmailBox.TrailingIcon = null;
            this.OldEmailBox.UseSystemPasswordChar = false;
            // 
            // FormEmailChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 414);
            this.Controls.Add(this.leaveEmailChangeButton);
            this.Controls.Add(this.OldEmailBox);
            this.Controls.Add(this.NewEmailTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.OldEmailLabel);
            this.Controls.Add(this.NewEmailLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.ChangeEmailButton);
            this.Name = "FormEmailChange";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Email Change";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton ChangeEmailButton;
        private MaterialSkin.Controls.MaterialLabel PasswordLabel;
        private MaterialSkin.Controls.MaterialLabel NewEmailLabel;
        private MaterialSkin.Controls.MaterialLabel OldEmailLabel;
        private MaterialSkin.Controls.MaterialTextBox2 PasswordTextBox;
        private MaterialSkin.Controls.MaterialTextBox2 NewEmailTextBox;
        private MaterialSkin.Controls.MaterialButton leaveEmailChangeButton;
        private MaterialSkin.Controls.MaterialTextBox2 OldEmailBox;
    }
}