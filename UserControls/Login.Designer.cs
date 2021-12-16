namespace SellingManagermenWF.UserControls
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnWibu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new RJCodeAdvance.RJControls.RJButton();
            this.password = new RJCodeAdvance.RJControls.RJTextBox();
            this.userName = new RJCodeAdvance.RJControls.RJTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnWibu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnWibu);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.userName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 503);
            this.panel1.TabIndex = 0;
            // 
            // pnWibu
            // 
            this.pnWibu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnWibu.BackgroundImage")));
            this.pnWibu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnWibu.Controls.Add(this.label2);
            this.pnWibu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnWibu.Location = new System.Drawing.Point(0, 0);
            this.pnWibu.Name = "pnWibu";
            this.pnWibu.Size = new System.Drawing.Size(712, 503);
            this.pnWibu.TabIndex = 4;
            this.pnWibu.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 57);
            this.label2.TabIndex = 0;
            this.label2.Text = "Login successfully~";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLogin.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLogin.BorderColor = System.Drawing.Color.Red;
            this.btnLogin.BorderRadius = 6;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(524, 254);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(106, 32);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // password
            // 
            this.password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.password.BackColor = System.Drawing.SystemColors.Window;
            this.password.BorderColor = System.Drawing.Color.Gray;
            this.password.BorderFocusColor = System.Drawing.Color.HotPink;
            this.password.BorderRadius = 0;
            this.password.BorderSize = 1;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password.Location = new System.Drawing.Point(358, 216);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Multiline = false;
            this.password.Name = "password";
            this.password.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.password.PasswordChar = true;
            this.password.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.password.PlaceholderText = "Password";
            this.password.Size = new System.Drawing.Size(272, 31);
            this.password.TabIndex = 2;
            this.password.Texts = "";
            this.password.UnderlinedStyle = false;
            // 
            // userName
            // 
            this.userName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userName.BackColor = System.Drawing.SystemColors.Window;
            this.userName.BorderColor = System.Drawing.Color.Gray;
            this.userName.BorderFocusColor = System.Drawing.Color.HotPink;
            this.userName.BorderRadius = 0;
            this.userName.BorderSize = 1;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userName.Location = new System.Drawing.Point(358, 177);
            this.userName.Margin = new System.Windows.Forms.Padding(4);
            this.userName.Multiline = false;
            this.userName.Name = "userName";
            this.userName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.userName.PasswordChar = false;
            this.userName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.userName.PlaceholderText = "Username";
            this.userName.Size = new System.Drawing.Size(272, 31);
            this.userName.TabIndex = 1;
            this.userName.Texts = "";
            this.userName.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(358, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please login to continue";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 503);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnWibu.ResumeLayout(false);
            this.pnWibu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private RJCodeAdvance.RJControls.RJButton btnLogin;
        private RJCodeAdvance.RJControls.RJTextBox password;
        private RJCodeAdvance.RJControls.RJTextBox userName;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        internal Panel pnWibu;
    }
}