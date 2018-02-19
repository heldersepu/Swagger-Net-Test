using System;
using System.ComponentModel.DataAnnotations;

namespace Swagger_Test.Models
{
    public class NewUserWriteModel
    {
        public Guid Uid { get; set; }

        [MinLength(5)]
        [MaxLength(250)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }
    }
}