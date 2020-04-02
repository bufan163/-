using System;
using System.Collections.Generic;
using System.Text;

namespace 建造者模式
{
    public  class ConstructorArg
    {
        private bool isRef;
        private string type;
        private string arg;
        // TODO: 待完善...
        public ConstructorArg(MyBuilder builder)
        {
            this.isRef = builder.isRef;
            this.type = builder.type;
            this.arg = builder.arg;
        }
        public class MyBuilder
        {
            internal bool isRef;
            internal string type;
            internal string arg;
            public ConstructorArg builder()
            {
                if (!isRef && string.IsNullOrEmpty(type))
                {
                    throw new Exception("Type is not Null");
                }
                if (!isRef && string.IsNullOrEmpty(type))
                {
                    throw new Exception("Arg is not Null");
                }
                return new ConstructorArg(this);
            }
            public MyBuilder IsRef(bool isRef)
            {
                this.isRef = isRef;
                return this;
            }
            public MyBuilder SetType(string type)
            {
              
                this.type = type;
                return this;
            }
            public MyBuilder SetArg(string arg)
            {
              
                this.arg = arg;
                return this;
            }
        }
    }

  
}
