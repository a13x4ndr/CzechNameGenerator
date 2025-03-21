namespace NameGenerator.Models
{
    public class NameGenerationOptions
    {
        /// <summary>
        /// Specifies the gender: "male" or "female"
        /// </summary>
        public string Gender { get; set; } = "male";

        /// <summary>
        /// Determines whether a middle name should be included.
        /// </summary>
        public bool IncludeMiddleName { get; set; } = false;

        /// <summary>
        /// The number of full names to generate.
        /// </summary>
        public int Count { get; set; } = 1;

        /// <summary>
        /// Whether to include an academic title before the name.
        /// </summary>
        public bool UseAcademicTitle { get; set; } = false;

        /// <summary>
        /// The academic title to use (e.g., "Mgr.", "PhD."). If not provided, a default title can be used.
        /// </summary>
        public string AcademicTitle { get; set; } = "";
    }
}
