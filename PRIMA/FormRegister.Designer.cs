namespace PRIMA
{
    partial class FormRegister
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
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.labelName = new MaterialSkin.Controls.MaterialLabel();
            this.registryTBoxName = new MaterialSkin.Controls.MaterialTextBox();
            this.btnRegister = new MaterialSkin.Controls.MaterialButton();
            this.labelPassword = new MaterialSkin.Controls.MaterialLabel();
            this.labelEmail = new MaterialSkin.Controls.MaterialLabel();
            this.labelUserName = new MaterialSkin.Controls.MaterialLabel();
            this.registryTBoxPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.registryTBoxEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.registryTBoxUserName = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(538, 451);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogin.Size = new System.Drawing.Size(64, 36);
            this.btnLogin.TabIndex = 18;
            this.btnLogin.Text = "Login";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Depth = 0;
            this.labelName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelName.Location = new System.Drawing.Point(202, 190);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(47, 19);
            this.labelName.TabIndex = 20;
            this.labelName.Text = "Name:";
            // 
            // registryTBoxName
            // 
            this.registryTBoxName.AnimateReadOnly = false;
            this.registryTBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registryTBoxName.Depth = 0;
            this.registryTBoxName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.registryTBoxName.LeadingIcon = null;
            this.registryTBoxName.Location = new System.Drawing.Point(204, 215);
            this.registryTBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.registryTBoxName.MaxLength = 50;
            this.registryTBoxName.MouseState = MaterialSkin.MouseState.OUT;
            this.registryTBoxName.Multiline = false;
            this.registryTBoxName.Name = "registryTBoxName";
            this.registryTBoxName.Size = new System.Drawing.Size(392, 50);
            this.registryTBoxName.TabIndex = 14;
            this.registryTBoxName.Text = "";
            this.registryTBoxName.TrailingIcon = null;
            // 
            // btnRegister
            // 
            this.btnRegister.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegister.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRegister.Depth = 0;
            this.btnRegister.HighEmphasis = true;
            this.btnRegister.Icon = null;
            this.btnRegister.Location = new System.Drawing.Point(204, 451);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRegister.Size = new System.Drawing.Size(89, 36);
            this.btnRegister.TabIndex = 17;
            this.btnRegister.Text = "Register";
            this.btnRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRegister.UseAccentColor = false;
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Depth = 0;
            this.labelPassword.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelPassword.Location = new System.Drawing.Point(202, 356);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(75, 19);
            this.labelPassword.TabIndex = 17;
            this.labelPassword.Text = "Password:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Depth = 0;
            this.labelEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEmail.Location = new System.Drawing.Point(202, 273);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(45, 19);
            this.labelEmail.TabIndex = 15;
            this.labelEmail.Text = "Email:";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Depth = 0;
            this.labelUserName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelUserName.Location = new System.Drawing.Point(202, 104);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(82, 19);
            this.labelUserName.TabIndex = 16;
            this.labelUserName.Text = "User Name:";
            // 
            // registryTBoxPassword
            // 
            this.registryTBoxPassword.AnimateReadOnly = false;
            this.registryTBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registryTBoxPassword.Depth = 0;
            this.registryTBoxPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.registryTBoxPassword.LeadingIcon = null;
            this.registryTBoxPassword.Location = new System.Drawing.Point(204, 381);
            this.registryTBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.registryTBoxPassword.MaxLength = 50;
            this.registryTBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.registryTBoxPassword.Multiline = false;
            this.registryTBoxPassword.Name = "registryTBoxPassword";
            this.registryTBoxPassword.Password = true;
            this.registryTBoxPassword.Size = new System.Drawing.Size(392, 50);
            this.registryTBoxPassword.TabIndex = 16;
            this.registryTBoxPassword.Text = "";
            this.registryTBoxPassword.TrailingIcon = null;
            // 
            // registryTBoxEmail
            // 
            this.registryTBoxEmail.AnimateReadOnly = false;
            this.registryTBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registryTBoxEmail.Depth = 0;
            this.registryTBoxEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.registryTBoxEmail.LeadingIcon = null;
            this.registryTBoxEmail.Location = new System.Drawing.Point(204, 298);
            this.registryTBoxEmail.Margin = new System.Windows.Forms.Padding(2);
            this.registryTBoxEmail.MaxLength = 50;
            this.registryTBoxEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.registryTBoxEmail.Multiline = false;
            this.registryTBoxEmail.Name = "registryTBoxEmail";
            this.registryTBoxEmail.Size = new System.Drawing.Size(392, 50);
            this.registryTBoxEmail.TabIndex = 15;
            this.registryTBoxEmail.Text = "";
            this.registryTBoxEmail.TrailingIcon = null;
            // 
            // registryTBoxUserName
            // 
            this.registryTBoxUserName.AnimateReadOnly = false;
            this.registryTBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registryTBoxUserName.Depth = 0;
            this.registryTBoxUserName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.registryTBoxUserName.LeadingIcon = null;
            this.registryTBoxUserName.Location = new System.Drawing.Point(204, 129);
            this.registryTBoxUserName.Margin = new System.Windows.Forms.Padding(2);
            this.registryTBoxUserName.MaxLength = 50;
            this.registryTBoxUserName.MouseState = MaterialSkin.MouseState.OUT;
            this.registryTBoxUserName.Multiline = false;
            this.registryTBoxUserName.Name = "registryTBoxUserName";
            this.registryTBoxUserName.Size = new System.Drawing.Size(392, 50);
            this.registryTBoxUserName.TabIndex = 13;
            this.registryTBoxUserName.Text = "";
            this.registryTBoxUserName.TrailingIcon = null;
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 548);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.registryTBoxName);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.registryTBoxPassword);
            this.Controls.Add(this.registryTBoxEmail);
            this.Controls.Add(this.registryTBoxUserName);
            this.Name = "FormRegister";
            this.Text = "PRIMA Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialLabel labelName;
        private MaterialSkin.Controls.MaterialTextBox registryTBoxName;
        private MaterialSkin.Controls.MaterialButton btnRegister;
        private MaterialSkin.Controls.MaterialLabel labelPassword;
        private MaterialSkin.Controls.MaterialLabel labelEmail;
        private MaterialSkin.Controls.MaterialLabel labelUserName;
        private MaterialSkin.Controls.MaterialTextBox registryTBoxPassword;
        private MaterialSkin.Controls.MaterialTextBox registryTBoxEmail;
        private MaterialSkin.Controls.MaterialTextBox registryTBoxUserName;
    }
}