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
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-f":
                        try
                        {
                            if (args[i + 1][0] == '-')
                            {
                                mess.printMessage("Error", "No file was found or written");
                            }
                            else
                            {
                                hash.fileToGetHash = args[i + 1];

                                mess.printMessage("File", $"Input file added [ {hash.fileToGetHash} ]");
                            }
                        }
                        catch (Exception e)
                        {
                            mess.printMessage("Error", "No file was found or written");
                        }
                        
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