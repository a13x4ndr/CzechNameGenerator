using Xunit;
using NameGenerator.Services;
using NameGenerator.Models;
using System.Linq;

namespace NameGenerator.Tests
{
    public class NameGenerationServiceTests
    {
        private readonly NameGenerationService _service;

        public NameGenerationServiceTests()
        {
            _service = new NameGenerationService();
        }

        [Fact]
        public void GenerateFullName_ReturnsNonEmptyString_ForMaleWithoutMiddleName()
        {
            string name = _service.GenerateFullName("male");
            Assert.False(string.IsNullOrWhiteSpace(name));
        }

        [Fact]
        public void GenerateFullName_WithMiddleName_ReturnsThreeParts_And_MiddleNotEqualToFirst()
        {
            string name = _service.GenerateFullName("female", withMiddleName: true);
            var parts = name.Split(' ');
            Assert.Equal(3, parts.Length);
            Assert.NotEqual(parts[0], parts[1]);
        }

        [Fact]
        public void GenerateFullNames_ReturnsSpecifiedCount()
        {
            var options = new NameGenerationOptions
            {
                Gender = "male",
                IncludeMiddleName = false,
                Count = 5,
                UseAcademicTitle = false
            };

            var names = _service.GenerateFullNames(options);
            Assert.Equal(5, names.Count);
        }

        [Fact]
        public void GenerateFullNames_WithAcademicTitle_IncludesTitlePrefix()
        {
            var options = new NameGenerationOptions
            {
                Gender = "female",
                IncludeMiddleName = false,
                Count = 3,
                UseAcademicTitle = true,
                AcademicTitle = "PhD."
            };

            var names = _service.GenerateFullNames(options);
            Assert.All(names, name => Assert.StartsWith("PhD.", name));
        }
    }
}

