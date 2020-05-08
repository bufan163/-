using System;
using System.IO;

namespace 组合模式
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
      * /
      * /wz/
      * /wz/a.txt
      * /wz/b.txt
      * /wz/movies/
      * /wz/movies/c.avi
      * /xzg/
      * /xzg/docs/
      * /xzg/docs/d.txt
      */
            var fileSystemTree =  Directory.CreateDirectory("/");
            DirectoryInfo node_wz = new DirectoryInfo("/wz/");
            DirectoryInfo node_xzg = new DirectoryInfo("/xzg/");
            fileSystemTree.CreateSubdirectory("/wz/");
            fileSystemTree.CreateSubdirectory("/xzg/");

            var node_wz_a =  File.Create("/wz/a.txt");
            var node_wz_b =  File.Create("/wz/b.txt");
            var node_wz_movies = Directory.CreateDirectory("/wz/movies/");
            node_wz.CreateSubdirectory("/wz/a.txt");
            node_wz.CreateSubdirectory("/wz/b.txt");
            node_wz.CreateSubdirectory("/wz/movies/");

            var node_wz_movies_c = File.Create("/wz/movies/c.avi");
            node_wz_movies.CreateSubdirectory("/wz/movies/c.avi");

            DirectoryInfo node_xzg_docs = new DirectoryInfo("/xzg/docs/");
            node_xzg.CreateSubdirectory("/xzg/docs/");

            var node_xzg_docs_d = File.Create("/xzg/docs/d.txt");
            node_xzg_docs.CreateSubdirectory("/xzg/docs/d.txt");
            
        }
    }
}
