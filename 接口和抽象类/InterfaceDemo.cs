using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace 接口和抽象类
{
    interface InterfaceDemo
    {
    }

    // 接口
    public interface Filter
    {
        void doFilter(RpcRequest req);
    }

  

    // 接口实现类：鉴权过滤器
    public class AuthencationFilter : Filter
    {

        public void doFilter(RpcRequest req)
        {
            //...鉴权逻辑..
        }
    }
    // 接口实现类：限流过滤器
    public class RateLimitFilter : Filter
    {

        public void doFilter(RpcRequest req)
        {
            //...限流逻辑...
        }
    }
    // 过滤器使用Demo
    public class Application
    {
        // filters.add(new AuthencationFilter());
        // filters.add(new RateLimitFilter());
        private List<Filter> filters = new List<Filter> ();

        public void handleRpcRequest(RpcRequest req)
        {
            try
            {
                foreach (Filter filter in filters)
                {
                    filter.doFilter(req);
                }
            }
            catch (Exception e)
            {
                // ...处理过滤结果...
            }
            // ...省略其他处理逻辑...
        }
    }
    public class RpcRequest
    {
    }
}
