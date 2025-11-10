using System;
using System.Linq.Expressions;
using SumHash;

namespace SumHash
{
    class Sum
    {
        public static Hash hash = new Hash();
        public static Messages mess = new Messages();

        public static void GetArgs(string[] args)
        {
            for (int i = 0; i < args.Length; i += 2)
            {
                switch (args[i])
                {
                    case "-f":
                    case "--file":
                        try
                        {
                            if (args[i + 1][0] == '-')
                            {
                                mess.printMessage("Error", "No file was found or written");
                            }
                            else
                            {
                                hash.typeOfHash = args[i + 1];

                                mess.printMessage("File", $"Input file added [ {hash.typeOfHash} ]");
                            }
                        }
                        catch (Exception e)
                        {
                            mess.printMessage("Error", "No file was found or written");
                        }

                        break;

                    case "-a":
                    case "--algo":
                        try
                        {
                            if (args[i + 1][0] == '-')
                            {
                                mess.printMessage("Error", "No algorithm was found or written");
                            }
                            else
                            {
                                hash.fileToGetHash = args[i + 1];

                                mess.printMessage("Algo", $"algo was added [ {hash.fileToGetHash} ]");
                            }
                        }
                        catch (Exception e)
                        {
                            mess.printMessage("Error", "No algorithm was found or written");
                        }
                        break;

                    default:
                        mess.printMessage("Error", $"\"{args[i]}\" was not found");
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            GetArgs(args);
        }
    }
}