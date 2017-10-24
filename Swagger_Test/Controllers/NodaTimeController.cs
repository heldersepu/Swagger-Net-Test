using System;
using System.Web.Http;
using NodaTime.Extensions;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("NodaTime")]
    public class NodaTimeController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(NodaTime.NodaConstants.BclEpoch.ToString());
        }

        [Route("my/route1/{date}")]
        public IHttpActionResult GetByDate1(NodaTime.LocalDate date)
        {
            return Ok(date.ToString());
        }

        [Route("my/route2/{date}")]
        public IHttpActionResult GetByDate2([FromUri] NodaTime.LocalDate date)
        {
            return Ok(date.ToString());
        }

        [Route("my/route3/{date}")]
        public IHttpActionResult GetByDate3(DateTime date)
        {
            try {
                var ndate = date.ToLocalDateTime().Date;
                return Ok(date.ToString());
            } catch  {
                return BadRequest("Date is not a valid NodaTime.LocalDate");
            }            
        }
    }
}
