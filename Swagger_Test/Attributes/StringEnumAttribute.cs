using System;

namespace Swagger_Test
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StringEnumAttribute : Attribute
    {
        public string[] Colors { get; set; }

        public StringEnumAttribute(string[] colors)
        {
            Colors = colors;
        }
    }
}