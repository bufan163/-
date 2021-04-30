using System;
using System.Collections.Generic;
using System.Text;

namespace 鉴权接口实战
{
    public class AuthToken
    {
        private static long DEFAULT_EXPRIRED_TIME_INTERVAL = 1 * 60 * 1000;
        private string token;
        private long createTime;
        private long expiredTimeInterval = DEFAULT_EXPRIRED_TIME_INTERVAL;

        public AuthToken(string token,long createTime)
        {
            this.token = token;
            this.createTime = createTime;
        }
        public AuthToken(string token, long createTime,long expiredTimeInterval)
        {
            this.token = token;
            this.createTime = createTime;
            this.expiredTimeInterval = expiredTimeInterval;
        }

        internal bool isExpired()
        {
            throw new NotImplementedException();
        }

        internal static AuthToken generate(string originalUrl, string appId, string password, long timestamp)
        {
            throw new NotImplementedException();
        }
    }
}
