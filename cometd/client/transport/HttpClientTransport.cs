using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace Cometd.Client.Transport
{
    public abstract class HttpClientTransport : ClientTransport
    {
        private String url;
        private WebHeaderCollection headerCollection;
        private CookieCollection cookieCollection;

        protected HttpClientTransport(String name, IDictionary<String, Object> options)
            : base(name, options)
        {
            setHeaderCollection(new WebHeaderCollection());
        }

        protected String getURL()
        {
            return url;
        }

        public void setURL(String url)
        {
            this.url = url;
        }

        protected WebHeaderCollection getHeaderCollection()
        {
            return headerCollection;
        }

        public void setHeaderCollection(WebHeaderCollection headerCollection)
        {
            this.headerCollection = headerCollection;
        }

        protected internal void addHeaders(NameValueCollection headers)
        {
            WebHeaderCollection headerCollection = this.headerCollection;
            if (headerCollection != null)
                headerCollection.Add(headers);
        }

        protected CookieCollection getCookieCollection()
        {
            return cookieCollection;
        }

        public void setCookieCollection(CookieCollection cookieCollection)
        {
            this.cookieCollection = cookieCollection;
        }

        protected internal void addCookie(Cookie cookie)
        {
            CookieCollection cookieCollection = this.cookieCollection;
            if (cookieCollection != null)
                cookieCollection.Add(cookie);
        }
    }
}
