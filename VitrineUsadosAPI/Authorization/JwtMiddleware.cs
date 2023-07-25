namespace WebApi.Authorization;

using VitrineUsadosAPI.Services;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUsuarioService usuarioService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token != null)
        {
            var usuario = await usuarioService.ValidarToken(token);
            if (usuario != null)
            {
                context.Items["Usuario"] = usuario;
            }
        }

        await _next(context);
    }
}