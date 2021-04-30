using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 接口和抽象类
{
    class AbstractClassDemo
    {
        private static Level minPermittedLevel;
        public void Send()
        {
            //对抽象类的使用：
            //Logger logger = new Logger("name", true, minPermittedLevel);//错误，抽象类不能被实例化
            Logger filelogger = new FileLogger("name", true, minPermittedLevel, "path");
            filelogger.log(minPermittedLevel,"message");
        }
       
    }

    // 抽象类
    public abstract class Logger
    {
        private String name;
        private bool enabled;
        private Level minPermittedLevel;

        public Logger(String name, bool enabled, Level minPermittedLevel)
        {
            this.name = name;
            this.enabled = enabled;
            this.minPermittedLevel = minPermittedLevel;
        }

        public void log(Level level, String message)
        {
            bool loggable = enabled && (minPermittedLevel.intValue() <= level.intValue());
            if (!loggable) return;
            doLog(level, message);
        }

        protected abstract void doLog(Level level, String message);
    }

    public class Level
    {
        internal int intValue()
        {
            throw new NotImplementedException();
        }
    }

    // 抽象类的子类：输出日志到文件
    public class FileLogger : Logger
    {
        private StreamWriter fileWriter;

        public FileLogger(String name, bool enabled,
          Level minPermittedLevel, String filepath) : base(name, enabled, minPermittedLevel)
        {
            this.fileWriter = new StreamWriter(filepath);
        }


        protected override void doLog(Level level, String mesage)
        {
            // 格式化level和message,输出到日志文件
            fileWriter.Write("message");
        }
    }
    // 抽象类的子类: 输出日志到消息中间件(比如kafka)
    public class MessageQueueLogger : Logger
    {
        private MessageQueueClient msgQueueClient;

        public MessageQueueLogger(String name, bool enabled,
          Level minPermittedLevel, MessageQueueClient msgQueueClient) : base(name, enabled, minPermittedLevel)
        {
            //消息组件通过注入的方式初始化
            this.msgQueueClient = msgQueueClient;
        }

        protected override void doLog(Level level, String mesage)
        {
            // 格式化level和message,输出到消息中间件
            msgQueueClient.send();
        }
    }

    public class MessageQueueClient
    {
        internal void send()
        {
            throw new NotImplementedException();
        }
    }
}
