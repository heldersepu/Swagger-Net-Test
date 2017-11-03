using Swagger.Net.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using X.PagedList;
using System.Collections;

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
        [SwaggerResponse(200, Type = typeof(IPagedList<Company>))]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(PagedCompany);
        }

        public MyPagedList Post()
        {
            return null;
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

    public class MyPagedList : IPagedList<Company>
    {
        public int Abc { get; }
        public int Def { get; }

        public Company this[int index]
        {
            get
            {                
                return new Company { Id = 1, Name = "Acme" };
            }
        }

        public int Count { get; }        

        public int PageCount { get; }

        public int TotalItemCount { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public bool HasPreviousPage { get; }

        public bool HasNextPage { get; }

        public bool IsFirstPage { get; }

        public bool IsLastPage { get; }

        public int FirstItemOnPage { get; }

        public int LastItemOnPage { get; }
        
        public IEnumerator<Company> GetEnumerator()
        {
            var data = new List<Company>();
            for (int i = 0; i < 10; i++)
                data.Add(new Company { Id = i, Name = i.ToString() });
            return null;
        }

        public PagedListMetaData GetMetaData()
        {
            return this.GetMetaData();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
