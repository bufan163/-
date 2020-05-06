using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 组合模式
{

    public class FileSystemNode
    {
        private String path;
        private bool isFile;
        private List<FileSystemNode> subNodes = new List<FileSystemNode>();

        public FileSystemNode(String path, bool isFile)
        {
            this.path = path;
            this.isFile = isFile;
        }

        public int countNumOfFiles()
        {
            if (isFile) { return 1; }
            int numOfFiles = 0;
            foreach (FileSystemNode fileOrDir in subNodes)
            {
                numOfFiles += fileOrDir.countNumOfFiles();
            }
            return numOfFiles;
        }

        public long countSizeOfFiles()
        {
            if (isFile)
            {
                if (!File.Exists(path)) return 0;
                return File.ReadAllText(path).Length;
            }
            long sizeofFiles = 0;
            foreach (FileSystemNode fileOrDir in subNodes)
            {
                sizeofFiles += fileOrDir.countSizeOfFiles();
            }
            return sizeofFiles;
        }

        public String getPath()
        {
            return path;
        }

        public void addSubNode(FileSystemNode fileOrDir)
        {
            subNodes.Add(fileOrDir);
        }

        public void removeSubNode(FileSystemNode fileOrDir)
        {
            int size = subNodes.Count;
            int i = 0;
            for (; i < size; ++i)
            {
                if (subNodes[i].getPath().Equals(fileOrDir.getPath()))
                {
                    break;
                }
            }
            if (i < size)
            {
                subNodes.Remove(i);
            }
        }
    }
}
