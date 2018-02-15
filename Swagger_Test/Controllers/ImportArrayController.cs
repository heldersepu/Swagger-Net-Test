using System;
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
            Contact = new HashSet<Contact>();
            SupplyAgreement = new HashSet<SupplyAgreement>();
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
        public ICollection<Contact> Contact { get; set; }
        public ICollection<SupplyAgreement> SupplyAgreement { get; set; }
    }

    public partial class Contact
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string BusinessPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string allOf { get; set; }
        public TheProps properties { get; set; }
        public TheProps properties2 { get; set; }

        public DateTime? Updated { get; set; }

        public Account Account { get; set; }
    }

    public partial class SupplyAgreement
    {
        public SupplyAgreement()
        {
        }

        public int Id { get; set; }
        public int EntityId { get; set; }
        public int? AccountId { get; set; }
        public string Name { get; set; }
        public int? Slaid { get; set; }

        public Account Account { get; set; }
    }

    public class TheProps
    {
        public int abc { get; set; }
        public int bcd { get; set; }
        public int def { get; set; }
    }
}
