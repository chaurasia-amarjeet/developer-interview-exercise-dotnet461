using FileData.Constants;
using FileData.Interfaces;
using System;

namespace FileData.Services
{
    public class Validator : IValidator
    {
        public void ValidateConsoleArguments(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Expecting atleast 2 arguments.");
                throw new Exception("Expecting atleast 2 arguments.");
            }

            if (!(ListConstants.VersionConstansts.Contains(args[0]) 
                || ListConstants.SizeConstansts.Contains(args[0])))
            {
                Console.WriteLine($"Invalid first argument: {args[0]}");
                throw new Exception($"Invalid first argument: {args[0]}");
            }
        }
    }
}
