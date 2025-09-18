using System;
using System.IO.Compression;
using System.IO.Abstractions;
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
            var file = _args[2];
            
            var splitFile = file.Split('/');

            FileStream input = File.OpenRead(splitFile[3]);
            ZLibStream decompressedFile = new ZLibStream(input, CompressionMode.Decompress);
            StreamReader reader = new StreamReader(decompressedFile);
            Console.WriteLine(reader);
        }
    }
    
}