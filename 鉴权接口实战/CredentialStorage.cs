using System;
using System.Collections.Generic;
using System.Text;

namespace 鉴权接口实战
{
    interface CredentialStorage
    {
        string getPasswordByAppId(string appId);
    }
}
