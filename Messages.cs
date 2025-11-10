using System;
using System.Collections;
using SumHash;

namespace SumHash
{

    class Messages
    {
        public void printMessage(string type, string message)
        {
            type = char.ToUpper(type[0]) + type.Substring(1);
            Console.WriteLine($"[ {type} ] : {message}");            
        }
    }
}