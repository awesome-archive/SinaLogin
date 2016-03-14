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
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Weibo wb = new Weibo(txtUsername.Text, txtPassword.Text);
            Image pinImage = wb.StartLogin();
            if (pinImage != null)
            {
                picPIN.Image = pinImage;
            }
            else
            {
                wb.EndLogin(null);
                txtRet.Text = wb.Get("http://weibo.com/guide/welcome");
            }
        }
    }
}
