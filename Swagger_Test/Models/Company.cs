using System.ComponentModel;

namespace Swagger_Test
{
    public class Company
    {
        /// <summary>The Unique Company ID</summary>
        /// <example>123</example>
        [DefaultValue(456)]
        public int Id { get; set; }

        /// <summary>The Company Name</summary>
        /// <example>Acme co</example>
        [DefaultValue("My Company")]
        public string Name { get; set; }

        /// <summary>An optional description of the company</summary>
        /// <remarks>This is a good place to put additional details such as: Phone & Address </remarks>
        /// <example>Super duper company</example>
        public string Description { get; set; }

        /// <example>42rty</example>
        public string TaxCode { get; set; }

        /// <example>Tax Code Display</example>
        public string TaxCodeDisplayName { get; set; }

        public string allOf { get; set; }

        public string properties { get; set; }

        public string lowercase { get; set; }
        public string UPPERCASE { get; set; }
        public string huNGariAnCASE { get; set; }
    }
}