namespace SinaLogin
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picPIN = new System.Windows.Forms.PictureBox();
            this.txtPIN = new System.Windows.Forms.TextBox();
            this.txtRet = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPIN)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(26, 188);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始登陆";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(26, 21);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(119, 21);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "miniodn9j@126.com";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(26, 48);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(119, 21);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "mini123";
            // 
            // picPIN
            // 
            this.picPIN.Location = new System.Drawing.Point(26, 88);
            this.picPIN.Name = "picPIN";
            this.picPIN.Size = new System.Drawing.Size(100, 40);
            this.picPIN.TabIndex = 3;
            this.picPIN.TabStop = false;
            // 
            // txtPIN
            // 
            this.txtPIN.Location = new System.Drawing.Point(26, 134);
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Size = new System.Drawing.Size(100, 21);
            this.txtPIN.TabIndex = 4;
            // 
            // txtRet
            // 
            this.txtRet.Location = new System.Drawing.Point(151, 21);
            this.txtRet.Multiline = true;
            this.txtRet.Name = "txtRet";
            this.txtRet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRet.Size = new System.Drawing.Size(422, 285);
            this.txtRet.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 318);
            this.Controls.Add(this.txtRet);
            this.Controls.Add(this.txtPIN);
            this.Controls.Add(this.picPIN);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnStart);
            this.Name = "FormMain";
            this.Text = "新浪微博模拟登陆";
            ((System.ComponentModel.ISupportInitialize)(this.picPIN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox picPIN;
        private System.Windows.Forms.TextBox txtPIN;
        private System.Windows.Forms.TextBox txtRet;
    }
}

