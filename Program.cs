namespace FileCreator;

class Program
{
    static void Main()
    {
        var files1 = new File(@"C:\Otus\TestDir1", "File", 10);
        var files2 = new File(@"C:\Otus\TestDir2", "File", 10);
        files1.Create();
        files1.ReadFile();
        files2.Create();
        files2.ReadFile();
    }
}