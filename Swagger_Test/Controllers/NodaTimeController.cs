using NodaTime.Extensions;
using System;
using System.Web.Http;

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

        [Route("my/route3")]
        public IHttpActionResult GetByDate3([FromUri] NodaTime.LocalDate date)
        {
            return Ok(date.ToString());
        }

        [Route("my/route4")]
        public IHttpActionResult GetByDate4([FromUri] InputData data)
        {
            return Ok(data);
        }

        [Route("my/route5/{date}")]
        public IHttpActionResult GetByDate5([FromUri] DateTime date)
        {
            try {
                var ndate = date.ToLocalDateTime().Date;
                return Ok(date.ToString());
            } catch  {
                return BadRequest("Date is not a valid NodaTime.LocalDate");
            }
        }

        [Route("my/route6")]
        public IHttpActionResult GetByDate6([FromUri] DateTime date)
        {
            try
            {
                var ndate = date.ToLocalDateTime().Date;
                return Ok(date.ToString());
            }
            catch
            {
                return BadRequest("Date is not a valid NodaTime.LocalDate");
            }
        }
    }

    public class InputData
    {
        public int Id { get; set; }
        public NodaTime.LocalDate Date { get; set; }
    }
}
