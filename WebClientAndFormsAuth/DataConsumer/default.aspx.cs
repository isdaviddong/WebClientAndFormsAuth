using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataConsumer
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ret = "";
            //改用CookieAwareWebClient可順利驗證
            CookieAwareWebClient wc = new CookieAwareWebClient();
            //WebClient wc = new WebClient(); //傳統WebClient 無法驗證驗證
            wc.Encoding = Encoding.UTF8;
            //先登入(傳入帳號密碼)
            ret = wc.DownloadString("http://localhost:11771/service1.ashx?action=login&user=david&pwd=david");
            //呼叫API抓取資料
            ret=wc.DownloadString("http://localhost:11771/service1.ashx");
            Response.Write(ret);
        }
    }


}