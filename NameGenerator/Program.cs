using System;
using NameGenerator.Models;
using NameGenerator.Services;

namespace NameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameService = new NameGenerationService();

            // Option 1: Generate a single male full name with a middle name.
            string singleMaleName = nameService.GenerateFullName("male", withMiddleName: true);
            Console.WriteLine("Single Male Full Name: " + singleMaleName);

            // Option 2: Generate a single female full name without a middle name.
            string singleFemaleName = nameService.GenerateFullName("female");
            Console.WriteLine("Single Female Full Name: " + singleFemaleName);

            // Option 3: Generate multiple names with user options.
            var options = new NameGenerationOptions
            {
                Gender = "male",
                IncludeMiddleName = true,
                Count = 5,
                UseAcademicTitle = true,
                AcademicTitle = "PhD."
            };

            var namesList = nameService.GenerateFullNames(options);
            Console.WriteLine("\nMultiple Generated Names:");
            foreach (var name in namesList)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}