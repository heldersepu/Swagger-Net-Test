using System;

namespace Swagger_Test
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class SwaggerFormAttribute : Attribute
    {
        public SwaggerFormAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}