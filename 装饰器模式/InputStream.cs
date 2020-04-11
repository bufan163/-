using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 装饰器模式
{

    public abstract class InputStream
    {
        //...
        public int read(List<byte> b)
        {
            return read(b, 0, b.Count);
        }

        public int read(List<byte> b, int off, int len)
        {
            return 0;
        }

        public long skip(long n)
        {
            return 0L;
        }

        public int available()
        {
            return 0;
        }

        public void close() { }

        public async void mark(int readlimit) { }

        public async void reset()
        {
            throw new IOException("mark/reset not supported");
        }

        public bool markSupported()
        {
            return false;
        }
    }

    public class FileInputStream : InputStream
    {
        protected volatile InputStream inputStream;
        public FileInputStream(string inputStream)
        {
             //this.inputStream;
        }
    }
    public class FilterInputStream : InputStream
    {
        protected volatile InputStream inputStream;

        public FilterInputStream(InputStream inputStream)
        {
            this.inputStream = inputStream;
        }
    }

    public class BufferedInputStream : FilterInputStream
    {
        protected volatile InputStream input;

        public BufferedInputStream(InputStream input) : base(input)
        {
            this.input = input;
        }
        //...实现基于缓存的读数据接口...  
    }

    public class DataInputStream : FilterInputStream
    {
        protected volatile InputStream input;

        public DataInputStream(InputStream input) : base(input)
        {
            this.input = input;
        }

        //...实现读取基本类型数据的接口
    }
}
