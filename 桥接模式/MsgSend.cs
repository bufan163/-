using System;
using System.Collections.Generic;
using System.Text;

namespace 桥接模式
{

    public interface MsgSender
    {
        void send(string message);
    }

    public class TelephoneMsgSender : MsgSender
    {
        private List<string> telephones;

        public TelephoneMsgSender(List<string> telephones)
        {
            this.telephones = telephones;
        }
        public void send(string message)
        {
            Console.WriteLine($"TelephoneMsgSender-Send:message{message}");
        }

    }

    public class EmailMsgSender : MsgSender
    {
        // 与TelephoneMsgSender代码结构类似，所以省略...
        public void send(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class WechatMsgSender : MsgSender
    {
        // 与TelephoneMsgSender代码结构类似，所以省略...
        public void send(string message)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Notification
    {
        protected MsgSender msgSender;

        public Notification(MsgSender msgSender)
        {
            this.msgSender = msgSender;
        }

        public abstract void notify(string message);
    }

    public class SevereNotification : Notification
    {
        public SevereNotification(MsgSender msgSender) : base(msgSender)
        {
            Console.WriteLine("对象初始化完成");
            //super(msgSender);
        }


        public override void notify(string message)
        {
            Console.WriteLine($"调用send方法,传入msg,notify:{message}");
            msgSender.send(message);
        }
    }

    public class UrgencyNotification : Notification
    {
        public UrgencyNotification(MsgSender msgSender) : base(msgSender)
        {

        }
        // 与SevereNotification代码结构类似，所以省略...
        public override void notify(string message)
        {
            throw new NotImplementedException();
        }
    }
    public class NormalNotification : Notification
    {
        public NormalNotification(MsgSender msgSender) : base(msgSender)
        {

        }
        // 与SevereNotification代码结构类似，所以省略...
        public override void notify(string message)
        {
            throw new NotImplementedException();
        }
    }
    public class TrivialNotification : Notification
    {
        public TrivialNotification(MsgSender msgSender) : base(msgSender)
        {

        }
        // 与SevereNotification代码结构类似，所以省略...
        public override void notify(string message)
        {
            throw new NotImplementedException();
        }
    }
}
