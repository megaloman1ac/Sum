using System;
class Sum
{

    public static void GetArgs(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine(args[i]);
        }
    }

    public static void Main(string[] args)
    {
        GetArgs(args);
    }
}