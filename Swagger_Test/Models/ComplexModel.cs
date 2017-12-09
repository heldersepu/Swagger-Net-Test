namespace Swagger_Test.Models
{
    public class EntityRequest
    {
        public Entity person { get; set; }
    }

    public class Entity
    {
        public string Description { get; set; }
        public EntityName entityName { get; set; }
    }

    public class EntityName
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}