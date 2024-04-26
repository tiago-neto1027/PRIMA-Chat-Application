namespace PRIMA
{
    partial class FormLogin
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
            this.btnRegistry = new MaterialSkin.Controls.MaterialButton();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.labelPassword = new MaterialSkin.Controls.MaterialLabel();
            this.labelUserName = new MaterialSkin.Controls.MaterialLabel();
            this.loginTBoxPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.loginTBoxUser = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // btnRegistry
            // 
            this.btnRegistry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegistry.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRegistry.Depth = 0;
            this.btnRegistry.HighEmphasis = true;
            this.btnRegistry.Icon = null;
            this.btnRegistry.Location = new System.Drawing.Point(507, 305);
            this.btnRegistry.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRegistry.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegistry.Name = "btnRegistry";
            this.btnRegistry.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRegistry.Size = new System.Drawing.Size(89, 36);
            this.btnRegistry.TabIndex = 9;
            this.btnRegistry.Text = "Register";
            this.btnRegistry.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRegistry.UseAccentColor = false;
            this.btnRegistry.UseVisualStyleBackColor = true;
            this.btnRegistry.Click += new System.EventHandler(this.btnRegistry_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(205, 305);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogin.Size = new System.Drawing.Size(64, 36);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Depth = 0;
            this.labelPassword.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelPassword.Location = new System.Drawing.Point(203, 207);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(75, 19);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Password:";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Depth = 0;
            this.labelUserName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelUserName.Location = new System.Drawing.Point(203, 110);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(82, 19);
            this.labelUserName.TabIndex = 8;
            this.labelUserName.Text = "User Name:";
            // 
            // loginTBoxPassword
            // 
            this.loginTBoxPassword.AnimateReadOnly = false;
            this.loginTBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginTBoxPassword.Depth = 0;
            this.loginTBoxPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginTBoxPassword.LeadingIcon = null;
            this.loginTBoxPassword.Location = new System.Drawing.Point(205, 232);
            this.loginTBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.loginTBoxPassword.MaxLength = 50;
            this.loginTBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.loginTBoxPassword.Multiline = false;
            this.loginTBoxPassword.Name = "loginTBoxPassword";
            this.loginTBoxPassword.Password = true;
            this.loginTBoxPassword.Size = new System.Drawing.Size(392, 50);
            this.loginTBoxPassword.TabIndex = 7;
            this.loginTBoxPassword.Text = "";
            this.loginTBoxPassword.TrailingIcon = null;
            this.loginTBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginTBoxPassword_KeyDown);
            // 
            // loginTBoxUser
            // 
            this.loginTBoxUser.AnimateReadOnly = false;
            this.loginTBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginTBoxUser.Depth = 0;
            this.loginTBoxUser.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginTBoxUser.LeadingIcon = null;
            this.loginTBoxUser.Location = new System.Drawing.Point(205, 135);
            this.loginTBoxUser.Margin = new System.Windows.Forms.Padding(2);
            this.loginTBoxUser.MaxLength = 50;
            this.loginTBoxUser.MouseState = MaterialSkin.MouseState.OUT;
            this.loginTBoxUser.Multiline = false;
            this.loginTBoxUser.Name = "loginTBoxUser";
            this.loginTBoxUser.Size = new System.Drawing.Size(392, 50);
            this.loginTBoxUser.TabIndex = 6;
            this.loginTBoxUser.Text = "";
            this.loginTBoxUser.TrailingIcon = null;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegistry);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.loginTBoxPassword);
            this.Controls.Add(this.loginTBoxUser);
            this.Name = "FormLogin";
            this.Text = "PRIMA Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnRegistry;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialLabel labelPassword;
        private MaterialSkin.Controls.MaterialLabel labelUserName;
        private MaterialSkin.Controls.MaterialTextBox loginTBoxPassword;
        private MaterialSkin.Controls.MaterialTextBox loginTBoxUser;
    }
}

