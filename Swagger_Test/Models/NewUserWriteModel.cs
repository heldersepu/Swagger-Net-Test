using System;
using System.ComponentModel.DataAnnotations;

namespace Swagger_Test.Models
{
    public class NewUserWriteModel
    {        
        [StringLength(9999)]
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }

    }
}