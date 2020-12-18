using lab2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication9.Models;
using lab2.Middleware;

namespace lab2
{
				public class Startup
				{
								public Startup(IConfiguration configuration)
								{
												Configuration = configuration;
								}
								public IConfiguration Configuration { get; }

								// This method gets called by the runtime. Use this method to add services to the container.
								// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
								public void ConfigureServices(IServiceCollection services)
								{
												services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["Data:SportsStoreProducts:ConnectionStrings"]));
												services.AddTransient<IProductRepository, EFProductRepository>();
												services.AddRazorPages();
								}

								// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
								public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
								{
												if (env.IsDevelopment())
												{
																app.UseDeveloperExceptionPage();
												}

												app.UseDeveloperExceptionPage();
												app.UseStatusCodePages();
												app.UseMyMiddleware();
												app.UseStaticFiles();
												app.UseRouting();

												app.UseEndpoints(routes =>
												{
																routes.MapControllerRoute(
																				name: "Admins",
																				pattern: "Admin/{action=Index}",
																				defaults: new
																				{
																								controller = "Admin",
																								action = "Index"
																				}
																				);
																routes.MapControllerRoute(
																				name: null,
																				pattern: "{controller=Product}/{action=List}/{id?}");
																routes.MapControllerRoute(
																				name: null,
																				pattern: "Product/{category}",
																				defaults: new 
																				{
																								controller = "Product",
																								action = "List" 
																				});
												});

												//app.UseEndpoints(endpoints =>
												//{
												//				endpoints.MapGet("/", async context =>
												//				{
												//								await context.Response.WriteAsync("Hello World!");
												//				});
												//});
												SeedData.EnsurePopulated(app);
								}
				}
}
