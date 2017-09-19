using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class ImportArrayController : ApiController
    {
        public IHttpActionResult Post([FromBody]Account[] value)
        {
            return Ok(value);
        }
    }

    public partial class Account
    {
        public Account()
        {
            Contact = new HashSet<string>();
            SupplyAgreement = new HashSet<string>();
        }
        
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Vat { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Website { get; set; }

        //public Entity Entity { get; set; }
        public ICollection<string> Contact { get; set; }
        public ICollection<string> SupplyAgreement { get; set; }
    }
}
