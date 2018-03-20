using System.ComponentModel.DataAnnotations;

namespace Swagger_Test.Models
{
    /// <summary>
    /// Testing POCO model
    /// </summary>
    public class ViewModelTest
    {
        /// <summary>
        /// The super ID that will be used
        /// </summary>
        /// <example>123</example>
        public int Id { get; set; }

        /// <summary>
        /// Who needs a name?
        /// </summary>
        /// <example>John Doe</example>
        public string Name { get; set; }

        /// <example>aaabbbddd</example>
        public string abd { get; set; }

        /// <example>xxxyyyzzz</example>
        public string xyz { get; set; }

        /// <example>cccdddeee</example>
        public string cde { get; set; }

        [MinLength(3)]
        [MaxLength(5)]
        //[Range(typeof(string), "AAA", "ZZZZZ")]
        public string bcd { get; set; }

    }
}