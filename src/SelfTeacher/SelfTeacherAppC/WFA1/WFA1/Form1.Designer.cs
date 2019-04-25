namespace WFA1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label l_login;
            System.Windows.Forms.Label l_password;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.b_reset = new System.Windows.Forms.Button();
            this.b_createaccount = new System.Windows.Forms.Button();
            this.b_authwithvk = new System.Windows.Forms.Button();
            this.b_authwithgoogle = new System.Windows.Forms.Button();
            this.p_gushin = new System.Windows.Forms.PictureBox();
            l_login = new System.Windows.Forms.Label();
            l_password = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p_gushin)).BeginInit();
            this.SuspendLayout();
            // 
            // l_login
            // 
            l_login.AutoSize = true;
            l_login.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            l_login.Location = new System.Drawing.Point(30, 82);
            l_login.Name = "l_login";
            l_login.Size = new System.Drawing.Size(32, 13);
            l_login.TabIndex = 0;
            l_login.Text = "login:";
            l_login.Click += new System.EventHandler(this.l_login_Click);
            // 
            // l_password
            // 
            l_password.AutoSize = true;
            l_password.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            l_password.Location = new System.Drawing.Point(7, 118);
            l_password.Name = "l_password";
            l_password.Size = new System.Drawing.Size(55, 13);
            l_password.TabIndex = 3;
            l_password.Text = "password:";
            l_password.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(68, 79);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(120, 20);
            this.tb_login.TabIndex = 1;
            this.tb_login.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tb_password
            // 
            this.tb_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_password.Location = new System.Drawing.Point(68, 115);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(120, 20);
            this.tb_password.TabIndex = 2;
            this.tb_password.UseSystemPasswordChar = true;
            this.tb_password.TextChanged += new System.EventHandler(this.tb_password_TextChanged);
            // 
            // b_reset
            // 
            this.b_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_reset.Enabled = false;
            this.b_reset.Location = new System.Drawing.Point(194, 115);
            this.b_reset.Name = "b_reset";
            this.b_reset.Size = new System.Drawing.Size(33, 20);
            this.b_reset.TabIndex = 4;
            this.b_reset.Text = "R";
            this.b_reset.UseVisualStyleBackColor = true;
            this.b_reset.Click += new System.EventHandler(this.b_reset_Click);
            // 
            // b_createaccount
            // 
            this.b_createaccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_createaccount.Location = new System.Drawing.Point(68, 141);
            this.b_createaccount.Name = "b_createaccount";
            this.b_createaccount.Size = new System.Drawing.Size(120, 20);
            this.b_createaccount.TabIndex = 5;
            this.b_createaccount.Text = "Create Account";
            this.b_createaccount.UseVisualStyleBackColor = true;
            this.b_createaccount.Click += new System.EventHandler(this.b_createaccount_Click);
            // 
            // b_authwithvk
            // 
            this.b_authwithvk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_authwithvk.Location = new System.Drawing.Point(68, 169);
            this.b_authwithvk.Name = "b_authwithvk";
            this.b_authwithvk.Size = new System.Drawing.Size(120, 25);
            this.b_authwithvk.TabIndex = 6;
            this.b_authwithvk.Text = "Auth with VK";
            this.b_authwithvk.UseVisualStyleBackColor = true;
            // 
            // b_authwithgoogle
            // 
            this.b_authwithgoogle.BackColor = System.Drawing.Color.Transparent;
            this.b_authwithgoogle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_authwithgoogle.Location = new System.Drawing.Point(68, 200);
            this.b_authwithgoogle.Name = "b_authwithgoogle";
            this.b_authwithgoogle.Size = new System.Drawing.Size(120, 25);
            this.b_authwithgoogle.TabIndex = 7;
            this.b_authwithgoogle.Text = "Auth with Google";
            this.b_authwithgoogle.UseVisualStyleBackColor = false;
            // 
            // p_gushin
            // 
            this.p_gushin.BackColor = System.Drawing.Color.Transparent;
            this.p_gushin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_gushin.Cursor = System.Windows.Forms.Cursors.No;
            this.p_gushin.Image = ((System.Drawing.Image)(resources.GetObject("p_gushin.Image")));
            this.p_gushin.InitialImage = ((System.Drawing.Image)(resources.GetObject("p_gushin.InitialImage")));
            this.p_gushin.Location = new System.Drawing.Point(68, 12);
            this.p_gushin.Name = "p_gushin";
            this.p_gushin.Size = new System.Drawing.Size(120, 50);
            this.p_gushin.TabIndex = 8;
            this.p_gushin.TabStop = false;
            this.p_gushin.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.Controls.Add(this.p_gushin);
            this.Controls.Add(this.b_authwithgoogle);
            this.Controls.Add(this.b_authwithvk);
            this.Controls.Add(this.b_createaccount);
            this.Controls.Add(this.b_reset);
            this.Controls.Add(l_password);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_login);
            this.Controls.Add(l_login);
            this.Cursor = System.Windows.Forms.Cursors.Help;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LOGIN PAGE";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_gushin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Button b_reset;
        private System.Windows.Forms.Button b_createaccount;
        private System.Windows.Forms.Button b_authwithvk;
        private System.Windows.Forms.Button b_authwithgoogle;
        private System.Windows.Forms.PictureBox p_gushin;

    }
}

