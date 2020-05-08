using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{

    //public interface RegObserver
    //{
    //    void handleRegSuccess(long userId);
    //}

    //public class RegPromotionObserver : RegObserver
    //{
    //    private PromotionService promotionService; // 依赖注入

    //    public void handleRegSuccess(long userId)
    //    {
    //        promotionService.issueNewUserExperienceCash(userId);
    //    }
    //}

    //public class RegNotificationObserver : RegObserver
    //{
    //    private NotificationService notificationService;


    //    public void handleRegSuccess(long userId)
    //    {
    //        notificationService.sendInboxMessage(userId, "Welcome...");
    //    }
    //}

    //public class UserController
    //{
    //    private UserService userService; // 依赖注入
    //    private List<RegObserver> regObservers = new ArrayList<>();

    //    // 一次性设置好，之后也不可能动态的修改
    //    public void setRegObservers(List<RegObserver> observers)
    //    {
    //        regObservers.addAll(observers);
    //    }
    //    public long register(String telephone, String password)
    //    {
    //        //省略输入参数的校验代码
    //        //省略userService.register()异常的try-catch代码
    //        long userId = userService.register(telephone, password);

    //        for (RegObserver observer : regObservers)
    //        {
    //            observer.handleRegSuccess(userId);
    //        }
    //        return userId;
    //    }
    //}
}
