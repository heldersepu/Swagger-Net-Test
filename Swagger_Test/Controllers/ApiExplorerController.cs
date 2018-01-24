using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Swagger_Test.Controllers
{

    public class ApiExplorerController : ApiController
    {
        /// <summary>
        /// Testing the summary on the ApiExplorerController
        /// </summary>
        /// 
        /// <remarks>
        /// Testing the description on the ApiExplorerController
        /// This is a second line
        /// Here is a link to <a href="https://github.com/heldersepu">my GitHub profile</a>
        /// <br/>
        /// Some HTML styling: <b>BOLD</b> <i>italics</i>
        /// <ul>
        /// <li>Item one</li>
        /// <li>Item two</li>
        /// </ul>
        /// <pre>Text in a pre element</pre>
        ///
        /// <h1>Header1</h1>
        /// <h2>Header2</h2>
        /// <h3>Header3</h3>
        /// </remarks>
        public IEnumerable<string> Get()
        {
            var apiEx = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            return apiEx.ApiDescriptions.Select(a => $"{a.HttpMethod} {a.RelativePath}");
        }

    }
}
