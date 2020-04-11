using System;
using System.Collections.Generic;
using System.Text;

namespace 代理模式
{
    public class UserVo
    {

    }
    public class RequestInfo
    {
        public RequestInfo(string method, long responsTime, long startTimestamp)
        {
            Console.WriteLine($"method:{method},responsTime:{responsTime},startTimestamp:{startTimestamp}");
        }
    }
    public class MetricsCollector
    {
        public void recordRequest(RequestInfo requestInfo)
        {

        }
    }
    public interface IUserController
    {
        public abstract UserVo login(string telephone, string password);
        public abstract UserVo register(string telephone, string password);
    }

    public class UserController : IUserController
    {
        //...省略其他属性和方法...

        public UserVo login(string telephone, string password)
        {
            Console.WriteLine("UserController-login");
            //...省略login逻辑...
            //...返回UserVo数据...
            return new UserVo { };
        }


        public UserVo register(string telephone, string password)
        {
            //...省略register逻辑...
            //...返回UserVo数据...
            return new UserVo { };
        }
    }

    public class UserControllerProxy : IUserController
    {
        private MetricsCollector metricsCollector;
        private UserController userController;

        public UserControllerProxy(UserController userController)
        {
            this.userController = userController;
            this.metricsCollector = new MetricsCollector();
        }


        public UserVo login(string telephone, string password)
        {
            Console.WriteLine("UserControllerProxy-login");
            long startTimestamp = DateTime.Now.Millisecond;
            // 委托
            UserVo userVo = userController.login(telephone, password);
            long endTimeStamp = DateTime.Now.Millisecond;
            long responseTime = endTimeStamp - startTimestamp;
            RequestInfo requestInfo = new RequestInfo("login", responseTime, startTimestamp);
            metricsCollector.recordRequest(requestInfo);

            return userVo;
        }


        public UserVo register(string telephone, string password)
        {
            long startTimestamp = DateTime.Now.Millisecond;
            UserVo userVo = userController.register(telephone, password);
            long endTimeStamp = DateTime.Now.Millisecond;
            long responseTime = endTimeStamp - startTimestamp;
            RequestInfo requestInfo = new RequestInfo("register", responseTime, startTimestamp);
            metricsCollector.recordRequest(requestInfo);
            return userVo;
        }

    }


}

