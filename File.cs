using System.Text;

namespace FileCreator;

public class File
{
    private List<string> _filesPathList = new List<string>();
    private string Path { get; }
    private string FileName { get; }
    private int FilesCount { get; }


    public File(string path, string fileName, int filesCount)
    {
        Path = path;
        FileName = fileName;
        FilesCount = filesCount;
    }

    public async Task Create()
    {
        var dir = new DirectoryInfo(Path);
        if (!dir.Exists)
        {
            dir.Create();
        }

        for (var i = 1; i <= FilesCount; i++)
        {
            string[] paths = { $"{Path}", $"{FileName}{i}.txt" };
            var filePath = System.IO.Path.Combine(paths);
            _filesPathList.Add(filePath);
            var file = new FileInfo(filePath);
            if (!file.Exists)
            {
                using var fileStream = System.IO.File.Create(filePath);
            }

            using (var sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                await sw.WriteLineAsync($"{file.Name}");
                await sw.WriteLineAsync($"{DateTime.Now}");
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