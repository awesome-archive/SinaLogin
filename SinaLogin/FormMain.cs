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
        WeiboLogin wb;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bgwLogin.RunWorkerAsync();
        }

        delegate void SetTextDelegate(Control ctrl, string text);
        /// <summary>
        /// 跨线程设置控件Text
        /// </summary>
        /// <param name="ctrl">待设置的控件</param>
        /// <param name="text">Text</param>
        public static void SetText(Control ctrl, string text)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new SetTextDelegate(SetText), ctrl, text);
            }
            else
            {
                ctrl.Text = text;
            }
        }

        delegate void SetEnabledDelegate(Control ctrl, bool enabled);
        /// <summary>
        /// 跨线程设置控件Enabled
        /// </summary>
        /// <param name="ctrl">待设置的控件</param>
        /// <param name="enabled">Enabled</param>
        public static void SetEnabled(Control ctrl, bool enabled)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new SetEnabledDelegate(SetEnabled), ctrl, enabled);
            }
            else
            {
                ctrl.Enabled = enabled;
            }
        }

        private void bgwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            SetText(btnStart, "开始登陆");
            SetEnabled(txtPIN, false);
            SetEnabled(btnStart, false);
            if (!needPIN)
            {
                wb = new WeiboLogin(txtUsername.Text, txtPassword.Text);
                Image pinImage = wb.Start();
                if (pinImage != null)
                {
                    picPIN.Image = pinImage;
                    needPIN = true;
                    SetText(labelState, "请填写验证码");
                    SetEnabled(txtPIN, true);
                    SetEnabled(btnStart, true);
                    SetText(btnStart, "继续登陆");
                }
                else
                {
                    string retcode = wb.End(null);
                    SetText(labelState, "登录结果：" + retcode);
                    SetText(btnStart, "重新登陆");
                    SetEnabled(btnStart, true);
                    string html = wb.Get("http://weibo.com/5237923337/");
                    SetText(txtRet, html);
                }
            }
            else
            {
                if (txtPIN.Text.Trim() != "")
                {
                    needPIN = false;
                    string retcode = wb.End(txtPIN.Text.Trim());
                    SetText(labelState, "登录结果：" + retcode);
                    SetText(btnStart, "重新登陆");
                    SetEnabled(btnStart, true);
                    string html = wb.Get("http://weibo.com/quanqiuyulequshi/");
                    SetText(txtRet, html);
                }
                else
                {
                    MessageBox.Show("请填写验证码");
                    SetEnabled(txtPIN, true);
                    SetEnabled(btnStart, true);
                }
            }
        }
    }
}
