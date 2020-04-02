namespace 实战
{
    internal class ClassPathXmlApplicationContext : ApplicationContext
    {
        private string v;

        public ClassPathXmlApplicationContext(string v)
        {
            this.v = v;
        }
    }
}