

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
    public abstract void accept(Extractor extractor);//这里重载不同的方法
    abstract public void accept(Compressor compressor);
}

public class PdfFile : ResourceFile
{
    public PdfFile(String filePath) : base(filePath)
    {

    }

    public override void accept(Extractor extractor)
    {
        extractor.extract2txt(this);
    }
    public override void accept(Compressor compressor)
    {
        compressor.compress(this);
    }
}
public class PPTFile : ResourceFile
{
    public PPTFile(String filePath) : base(filePath)
    {

    }
    public override void accept(Extractor extractor)
    {
        extractor.extract2txt(this);
    }
    public override void accept(Compressor compressor)
    {
        compressor.compress(this);
    }
}
public class WordFile : ResourceFile
{
    public WordFile(String filePath) : base(filePath)
    {

    }
    public override void accept(Extractor extractor)
    {
        extractor.extract2txt(this);
    }
    public override void accept(Compressor compressor)
    {
        compressor.compress(this);
    }
}

public class Extractor
{
    public void extract2txt(PPTFile pptFile)
    {
        Console.WriteLine("Extract PPT.");
    }

    public void extract2txt(PdfFile pdfFile)
    {
        Console.WriteLine("Extract PDF.");
    }

    public void extract2txt(WordFile wordFile)
    {
        Console.WriteLine("Extract WORD.");
    }
}
public class Compressor
{
    public void compress(PPTFile pptFile)
    {
        Console.WriteLine("compress PPT.");
    }

    public void compress(PdfFile pdfFile)
    {
        Console.WriteLine("compress PDF.");
    }

    public void compress(WordFile wordFile)
    {
        Console.WriteLine("compress WORD.");
    }
}
