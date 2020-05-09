using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 观察者模式_实战
{

//    // 第一种实现方式，其他类代码不变，就没有再重复罗列
//    public class RegPromotionObserver : RegObserver
//    {
//  private PromotionService promotionService; // 依赖注入

  
//  public void handleRegSuccess(long userId)
//    {
//        Thread thread = new Thread(new Runnable() {
    
//      public void run()
//        {
//            promotionService.issueNewUserExperienceCash(userId);
//        }
//    });
//    thread.start();
//  }
//}

//// 第二种实现方式，其他类代码不变，就没有再重复罗列
//public class UserController
//{
//    private UserService userService; // 依赖注入
//    private List<RegObserver> regObservers = new ArrayList<>();
//    private Executor executor;

//    public UserController(Executor executor)
//    {
//        this.executor = executor;
//    }

//    public void setRegObservers(List<RegObserver> observers)
//    {
//        regObservers.addAll(observers);
//    }

//    public Long register(String telephone, String password)
//    {
//        //省略输入参数的校验代码
//        //省略userService.register()异常的try-catch代码
//        long userId = userService.register(telephone, password);

//        for (RegObserver observer : regObservers)
//        {
//            executor.execute(new Runnable() {
//        @Override
//        public void run()
//            {
//                observer.handleRegSuccess(userId);
//            }
//        });
//    }

//    return userId;
//  }
//}
}
