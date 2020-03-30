using System;
using System.Collections.Generic;
using System.Text;

namespace 工厂模式
{

    public class RuleConfigParserFactory
    {
        private static Dictionary<string, IRuleConfigParser> cachedParsers = new Dictionary<string, IRuleConfigParser>();

        static RuleConfigParserFactory()
        {

            cachedParsers.Add("json", new JsonRuleConfigParser());
            cachedParsers.Add("xml", new XmlRuleConfigParser());
            cachedParsers.Add("yaml", new YamlRuleConfigParser());
            cachedParsers.Add("properties", new PropertiesRuleConfigParser());
        }

        public static IRuleConfigParser createParser(String configFormat)
        {
            if (configFormat == null || string.IsNullOrEmpty(configFormat))
            {
                return null;//返回null还是IllegalArgumentException全凭你自己说了算
            }
            IRuleConfigParser parser = cachedParsers[configFormat];
            return parser;
        }
    }
}
