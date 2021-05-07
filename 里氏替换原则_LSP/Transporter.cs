using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace 里氏替换原则_LSP
{

    public class Transporter
    {
        private HttpClient httpClient;

        public Transporter(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public virtual HttpResponseMessage sendRequest(HttpRequestMessage request)
        {
            // ...use httpClient to send request
            return new HttpResponseMessage();
        }
    }

    public class SecurityTransporter : Transporter
    {
        private String appId;
        private String appToken;

        public SecurityTransporter(HttpClient httpClient, String appId, String appToken) : base(httpClient)
        {
            this.appId = appId;
            this.appToken = appToken;
        }


        public override HttpResponseMessage sendRequest(HttpRequestMessage request)
        {
            if (!string.IsNullOrEmpty(appId) && !string.IsNullOrEmpty(appToken))
            {
                //处理appid 和 apptoken
                //request.addPayload("app-id", appId);
                //request.addPayload("app-token", appToken);
            }
            return base.sendRequest(request);
        }
    }

    public class Demo
    {
        public void demoFunction(Transporter transporter)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            //...省略设置request中数据值的代码...
            HttpResponseMessage response = transporter.sendRequest(request);
            //...省略其他逻辑...
        }
    }
}
