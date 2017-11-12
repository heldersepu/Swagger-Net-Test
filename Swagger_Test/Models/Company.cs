namespace Swagger_Test
{
    public class Company
    {
        /// <example>123</example>
        public int Id { get; set; }

        /// <example>Acme co</example>
        public string Name { get; set; }

        /// <example>Super duper company</example>
        public string Description { get; set; }

        /// <example>42rty</example>
        public string TaxCode { get; set; }

        /// <example>Tax Code Display</example>
        public string TaxCodeDisplayName { get; set; }

        public string lowercase { get; set; }
        public string UPPERCASE { get; set; }
        public string huNGariAnCASE { get; set; }
    }
}