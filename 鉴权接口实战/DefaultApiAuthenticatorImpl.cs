using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace 鉴权接口实战
{
    class DefaultApiAuthenticatorImpl : ApiAuthenticator
    {
        private CredentialStorage credentialStorage;
        public DefaultApiAuthenticatorImpl()
        {
            this.credentialStorage = new MysqlCredentialStorage();
        }
        public DefaultApiAuthenticatorImpl(CredentialStorage credentialStorage)
        {
            this.credentialStorage = credentialStorage;
        }

        public void auth(string url)
        {
            ApiRequest apiRequest = ApiRequest.buildFromUrl(url);
            auth(apiRequest);
        }

        public void auth(ApiRequest apiRequest)
        {
            String appId = apiRequest.getAppId();
            String token = apiRequest.getToken();
            long timestamp = apiRequest.getTimestamp();
            String originalUrl = apiRequest.getOriginalUrl();
            AuthToken clientAuthToken = new AuthToken(token, timestamp);
            if (clientAuthToken.isExpired())
            {
                throw new Exception("Token is expired.");
            }
            String password = credentialStorage.getPasswordByAppId(appId);
            AuthToken serverAuthToken = AuthToken.generate(originalUrl, appId, password, timestamp);
            if (!serverAuthToken.Equals(clientAuthToken))
            {
                throw new Exception("Token verfication failed.");
            }
        }
    }
}
