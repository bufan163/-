using System;
using System.Collections.Generic;
using System.Text;

namespace 建造者模式
{

    public class ResourcePoolConfig
    {
        private String name;
        public int maxTotal;
        private int maxIdle;
        private int minIdle;
        public string Message  { get; set; }

        private ResourcePoolConfig(Builder builder)
        {
            this.name = builder.name;
            this.maxTotal = builder.maxTotal;
            this.maxIdle = builder.maxIdle;
            this.minIdle = builder.minIdle;
        }
        //...省略getter方法...

        //我们将Builder类设计成了ResourcePoolConfig的内部类。
        //我们也可以将Builder类设计成独立的非内部类ResourcePoolConfigBuilder。
        public  class Builder
        {
            private  const int DEFAULT_MAX_TOTAL = 8;
            private  const int DEFAULT_MAX_IDLE = 8;
            private  const int DEFAULT_MIN_IDLE = 0;

            public String name;
            public int maxTotal = DEFAULT_MAX_TOTAL;
            public int maxIdle = DEFAULT_MAX_IDLE;
            public int minIdle = DEFAULT_MIN_IDLE;

            public ResourcePoolConfig build()
            {

                // 校验逻辑放到这里来做，包括必填项校验、依赖关系校验、约束条件校验等
                return new ResourcePoolConfig(this);
            }

            public Builder setName(String name)
            {
              
                this.name = name;
                return this;
            }

            public Builder setMaxTotal(int maxTotal)
            {
              
                this.maxTotal = maxTotal;
                return this;
            }

            public Builder setMaxIdle(int maxIdle)
            {
               
                this.maxIdle = maxIdle;
                return this;
            }

            public Builder setMinIdle(int minIdle)
            {
                this.minIdle = minIdle;
                return this;
            }
        }
    }

 
}
