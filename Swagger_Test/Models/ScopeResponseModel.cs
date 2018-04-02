namespace Swagger_Test.Models
{
    public class ScopeResponseModel
    {
        /// <summary>
        /// Id of the administrative scope.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the administrative scope.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the administrative scope.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the administrative scope is built-in.
        /// </summary>
        public bool IsBuiltIn { get; set; }

        /// <summary>
        /// Indicates the built-in "All" scope.  There will be
        /// exactly one scope with this property set to <c>true</c>.
        /// </summary>
        public bool IsAllScope { get; set; }
    }
}