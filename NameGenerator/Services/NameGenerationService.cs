using System;
using System.Collections.Generic;
using System.Linq;
using NameGenerator.Models;
using NameGenerator.Utilities;

namespace NameGenerator.Services
{
    public class NameGenerationService
    {
        private static readonly Random _random = new Random();
        private readonly NameData _nameData;

        public NameGenerationService()
        {
            // Load the embedded JSON data.
            _nameData = DataLoader.LoadNameData();
        }

        // Generate multiple full names based on user options.
        public List<string> GenerateFullNames(NameGenerationOptions options)
        {
            var names = new List<string>();

            for (int i = 0; i < options.Count; i++)
            {
                string fullName = GenerateFullName(options.Gender, options.IncludeMiddleName);

                // Optionally prepend an academic title.
                if (options.UseAcademicTitle)
                {
                    // Use provided title or default title if not provided.
                    string title = string.IsNullOrWhiteSpace(options.AcademicTitle) ? "Mgr." : options.AcademicTitle;
                    fullName = $"{title} {fullName}";
                }

                names.Add(fullName);
            }

            return names;
        }

        // Public method to generate a full name (first and last) with an option for a middle name.
        public string GenerateFullName(string gender, bool withMiddleName = false)
        {
            List<TableName> firstNames;
            List<TableName> lastNames;

            if (gender.ToLower() == "male")
            {
                firstNames = _nameData.MaleNames;
                lastNames = _nameData.MaleLastNames;
            }
            else if (gender.ToLower() == "female")
            {
                firstNames = _nameData.FemaleNames;
                lastNames = _nameData.FemaleLastNames;
            }
            else
            {
                throw new ArgumentException("Invalid gender specified. Use 'male' or 'female'.");
            }

            string firstName = GenerateRandomName(firstNames);
            string lastName = GenerateRandomName(lastNames);

            if (withMiddleName)
            {
                string middleName;
                // Loop until we get a middle name that is different from the first name.
                do
                {
                    middleName = GenerateRandomName(firstNames);
                } while (middleName == firstName);

                return $"{firstName} {middleName} {lastName}";
            }
            else
            {
                return $"{firstName} {lastName}";
            }
        }

        // Helper method to generate a random name from a list using cumulative probability.
        private string GenerateRandomName(List<TableName> tableNames)
        {
            double randomValue = _random.NextDouble();
            double cumulative = 0.0;

            foreach (var item in tableNames)
            {
                cumulative += item.Probability;
                if (randomValue <= cumulative)
                    return item.Name;
            }

            // Fallback: return the last name if rounding issues occur.
            return tableNames.Last().Name;
        }
    }
}

