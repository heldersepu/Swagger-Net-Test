using Swagger_Test.Models;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class EnumTestController : ApiController
    {
        public ShiftDayOffRule Get(ShiftDayOffRule rule)
        {
            return rule;
        }

        public ShiftDayOffRule Post(TestEnum data)
        {
            return data.shift_day_off_rule;
        }

    }

    public class TestEnum
    {
        /// <summary>Everything needs an ID.</summary>
        public int id;

        /// <summary>
        /// <ul>
        /// <li>None = 0,       // DayOffNotRequired</li>
        /// <li>OffAfter = 1,   // DayOffAfter next is off</li>
        /// <li>OffBefore = -1, // DayOffBefore previous is off</li>
        /// <li>InAfter = 3     // DayInAfter next cannot be off</li>
        /// </ul>
        /// </summary>
        public ShiftDayOffRule shift_day_off_rule;

    }
}
