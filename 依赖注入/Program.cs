using System;

namespace 依赖注入
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用Notification
            MessageSender messageSender = new SmsSender();
            Notification notification = new Notification(messageSender);
            notification.sendMessage("cellphone", "message");
            MessageSender messageSender2 = new InboxSender();
            Notification notification2 = new Notification(messageSender2);
            notification2.sendMessage("cellphone", "message");
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public class Notification
    {
        private MessageSender messageSender;

        public Notification(MessageSender messageSender)
        {
            this.messageSender = messageSender;
        }

        public void sendMessage(String cellphone, String message)
        {
            this.messageSender.send(cellphone, message);
        }
    }

    public interface MessageSender
    {
        void send(String cellphone, String message);
    }

    // 短信发送类
    public class SmsSender : MessageSender
    {

        public void send(String cellphone, String message)
        {
            Console.WriteLine("send sms");
        }
    }

    // 站内信发送类
    public class InboxSender : MessageSender
    {

        public void send(String cellphone, String message)
        {
            Console.WriteLine("send inbox");
        }
    }


}
