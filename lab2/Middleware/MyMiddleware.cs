using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace lab2.Middleware
{
				public class MyMiddleware
				{
								private readonly ILogger _logger;
								private readonly RequestDelegate _next;


								public MyMiddleware(ILogger<MyMiddleware> logger, RequestDelegate next)
								{
												_logger = logger;
												_next = next;
								}

								public async Task Invoke(HttpContext context)
								{
												var sw = new Stopwatch();
												sw.Start();
												await _next(context);
												var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
												if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
												{
																_logger.LogInformation($"{context.Request.Path} executed in {sw.ElapsedMilliseconds}ms");
												}
								}
				}

				public static class MyMiddlewareExtensions
				{
								public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
								{
												return builder.UseMiddleware<MyMiddleware>();
								}
				}
}
