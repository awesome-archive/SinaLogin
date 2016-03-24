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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPIN)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(76, 164);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始登录";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(76, 24);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(119, 21);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "miniodn9j@126.com";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(76, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(119, 21);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "mini123";
            // 
            // picPIN
            // 
            this.picPIN.Location = new System.Drawing.Point(76, 78);
            this.picPIN.Name = "picPIN";
            this.picPIN.Size = new System.Drawing.Size(100, 40);
            this.picPIN.TabIndex = 3;
            this.picPIN.TabStop = false;
            // 
            // txtPIN
            // 
            this.txtPIN.Enabled = false;
            this.txtPIN.Location = new System.Drawing.Point(76, 137);
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Size = new System.Drawing.Size(119, 21);
            this.txtPIN.TabIndex = 4;
            // 
            // txtRet
            // 
            this.txtRet.Location = new System.Drawing.Point(211, 24);
            this.txtRet.Multiline = true;
            this.txtRet.Name = "txtRet";
            this.txtRet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRet.Size = new System.Drawing.Size(422, 285);
            this.txtRet.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "账号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "验证码：";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(74, 235);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(71, 12);
            this.labelState.TabIndex = 9;
            this.labelState.Text = "等待登录...";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 325);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRet);
            this.Controls.Add(this.txtPIN);
            this.Controls.Add(this.picPIN);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnStart);
            this.Name = "FormMain";
            this.Text = "新浪微博模拟登陆Demo";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelState;
    }
}

