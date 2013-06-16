using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DataConsumer
{
    public class CookieAwareWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; set; }
        public CookieAwareWebClient()
            : this(new CookieContainer())
        {
        }
        public CookieAwareWebClient(CookieContainer c)
        {
            this.CookieContainer = c;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);

            var castRequest = request as HttpWebRequest;
            if (castRequest != null)
            {
                castRequest.CookieContainer = this.CookieContainer;
            }
            return request;
        }
    }
}