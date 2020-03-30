using System;
using System.Collections.Generic;
using System.Text;

namespace 工厂模式
{

    

    //因为工厂类只包含方法，不包含成员变量，完全可以复用，
    //不需要每次都创建新的工厂类对象，所以，简单工厂模式的第二种实现思路更加合适。
    public class RuleConfigParserFactoryMap
    { //工厂的工厂
        private static Dictionary<String, IRuleConfigParserFactory> cachedFactories = new Dictionary<string, IRuleConfigParserFactory>();

         static RuleConfigParserFactoryMap()
        {
            cachedFactories.Add("json", new JsonRuleConfigParserFactory());
            cachedFactories.Add("xml", new XmlRuleConfigParserFactory());
            cachedFactories.Add("yaml", new YamlRuleConfigParserFactory());
            cachedFactories.Add("properties", new PropertiesRuleConfigParserFactory());
        }

        public static IRuleConfigParserFactory getParserFactory(String type)
        {
            if (type == null || string.IsNullOrEmpty(type))
            {
                return null;
            }
            IRuleConfigParserFactory parserFactory = cachedFactories[type];
            return parserFactory;
        }
    }
}
