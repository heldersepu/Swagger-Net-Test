using System.Web.Http;

namespace Swagger_Test.Controllers
{
    /// <summary>
    /// Testing enums ...
    /// </summary>
    public class TestEnumController : ApiController
    {
        public enum CustomEnum
        {
            Text = 1,
            Numeric = 2,
            Date = 4,
            Numeric_Function = 8,
            Dropdown_List = 16,
            Checkbox = 32
        }

        /// <summary>
        /// Simple GET echoing the given param
        /// </summary>
        /// <param name="value">CustomEnum</param>
        /// <returns>CustomEnum</returns>
        public CustomEnum Get(CustomEnum value)
        {
            return value;
        }

        /// <summary>
        /// Test POST lorem ipsum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public CustomEnum Post(CustomEnum value)
        {
            return value;
        }
    }
}
