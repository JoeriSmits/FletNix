using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Extensions;

namespace FletNix.MiddleWare
{
    public class DeepLinkBlocker
    {
        RequestDelegate _next;
        
        public DeepLinkBlocker(RequestDelegate next) {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            // if(context.Request.GetEncodedUrl().EndsWith(".jpg")
            //  && context.Request.Headers["HTTP_REFERER"] != "localhost") {
            //     context.Response.Redirect("http://hoi.nl");
            // } else {
                await _next(context);
            // }
        }
    }
}