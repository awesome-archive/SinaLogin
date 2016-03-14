using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Threading;
using System.IO;
using System.Drawing;

namespace SinaLogin
{
    public class Weibo
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //存放登陆后的cookie
        public CookieContainer loginCookie = new CookieContainer();

        private const string PUBKEY = "EB2A38568661887FA180BDDB5CABD5F21C7BFD59C090CB2D245A87AC253062882729293E5506350508E7F9AA3BB77F4333231490F915F6D63C55FE2F08A49B353F444AD3993CACC02DB784ABBB8E42A9B1BBFFFB38BE18D78E87A0E41B9B8F73A928EE0CCEE1F6739884B9777E4FE9E88A1BBE495927AC4A799B3181D6442443";
        private const string RSAKV = "1330428213";

        private string su; //加密后的用户名
        private string servertime; //预登录参数1（时间戳）
        private string pcid; //预登录参数2
        private string nonce; //预登录参数3（随机数）
        private string showpin; //预登录参数4（是否需要验证码）


        public Weibo(string username, string password)
        {
            this.Username = username;
            this.Password = password;

            //Base64加密用户名
            Encoding myEncoding = Encoding.GetEncoding("utf-8");
            byte[] suByte = myEncoding.GetBytes(HttpUtility.UrlEncode(username));
            su = Convert.ToBase64String(suByte);
        }

        public Image StartLogin()
        {
            GetParameter();
            if(showpin == "1")
            {
                return GetPIN();
            }
            else
            {
                return null;
            }
        }

        public void EndLogin(string door)
        {
            loginCookie = GetCookie(door);
        }

        public string Get(string url)
        {
            return HttpHelper.Get(url, loginCookie);
        }

        private void GetParameter()
        {
            string url = "http://login.sina.com.cn/sso/prelogin.php?entry=weibo&callback=sinaSSOController.preloginCallBack&su="
                + su + "&rsakt=mod&checkpin=1&client=ssologin.js(v1.4.18)";
            string content = HttpHelper.Get(url);
            int pos;
            pos = content.IndexOf("servertime");
            servertime = content.Substring(pos + 12, 10);
            pos = content.IndexOf("pcid");
            pcid = content.Substring(pos + 7, 39);
            pos = content.IndexOf("nonce");
            nonce = content.Substring(pos + 8, 6);
            pos = content.IndexOf("showpin");
            showpin = content.Substring(pos + 7, 1);
        }

        private Image GetPIN()
        {
            string url = "http://login.sina.com.cn/cgi/pin.php?p=" + pcid;
            return HttpHelper.GetImage(url);
        }

        private string GetSP(string pwd, string servertime, string nonce, string pubkey)
        {
            StreamReader sr = new StreamReader("sinaSSOEncoder"); //从文本中读取修改过的JS
            string js = sr.ReadToEnd();
            //自定义function进行加密
            js += "function getpass(pwd,servicetime,nonce,rsaPubkey){var RSAKey=new sinaSSOEncoder.RSAKey();RSAKey.setPublic(rsaPubkey,'10001');var password=RSAKey.encrypt([servicetime,nonce].join('\\t')+'\\n'+pwd);return password;}";
            ScriptEngine se = new ScriptEngine(ScriptLanguage.JavaScript);
            object obj = se.Run("getpass", new object[] { pwd, servertime, nonce, pubkey }, js);
            return obj.ToString();
        }

        private CookieContainer GetCookie(string door)
        {
            CookieContainer myCookieContainer = new CookieContainer();
            string sp = GetSP(Password, servertime, nonce, PUBKEY);//得到加密后的密码
            string postData = "entry=weibo&gateway=1&from=&savestate=7&useticket=1&pagerefer=&vsnf=1&su=" + su
                            + "&service=miniblog&servertime=" + servertime
                            + "&nonce=" + nonce
                            + "&pwencode=rsa2&rsakv=" + RSAKV + "&sp=" + sp
                            + "&sr=1366*768&encoding=UTF-8&prelt=104&url=http%3A%2F%2Fweibo.com%2Fajaxlogin.php%3Fframelogin%3D1%26callback%3Dparent.sinaSSOController.feedBackUrlCallBack&returntype=META";
            if(showpin == "1" && door != null)
            {
                postData += "&pcid=" + pcid + "&door=" + door;
            }
            string content = HttpHelper.Post("http://login.sina.com.cn/sso/login.php?client=ssologin.js(v1.4.18)", postData);
            int pos = content.IndexOf("retcode=");
            string retcode = content.Substring(pos + 8, 1);
            if (retcode == "0")
            {
                pos = content.IndexOf("location.replace");
                string url = content.Substring(pos + 18, 285); //这里出错,浪费了我16小时检查出来,果然是太累了,妈蛋啊
                content = HttpHelper.Get(url, myCookieContainer);
                return myCookieContainer;
            }
            else
            {
                return null;
            }
        }
    }
}
