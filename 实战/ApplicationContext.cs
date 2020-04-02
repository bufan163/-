using System;
using System.Collections;
using System.Collections.Generic;

namespace 实战
{

    public interface ApplicationContext
    {
        object GetBean(string beanId);
    }
    /// <summary>
    /// 负责组装beansFactory和beanConfigParser
    /// </summary>
    public class ClassPathXmlApplicationContext : ApplicationContext
    {
        private BeansFactory beansFactory;
        private BeanConfigParser beanConfigParser;

        public ClassPathXmlApplicationContext(String configLocation)
        {
            this.beansFactory = new BeansFactory();
            this.beanConfigParser = new XmlBeanConfigParser();
            loadBeanDefinitions(configLocation);
        }

        public void loadBeanDefinitions(String configLocation)
        {
            List<BeanDefinition> beanDefinitions = beanConfigParser.parse(new BeanDefinition { });

            beansFactory.addBeanDefinitions(beanDefinitions);
        }

        public object GetBean(string beanId)
        {
            return beansFactory.getBean(beanId);
        }
    }

    internal class BeanDefinition
    {
        private String id;
        private String className;
        private List<ConstructorArg> constructorArgs;
        private Scope scope = Scope.SINGLETON;
        private bool lazyInit = false;
        // 省略必要的getter/setter/constructors  
        public bool isSingleton() { return scope.Equals(Scope.SINGLETON); }
        public enum Scope { SINGLETON, PROTOTYPE }
        public class ConstructorArg
        {
            private bool isRef;
            private Object arg;
            // 省略必要的getter/setter/constructors  
        }
    }
    internal interface BeanConfigParser
    {
        internal List<BeanDefinition> parse(BeanDefinition beanDefinition)
        {
            throw new NotImplementedException();
        }
        List<BeanDefinition> parse(InputStream inputStream);
        List<BeanDefinition> parse(String configContent);
    }
    internal class XmlBeanConfigParser : BeanConfigParser
    {
        public List<BeanDefinition> parse(InputStream inputStream)
        {
            throw new NotImplementedException();
        }

        public List<BeanDefinition> parse(string configContent)
        {
            throw new NotImplementedException();
        }
    }




    public class BeansFactory
    {

        private Dictionary<String, Object> singletonObjects = new Dictionary<string, object>();
        private Dictionary<String, BeanDefinition> beanDefinitions = new Dictionary<string, object>();

        public void addBeanDefinitions(List<BeanDefinition> beanDefinitionList)
        {
            foreach (BeanDefinition beanDefinition in beanDefinitionList)
            {
                this.beanDefinitions.putIfAbsent(beanDefinition.getId(), beanDefinition);
            }

            foreach (BeanDefinition beanDefinition in beanDefinitionList)
            {
                if (beanDefinition.isLazyInit() == false && beanDefinition.isSingleton())
                {
                    createBean(beanDefinition);
                }
            }
        }

        public Object getBean(String beanId)
        {
            BeanDefinition beanDefinition = beanDefinitions.get(beanId);
            if (beanDefinition == null)
            {
                throw new Exception("Bean is not defined: " + beanId);
            }
            return createBean(beanDefinition);
        }


        protected Object createBean(BeanDefinition beanDefinition)
        {
            if (beanDefinition.isSingleton() && singletonObjects.contains(beanDefinition.getId()))
            {
                return singletonObjects.get(beanDefinition.getId());
            }

            Object bean = null;
            try
            {
                Type beanClass = Class.forName(beanDefinition.getClassName());
                List<BeanDefinition.ConstructorArg> args = beanDefinition.getConstructorArgs();
                if (args.isEmpty())
                {
                    bean = beanClass.newInstance();
                }
                else
                {
                    Class[] argClasses = new Class[args.size()];
                    Object[] argObjects = new Object[args.size()];
                    for (int i = 0; i < args.size(); ++i)
                    {
                        BeanDefinition.ConstructorArg arg = args.get(i);
                        if (!arg.getIsRef())
                        {
                            argClasses[i] = arg.getType();
                            argObjects[i] = arg.getArg();
                        }
                        else
                        {
                            BeanDefinition refBeanDefinition = beanDefinitions.get(arg.getArg());
                            if (refBeanDefinition == null)
                            {
                                throw new NoSuchBeanDefinitionException("Bean is not defined: " + arg.getArg());
                            }
                            argClasses[i] = Class.forName(refBeanDefinition.getClassName());
                            argObjects[i] = createBean(refBeanDefinition);
                        }
                    }
                    bean = beanClass.getConstructor(argClasses).newInstance(argObjects);
                }
            }
            catch (ClassNotFoundException | IllegalAccessException
                  | InstantiationException | NoSuchMethodException | InvocationTargetException e) {
                throw new BeanCreationFailureException("", e);
            }

            if (bean != null && beanDefinition.isSingleton())
            {
                singletonObjects.putIfAbsent(beanDefinition.getId(), bean);
                return singletonObjects.get(beanDefinition.getId());
            }
            return bean;
            }
        }
    }