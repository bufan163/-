using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace 鉴权接口实战
{
    interface ApiAuthenticator
    {
        void auth(string url);
        void auth(ApiRequest apiRequest);
    }
}
