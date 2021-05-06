using System;
using System.Collections.Generic;
using System.Text;

namespace 开闭原则_OCP
{

    public class AlertOCP
    {
        private List<AlertHandler> alertHandlers = new List<AlertHandler>();

        public void addAlertHandler(AlertHandler alertHandler)
        {
            this.alertHandlers.Add(alertHandler);
        }

        public void check(ApiStatInfo apiStatInfo)
        {
            foreach (AlertHandler handler in alertHandlers)
            {
                //执行检查逻辑
                handler.check(apiStatInfo);
            }
        }
    }
    /*
     * Alert 要操作的参数通过ApiStatInfo这个对象传入
     * ApiStatInfo 这个类会随着业务逻辑的变化不断膨胀，相当于ApiStatInfo 这个类就是一个开发的类
     */
    public class ApiStatInfo
    {//省略constructor/getter/setter方法
        private String api;
        private long requestCount;
        private long errorCount;
        private long durationOfSeconds;
        private long timeoutCount; // 改动一：添加新字段
        internal int getRequestCount()
        {
            throw new NotImplementedException();
        }

        internal int getDurationOfSeconds()
        {
            throw new NotImplementedException();
        }

        internal string getApi()
        {
            throw new NotImplementedException();
        }

        internal long getErrorCount()
        {
            throw new NotImplementedException();
        }

        internal void setTimeoutCount(int time)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class AlertHandler
    {
        protected AlertRule rule;
        protected Notification notification;
        public AlertHandler(AlertRule rule, Notification notification)
        {
            this.rule = rule;
            this.notification = notification;
        }
        public abstract void check(ApiStatInfo apiStatInfo);
    }

    public class TpsAlertHandler : AlertHandler
    {
        public TpsAlertHandler(AlertRule rule, Notification notification) : base(rule, notification)
        {

        }
        public override void check(ApiStatInfo apiStatInfo)
        {
            long tps = apiStatInfo.getRequestCount() / apiStatInfo.getDurationOfSeconds();
            if (tps > rule.getMatchedRule(apiStatInfo.getApi()).getMaxTps())
            {
                notification.notify(NotificationEmergencyLevel.URGENCY, "...");
            }
        }
    }

    public class ErrorAlertHandler : AlertHandler
    {
        public ErrorAlertHandler(AlertRule rule, Notification notification) : base(rule, notification)
        {

        }
        public override void check(ApiStatInfo apiStatInfo)
        {
            if (apiStatInfo.getErrorCount() > rule.getMatchedRule(apiStatInfo.getApi()).getMaxErrorCount())
            {
                notification.notify(NotificationEmergencyLevel.SEVERE, "...");
            }
        }
    }
    public class TimeoutAlertHandler : AlertHandler
    {
        public TimeoutAlertHandler(AlertRule rule, Notification notification) : base(rule, notification)
        {

        }
        public override void check(ApiStatInfo apiStatInfo)
        {
           //新增逻辑
        }
    }
}
