using System;
using System.IO;
using System.IO.Abstractions;
using codecrafters_git;

var git = new GitApp(args, new FileSystem());
git.RunCommand();

//test