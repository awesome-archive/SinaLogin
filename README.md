# C#实现新浪微博模拟登陆
以前写的，现在重构了一下代码。

## 界面
![界面](https://raw.githubusercontent.com/huiyadanli/SinaLogin/master/img/screenshot0.png)

## 模拟登陆原理
1.输入用户名时，发送如下GET请求，返回一大堆登陆所需要的参数。其中`entry` `callback` `rsakt`  `client`参数都是固定不变的，`su`是经过Base64加密后的用户名，`checkpin` =1时，会返回`showpin`告诉你是否需要验证码，`_`很明显是时间戳，没有这个参数也可以正常得到返回信息。
> http://login.sina.com.cn/sso/prelogin.php?entry=weibo&callback=sinaSSOController.preloginCallBack&su=aHVpeWFkYW5saSU0MDEyNi5jb20%3D&rsakt=mod&checkpin=1&client=ssologin.js(v1.4.18)&_=1457524967315

返回信息如下，后面会用到 `servertime ` `nonce ` `pcid` `pubkey` `rsakv` 这几个参数，其中`pubkey` `rsakv`的值是固定的（1年多都没变）。
还有一个`showpin`上面已经说到了，告诉你是否需要验证码，此处的值为0是不需要的，频繁登陆时会需要验证码。
> sinaSSOController.preloginCallBack({"retcode":0,"servertime": 1457525116,
"pcid":"ja-69837828b9f065232d6ea4a3130fe2cdbd47","nonce":"7R4XFC",
"pubkey":"EB2A38568661887FA180BDDB5CABD5F21C7BFD59C090CB2D245A87AC253062
882729293E5506350508E7F9AA3BB77F4333231490F915F6D63C55FE2F08A49B353F
444AD3993CACC02DB784ABBB8E42A9B1BBFFFB38BE18D78E87A0E41B9B8F73A928EE0CCEE1F6
739884B9777E4FE9E88A1BBE495927AC4A799B3181D6442443",
"rsakv":"1330428213","is_openlock":0,"showpin":0,"exectime":12})

2.自己构造以下数据POST到http://login.sina.com.cn/sso/login.php?client=ssologin.js(v1.4.18)
其中`su`依旧是Base64加密后的用户名，`servertime ` `nonce ` `rsakv` 字段的值就是刚刚GET得到的值，`sp`是经过RSA2加密后的密码。其余的值都可以保持不变。
这里有一个登陆的难点就是RSA2加密，其实加密的方法就在ssologin.js中，直接用C#调用那段RSA2加密的js即可。详细方法：http://www.cnblogs.com/coding1016/archive/2013/03/25/2980310.html

！如果上面一步的返回值`showpin`=1，则需要GET  http://login.sina.com.cn/cgi/pin.php?p=`pcid` 来得到验证码图片（`pcid` 也来自上一步哟），然后在下面的POST数据中加上`pcid` `door` 两个字段，`door`的值就是验证码的值
> entry=weibo&gateway=1&from=&savestate=7&useticket=1&pagerefer=
&vsnf=1&su=aHVpeWFkYW5saSU0MDEyNi5jb20%3D&service=miniblog&servertime=1457525116
&nonce=7R4XFC&pwencode=rsa2&rsakv=1330428213&sp=`加密后的密码`
&sr=1745*982&encoding=UTF-8&prelt=78&url=http%3A%2F%2F
www.weibo.com%2Fajaxlogin.php%3Fframelogin%3D1%26
callback%3Dparent.sinaSSOController.feedBackUrlCallBack&returntype=META

POST以后会返回一个页面，location.replace 后面就是下一步要跳转的页面，其中还有个retcode参数告诉你登陆的结果（0-登陆成功，2070-验证码错误，4049-验证码为空，101密码错误）

跳转到那个页面，就可以得到登陆的cookie，模拟登陆完成。

## License
WTFPL