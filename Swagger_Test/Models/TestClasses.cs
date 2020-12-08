using System;

namespace Swagger_Test.Models
{
    public class test1
    {
        public int MyId;
        public Guid data;
    }

    public class test2
    {
        public int? MyId;
        public Guid data;
    }

    public class rint
    {
        public int num;
        public DateTime date;
    }

    public class EditModel
    {
        public class Command
        {
            public int Id { get; set; }
            public string Info { get; set; }
        }
    }
    
    public class CreateModel
    {
        public class Command
        {
            public int Id { get; set; }
            public string Info { get; set; }
        }
    }
}