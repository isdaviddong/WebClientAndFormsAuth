using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataProvider
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    public class Service1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //如果要登入
            if (context.Request.QueryString.AllKeys.Contains("action") && 
                context.Request.QueryString["action"]=="login" )
            {
                //驗證帳號密碼(測試，固定帳號密碼驗證)
                if (context.Request.QueryString.AllKeys.Contains("user") &&
                    context.Request.QueryString.AllKeys.Contains("pwd"))
                {
                    if (context.Request.QueryString["user"] == "david" &&
                        context.Request.QueryString["pwd"] == "david")
                    {
                        System.Web.Security.FormsAuthentication.SetAuthCookie(context.Request.QueryString["user"], false);
                        context.Response.Write("驗證成功");
                        return;
                    }
                    else
                    {
                        context.Response.Write("帳號密碼錯誤");
                        return;
                    }
                }
                else
                {
                    context.Response.Write("沒有提供帳號密碼");
                    return;
                }
            }

            //如果尚未驗證
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.Write("沒有權限");
                return;
            }
            else
            {
                //有驗證過，提供資料
              context.Response.Write(System.DateTime.Now.ToString());
              return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}