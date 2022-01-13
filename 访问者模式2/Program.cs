

class Program
{
    static void Main(string[] args)
    {
        //具体的操作
        Extractor extractor = new Extractor();//提取
        Compressor compressor = new Compressor();//压缩
        List<ResourceFile> resourceFiles = listAllResourceFiles();
        foreach (ResourceFile resourceFile in resourceFiles)
        {
            //extractor.extract2txt(resourceFile);
            resourceFile.accept(extractor);
            resourceFile.accept(compressor);
        }
    }

    private static List<ResourceFile> listAllResourceFiles()
    {
        List<ResourceFile> resourceFiles = new List<ResourceFile>();
        //...根据后缀(pdf/ppt/word)由工厂方法创建不同的类对象(PdfFile/PPTFile/WordFile)
        resourceFiles.Add(new PdfFile("a.pdf"));
        resourceFiles.Add(new WordFile("b.word"));
        resourceFiles.Add(new PPTFile("c.ppt"));
        return resourceFiles;
    }
}
public abstract class ResourceFile
{
    protected String filePath;
    public ResourceFile(String filePath)
    {
        this.filePath = filePath;
    }
    public abstract void accept(Visitor vistor);//这里重载不同的方法
   
}

public interface Visitor { 
    void visit(PdfFile pdfFile); 
    void visit(PPTFile pdfFile); 
    void visit(WordFile pdfFile); 
}

public class PdfFile : ResourceFile
{
    public PdfFile(String filePath) : base(filePath)
    {

    }

    public override void accept(Visitor visitor)
    {
        visitor.visit(this);
    }   
}
public class PPTFile : ResourceFile
{
    public PPTFile(String filePath) : base(filePath)
    {

    }
    public override void accept(Visitor visitor)
    {
        visitor.visit(this);
    }
}
public class WordFile : ResourceFile
{
    public WordFile(String filePath) : base(filePath)
    {

    }
    public override void accept(Visitor visitor)
    {
        visitor.visit(this);
    }
}

public class Extractor:Visitor
{
  
    public void visit(PdfFile file)
    {
        Console.WriteLine("Extract PDF.");
    }

    public void visit(PPTFile file)
    {
        Console.WriteLine("Extract PPT.");
    }

    public void visit(WordFile file)
    {
        Console.WriteLine("Extract Word.");
    }
}
public class Compressor : Visitor
{

    public void visit(PdfFile file)
    {
        Console.WriteLine("compress PDF.");
    }

    public void visit(PPTFile file)
    {
        Console.WriteLine("compress PPT.");
    }

    public void visit(WordFile file)
    {
        Console.WriteLine("compress World.");
    }
}
