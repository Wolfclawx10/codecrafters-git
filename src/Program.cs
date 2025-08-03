using System;
using System.IO;
using System.IO.Abstractions;
using codecrafters_git;

var git = new GitApp(args, new FileSystem());
git.RunCommand();

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

