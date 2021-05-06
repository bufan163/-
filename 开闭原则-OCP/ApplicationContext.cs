using System;
using System.Collections.Generic;
using System.Text;

namespace 开闭原则_OCP
{

    public class ApplicationContext
    {
        private AlertRule alertRule;
        private Notification notification;
        private AlertOCP alert;

        public void initializeBeans()
        {
            alertRule = new AlertRule(/*.省略参数.*/); //省略一些初始化代码
            notification = new Notification(/*.省略参数.*/); //省略一些初始化代码
            alert = new AlertOCP();
            alert.addAlertHandler(new TpsAlertHandler(alertRule, notification));
            alert.addAlertHandler(new ErrorAlertHandler(alertRule, notification));
            alert.addAlertHandler(new TimeoutAlertHandler(alertRule, notification));//新增逻辑
        }
        public AlertOCP getAlert() { return alert; }

        // 饿汉式单例
        private static ApplicationContext instance = new ApplicationContext();
        private ApplicationContext()
        {
            initializeBeans();
        }
        public static ApplicationContext getInstance()
        {
            return instance;
        }
    }
}
