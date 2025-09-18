using System;
using System.IO.Compression;
using System.IO.Abstractions;
using System.Text;

namespace codecrafters_git;

public class GitApp
{
    private readonly string[] _args;
    private readonly IFileSystem _fileSystem;

    public GitApp(string[] args, IFileSystem fileSystem)
    {
        _args = args;
        _fileSystem = fileSystem;
    }

    public void RunCommand()
    {
        if (_args.Length < 1)
        {
            Console.WriteLine("Please provide a command.");
            return;
        }
        
        string command = _args[0];

        if (command == "init")
        {
            // Uncomment this block to pass the first stage
            _fileSystem.Directory.CreateDirectory(".git");
            _fileSystem.Directory.CreateDirectory(".git/objects");
            _fileSystem.Directory.CreateDirectory(".git/refs");
            _fileSystem.File.WriteAllText(".git/HEAD", "ref: refs/heads/main\n");
            Console.WriteLine("Initialized git directory");
        }
        
        else if (command == "cat-file")
        {
            FileStream file = new($".git/objects/{_args[2][..2]}/{_args[2][2..]}",
                FileMode.Open, FileAccess.Read);
            ZLibStream decompressedFile = new ZLibStream(file, CompressionMode.Decompress);
            StreamReader reader = new StreamReader(decompressedFile,Encoding.UTF8);
            Console.WriteLine(reader.ReadToEnd().Split('\x00')[1]);
        }
    }
    
}