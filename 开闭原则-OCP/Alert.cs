using System;
using System.Collections.Generic;
using System.Text;

namespace 开闭原则_OCP
{

    public class Alert
    {
        private AlertRule rule;
        private Notification notification;

        public Alert(AlertRule rule, Notification notification)
        {
            this.rule = rule;
            this.notification = notification;
        }
        //如果需要新增一个逻辑就需要新增参数和再逻辑里面增加if
        public void check(String api, long requestCount, long errorCount, long durationOfSeconds)
        {
            long tps = requestCount / durationOfSeconds;
            if (tps > rule.getMatchedRule(api).getMaxTps())
            {
                notification.notify(NotificationEmergencyLevel.URGENCY, "...");
            }
            if (errorCount > rule.getMatchedRule(api).getMaxErrorCount())
            {
                notification.notify(NotificationEmergencyLevel.SEVERE, "...");
            }
        }
    }

    public class Notification
    {
        internal void notify(object uRGENCY, string v)
        {
            throw new NotImplementedException();
        }
    }

    public class AlertRule
    {
        internal AlertRule getMatchedRule(string api)
        {
            throw new NotImplementedException();
        }

        internal long getMaxErrorCount()
        {
            throw new NotImplementedException();
        }

        internal long getMaxTps()
        {
            throw new NotImplementedException();
        }
    }
    enum NotificationEmergencyLevel
    {
        SEVERE,
        URGENCY,
        NORMAL,
        TRIVIAL
    }
}
