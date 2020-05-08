using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者模式
{

    public interface Subject
    {
        void registerObserver(Observer observer);
        void removeObserver(Observer observer);
        void notifyObservers(Message message);
    }

    public interface Observer
    {
        void update(Message message);
    }

    public class ConcreteSubject : Subject
    {
        private List<Observer> observers = new List<Observer>();


        public void registerObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(Observer observer)
        {
            observers.Remove(observer);
        }
        public void notifyObservers(Message message)
        {
            foreach (Observer observer in observers)
            {
                observer.update(message);
            }
        }
    }

    public class ConcreteObserverOne : Observer
    {

        public void update(Message message)
        {
            //TODO: 获取消息通知，执行自己的逻辑...
            Console.WriteLine($"ConcreteObserverOne is notified.{message.currentTime}");
        }
    }

    public class ConcreteObserverTwo : Observer
    {

        public void update(Message message)
        {
            //TODO: 获取消息通知，执行自己的逻辑...
            Console.WriteLine($"ConcreteObserverTwo is notified.{message.currentTime}");
        }
    }
    public class Message
    {
        //消息针对所有观察者都是一致的
        public DateTime currentTime { get; set; } = DateTime.Now;
    }

}
