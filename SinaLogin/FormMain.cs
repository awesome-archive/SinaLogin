using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SinaLogin
{
    public partial class FormMain : Form
    {
        //下一步
        //把登录过程放在后台线程中
        bool needPIN = false;
        Weibo wb;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtPIN.Enabled = false;
            if (!needPIN)
            {
                wb = new Weibo(txtUsername.Text, txtPassword.Text);
                Image pinImage = wb.StartLogin();
                if (pinImage != null)
                {
                    picPIN.Image = pinImage;
                    needPIN = true;
                    labelState.Text = "请填写验证码";
                    txtPIN.Enabled = true;
                }
                else
                {
                    wb.EndLogin(null);
                    txtRet.Text = wb.Get("http://weibo.com/");
                    labelState.Text = "登录成功！";
                }
            }
            else
            {
                wb.EndLogin(txtPIN.Text);
                txtRet.Text = wb.Get("http://weibo.com/");
                labelState.Text = "登录成功！";
            }
        }
    }
}
