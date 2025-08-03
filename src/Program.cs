using System;
using System.IO;

if (args.Length < 1)
{
    Console.WriteLine("Please provide a command.");
    return;
}

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.Error.WriteLine("Logs from your program will appear here!");

string command = args[0];

if (command == "init")
{
    // Uncomment this block to pass the first stage
    Directory.CreateDirectory(".git");
    Directory.CreateDirectory(".git/objects");
    Directory.CreateDirectory(".git/refs");
    File.WriteAllText(".git/HEAD", "ref: refs/heads/main\n");
    Console.WriteLine("Initialized git directory");
}
// else if (command == "cat-file")
// {
    
//     var file = args[3];
    
//     using (FileStream input = File.OpenRead(file))
//     using (FileStream output = File.Create("data.text"))
//     using (ZlibStream decompressor = new ZlibStream(output, CompressionMode.decompress))
//     {
//         input.CopyTo(decompressor);
//     }

//    var result = File.OpenRead(output);

//     Console.WriteLine(result);
// }

