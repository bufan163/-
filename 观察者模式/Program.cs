using System;

namespace 观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConcreteSubject subject = new ConcreteSubject();
            subject.registerObserver(new ConcreteObserverOne());
            subject.registerObserver(new ConcreteObserverTwo());
            subject.notifyObservers(new Message());
            Console.ReadKey();
        }
    }
}
