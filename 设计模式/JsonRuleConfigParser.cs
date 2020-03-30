namespace 工厂模式
{
    internal class JsonRuleConfigParser : IRuleConfigParser
    {
        public RuleConfig parse(string configText)
        {
            System.Console.WriteLine("Load JsonRule");
            return new RuleConfig { Name = configText };
        }
    }
}