//using Swagger.Net.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using X.PagedList;

namespace Swagger_Test.Controllers
{
    public class PagedListController : ApiController
    {
        // GET: api/PagedList
        public IPagedList<Company> Get()
        {
            return PagedCompany;
        }

        // GET: api/PagedList/5
        //[SwaggerResponse(200, Type = typeof(IPagedList<Company>))]
        //[SwaggerResponse(statusCode: 400, type: typeof(string), description:"<p>Hello</p><p>World</p>")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(PagedCompany);
        }

        private PagedList<Company> PagedCompany
        {
            get
            {
                var data = new List<Company>();
                for (int i = 0; i < 10; i++)
                    data.Add(new Company { Id = i, Name = i.ToString() });
                return new PagedList<Company>(data, 1, 3);
            }
        }
    }
}
