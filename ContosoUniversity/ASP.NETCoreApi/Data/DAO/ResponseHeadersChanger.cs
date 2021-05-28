using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace ASP.NETCoreApi.Data.DAO
{
    public class ResponseHeadersChanger
    {
        private IHttpContextAccessor ContextAccessor { get; set; } 
        
        public ResponseHeadersChanger(IHttpContextAccessor httpContextAccessor)
        {
            ContextAccessor = httpContextAccessor;
        }
        
        public void AddOptions(HttpResponse r)
        {
            
            r.Headers.Add("Allow", new StringValues("OPTIONS, GET, HEAD, POST"));
        }
    }
}