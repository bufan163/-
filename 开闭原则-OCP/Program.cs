using System;

namespace 开闭原则_OCP
{
    class Program
    {
        //开闭原则的英文全称是 Open Closed Principle，简写为 OCP。它的英文描述是：software entities(modules, classes, functions, etc.) should be open for extension , but closed for modification。我们把它翻译成中文就是：软件实体（模块、类、方法等）应该“对扩展开放、对修改关闭”。
        static void Main(string[] args)
        {
            try
            {
                ApiStatInfo apiStatInfo = new ApiStatInfo();
                apiStatInfo.setTimeoutCount(280);
                // ...省略设置apiStatInfo数据值的代码
                ApplicationContext.getInstance().getAlert().check(apiStatInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            Console.WriteLine("Hello World!");
        }
    }
}
