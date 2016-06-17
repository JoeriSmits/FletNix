using System;
using System.Net;
using System.Threading.Tasks;
using FletNix.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Extensions;

namespace FletNix.MiddleWare
{
    public class DeepLinkBlocker
    {
        RequestDelegate _next;
        private FletNixContext _context;

        public DeepLinkBlocker(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().StartsWith("/movie"))
            {
                
                if (!context.User.Identity.IsAuthenticated)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    await context.Response.WriteAsync("<h1>Forbidden</h1><p>You don't have permission to access: " + context.Request.Path + "</p>");
                }
                else {
                    await _next(context);
                }
            }
            else {
                await _next(context);
            }
        }
    }
}