namespace Repository_UnitOfWork.Middleware
{
    public static class ExtensionsSwaggerAuthToBuilder
    {
        public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerBasicAuthMiddleware>();
        }
    }
}
