﻿using System;
using System.Collections.Generic;
using System.Text;

namespace 代理模式
{

    //public class UserController
    //{
    //    //...省略其他属性和方法...
    //    private MetricsCollector metricsCollector; // 依赖注入

    //    public UserVo login(String telephone, String password)
    //    {
    //        long startTimestamp = System.currentTimeMillis();

    //        // ... 省略login逻辑...

    //        long endTimeStamp = System.currentTimeMillis();
    //        long responseTime = endTimeStamp - startTimestamp;
    //        RequestInfo requestInfo = new RequestInfo("login", responseTime, startTimestamp);
    //        metricsCollector.recordRequest(requestInfo);

    //        //...返回UserVo数据...
    //    }

    //    public UserVo register(String telephone, String password)
    //    {
    //        long startTimestamp = System.currentTimeMillis();

    //        // ... 省略register逻辑...

    //        long endTimeStamp = System.currentTimeMillis();
    //        long responseTime = endTimeStamp - startTimestamp;
    //        RequestInfo requestInfo = new RequestInfo("register", responseTime, startTimestamp);
    //        metricsCollector.recordRequest(requestInfo);

    //        //...返回UserVo数据...
    //    }
    //}
}
