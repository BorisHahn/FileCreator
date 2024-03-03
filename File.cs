using System.Text;

namespace FileCreator;

public class File
{
    private readonly List<string> _filesPathList = new List<string>();
    private readonly string _path;
    private readonly string _fileName;
    private readonly int _filesCount;


    public File(string path, string fileName, int filesCount)
    {
        _path = path;
        _fileName = fileName;
        _filesCount = filesCount;
    }

    public async Task Create()
    {
        var dir = new DirectoryInfo(_path);
        if (!dir.Exists)
        {
            dir.Create();
        }

        for (var i = 1; i <= _filesCount; i++)
        {
            string[] paths = { $"{_path}", $"{_fileName}{i}.txt" };
            var filePath = System.IO.Path.Combine(paths);
            _filesPathList.Add(filePath);
            var file = new FileInfo(filePath);
            if (!file.Exists)
            {
                using (StreamWriter fileStream = System.IO.File.CreateText(filePath))
                {
                    fileStream.WriteLine($"{file.Name}");
                    fileStream.WriteLine($"{DateTime.Now}");
                }
            }
        }
    }

    public async Task ReadFile()
    {
        foreach (var filePathItem in _filesPathList)
        {
            using (var sr = new StreamReader(filePathItem))
            {
                string? line;
                var text = "";
                while (!sr.EndOfStream)
                {
                    text += $" {sr.ReadLine()}";
                }

                sr.Close();
                Console.WriteLine($"имя_файла:{text}");
            }
        }
    }
}