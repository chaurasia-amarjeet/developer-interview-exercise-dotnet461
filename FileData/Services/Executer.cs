using FileData.Extensions;
using FileData.Interfaces;
using System;

namespace FileData.Services
{
    public class Executer : IExecuter
    {
        private readonly IFileDetailsService _fileDetailsService;
        private readonly IValidator _validator;

        public Executer(IFileDetailsService fileDetailsService, IValidator validator)
        {
            _fileDetailsService = fileDetailsService;
            _validator = validator;
        }

        public void Execute(string[] args)
        {
            try
            {
                Console.WriteLine("Validating args...");
                _validator.ValidateConsoleArguments(args);

                var operation = args[0].GetOperation();

                Console.WriteLine($"Performing operation: {operation}");
                PerformOperation(operation, args[1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Exxception occured.");
            }
        }

        private void PerformOperation(Enum.Operation operation, string filePath)
        {
            switch (operation)
            {
                case Enum.Operation.FileVersion:
                    Console.WriteLine("File version: " + _fileDetailsService.GetFileVersion(filePath));
                    break;
                case Enum.Operation.FileSize:
                    Console.WriteLine("File size: " + _fileDetailsService.GetFileSize(filePath));
                    break;
            }
        }
    }
}
