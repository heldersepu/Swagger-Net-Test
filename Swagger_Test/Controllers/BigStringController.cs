using System;
using System.Text;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class BigStringController : ApiController
    {
        /// <remarks>
        /// <h2>Testing html table</h2>
        /// <table border="1">
        ///     <tr>
        ///         <td colspan="3"><span class="method">ONE</span></td>
        ///     </tr>
        ///     <tr>
        ///         <td>ABC11</td>
        ///         <td>ABC22</td>
        ///         <td>ABC33</td>
        ///     </tr>
        /// </table>
        /// <img src="https://yuml.me/diagram/class/%5BSupplier%7Bbg:orange%7D%5D,%5BSupplier%5D-0..1%3E%5BAddress%5D,%5BSupplier%5D" />
        /// </remarks>
        public string Get(int max = 10000)
        {
            var big = new StringBuilder();
            for (int i = 0; i < max; i++)
            {
                big.Append(" ");
                big.Append(i.ToString());
                big.Append(",");
                big.Append(DateTime.Now.Ticks.ToString());
            }
            return big.ToString();
        }
    }
}
