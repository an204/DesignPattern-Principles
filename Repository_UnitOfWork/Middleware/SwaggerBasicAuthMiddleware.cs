using System.Net.Http.Headers;
using System.Net;
using System.Text;

namespace Repository_UnitOfWork.Middleware
{
    public class SwaggerBasicAuthMiddleware
    {
        int count = 0;
        private readonly RequestDelegate next;
        private Microsoft.Extensions.Configuration.IConfiguration _iConfiguration;
        public SwaggerBasicAuthMiddleware(RequestDelegate next, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            this.next = next;
            this._iConfiguration = config;
        }
        /// <summary>
        /// The main method that gets executed for each request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the request path starts with "/swagger"
            if (context.Request.Path.StartsWithSegments("/swagger/index.html"))
            {
                #region

                //// Get the Authorization parameter value from the query string
                //string authorizationValue = context.Request.Query["Authorization"];
                //// Get the value of the "user" query parameter
                //string user = context.Request.Query["user"];
                //// Get the value of the "pass" query parameter
                //string pass= context.Request.Query["pass"];

                // Extract and decode the credentials
                var isAuthenticated = context.Session.GetString("SwaggerAuthenticated");
                if (isAuthenticated == "true")
                {
                    await next.Invoke(context).ConfigureAwait(false);
                    return;
                }
                context.Response.Redirect("https://localhost:7117/SwaggerLoggin/Login");
                #endregion
            }
            else
            {
                await next.Invoke(context).ConfigureAwait(false);
            }
        }
    }
}
