using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public abstract class NestedEnum<T> : ApiController
    {
        public enum Giorno { Lunedi, Martedi, Venerdi }


        /// <summary> A nullable enum test </summary>
        public string PutEnumNull(Giorno value)
        {
            return "Nullable Enum parameter";
        }

        /// <summary> A non-null enum test </summary>
        public string DeleteEnumNonNull(Giorno value)
        {
            return "Non-Null Enum parameter";
        }
    }

    public class NestedEnumController : NestedEnum<int> { }
}
