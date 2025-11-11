// ** libraries ** //

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.IO;

// ** namespaces ** //
using SumHash;
using System.Threading.Tasks;

namespace SumHash
{
    class Sum
    {
        public static Hash hash = new Hash();
        public static Messages mess = new Messages();
        public static byte err = 0;
        public static string outputFile = string.Empty;

        public static void GetArgs(string[] args)
        {
            for (int i = 0; i < args.Length; i += 2)
            {
                switch (args[i])
                {
                    case "-f":
                    case "--file":
                        if (i + 1 == args.Length || args[i + 1][0] == '-')
                        {
                            mess.printMessage("Error", "No file was found or written");
                            err = 1;
                        }
                        else
                        {
                            hash.fileToGetHash = args[i + 1];
                            mess.printMessage("File", $"Input file added [ {hash.fileToGetHash} ]");
                        }
                        break;

                    case "-a":
                    case "--algo":
                        if (i+1 == args.Length || args[i + 1][0] == '-')
                        {
                            mess.printMessage("Error", "No algorithm was found or written");
                            err = 1;
                        }
                        else
                        {
                            hash.typeOfHash = args[i + 1];
                            mess.printMessage("Algo", $"algo was added [ {hash.typeOfHash} ]");
                        }
                        break;

                    default:
                        mess.printMessage("Error", $"\"{args[i]}\" was not found");
                        err = 1;
                        break;
                }
            }
        }

        public static async Task Main(string[] args)
        {
            GetArgs(args);

            if (err == 1)
            {
                mess.printMessage("End", $"Shutting down");
                Environment.Exit(0);
            }

            if (hash.typeOfHash == string.Empty)
            {
                hash.typeOfHash = "sha256";
                mess.printMessage("Algo", $"default algorithm [ {hash.typeOfHash} ]");
            }

            Process powershell = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"certutil -hashfile {hash.fileToGetHash} {hash.typeOfHash}",
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };


            List<string> line = new List<string>();

            powershell.Start();
            while (!powershell.StandardOutput.EndOfStream)
            {
                line.Add(powershell.StandardOutput.ReadLine());
            }

            hash.hashOfFile = line[1];

            line = null;
            err = 0;

            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.WaitForPendingFinalizers();

            mess.printMessage("Hash", $"hash of file [ {hash.hashOfFile} ]");
            outputFile = $"{hash.fileToGetHash}.{hash.typeOfHash}";

            try
            {
                if (!File.Exists(outputFile))
                {
                    mess.printMessage("OutFile", $"Working on [ {outputFile} ]");
                    File.WriteAllText(outputFile, $"{hash.hashOfFile}  {(hash.fileToGetHash).Substring((hash.fileToGetHash).LastIndexOf("\\") + 1)}");
                    mess.printMessage("OutFile", $"File has been written [ {outputFile} ]");
                }
            }
            catch(Exception ex)
            {
                mess.printMessage("Error", $"{ex.Message}");
            }
        }
    }
}