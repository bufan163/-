
using System;

namespace 装饰器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            InputStream inputStream= new FileInputStream("");
            InputStream bin = new BufferedInputStream(inputStream);
            DataInputStream dataInputStream =new DataInputStream(bin);
            dataInputStream.read(new System.Collections.Generic.List<byte>() { });
            Console.WriteLine("Hello World!");
        }
    }
}
