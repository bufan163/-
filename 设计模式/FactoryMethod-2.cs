using System;
using System.Collections.Generic;
using System.Text;

namespace 工厂模式
{

    public interface IRuleConfigParserFactory
    {
        IRuleConfigParser createParser();
        //如果在这里创建不同类型对象就是抽象工厂
    }

    public interface IRuleConfigParser
    {
        RuleConfig parse(string configText);
    }

    public class JsonRuleConfigParserFactory : IRuleConfigParserFactory
    {

        public IRuleConfigParser createParser()
        {
            return new JsonRuleConfigParser();
        }
    }

    public class XmlRuleConfigParserFactory : IRuleConfigParserFactory
    {

        public IRuleConfigParser createParser()
        {
            //工厂方法中可以创建复杂对象
            return new XmlRuleConfigParser();
        }
    }

    public class YamlRuleConfigParserFactory : IRuleConfigParserFactory
    {

        public IRuleConfigParser createParser()
        {
            return new YamlRuleConfigParser();
        }
    }

    public class PropertiesRuleConfigParserFactory : IRuleConfigParserFactory
    {

        public IRuleConfigParser createParser()
        {
            return new PropertiesRuleConfigParser();
        }
    }
}
