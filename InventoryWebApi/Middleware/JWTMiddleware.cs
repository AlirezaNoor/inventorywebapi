using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace InventoryWebApi.Middleware
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public JWTMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //get token from header or cookie or query string
            // var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var token = context.Request.Cookies["token"] ?? context.Request.Query["token"];
            if (token != null)
            {
                try
                {
                    //get secret key from environment variables and decode jwt from request and get user id from it
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = _configuration.GetValue<byte[]>("Tokenkey");
                    /*var key = Encoding.ASCII.GetBytes(Env.GetString("JWT_SECRET"));*/
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken) validatedToken;
                    context.Items["userid"] = jwtToken.Claims.First(x => x.Type == "nameid").Value;
                    context.Items["username"] = jwtToken.Claims.First(x => x.Type == "unique_name").Value;
                }
                catch
                {
                    // do nothing if jwt validation fails
                    // account is not attached to context so request won't have access to secure routes
                }
            }

            if (context.Items["username"] == null)
            {
                await context.Response.WriteAsJsonAsync(new
                {
                    auth_error = "دسترسی غیر مجاز می باشد"
                });
                return;
            }

            await _next(context);
        }
    }

    public static class JWTMiddlewareExtensions
    {
        public static IApplicationBuilder UseJWTMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<JWTMiddleware>();
        }
    }

    public class JWTMiddlewareAnnotation
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<JWTMiddleware>();
        }
    }
}