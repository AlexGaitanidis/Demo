using Newtonsoft.Json.Linq;

namespace Demo.API
{
    public class AuthenticationToken
    {
        private readonly RequestDelegate _next;
        private readonly List<string> _tokens;

        public AuthenticationToken(RequestDelegate next)
        {
            _tokens = new List<string>();

            try
            {
                var jAppSettings = JToken.Parse(
                    File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json"))
                );

                foreach (var token in jAppSettings["tokens"])
                    _tokens.Add(token["key"].ToString());

            }
            catch { }

            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string token = context.Request.Headers["Authorization"];

            if (context.Request.Path.Value.ToLower().Contains("/api/users") && context.Request.Method.ToLower() == "delete")
            {
                if (token != null && _tokens.Contains(token))
                    await _next(context);

                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Access denied!");
                    return;
                }
            }

            else
                await _next(context);
        }
    }
}
