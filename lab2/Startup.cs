using lab2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication9.Models;
using lab2.Middleware;
using lab2.Hubs;

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
												services.AddMvc();

												services.AddIdentity<IdentityUser, IdentityRole>()
																.AddEntityFrameworkStores<AppDbContext>()
																.AddDefaultTokenProviders();

												services.AddSwaggerGen();
												services.AddSignalR();
								}

								// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
								public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
								{
												if (env.IsDevelopment())
												{
																app.UseDeveloperExceptionPage();
												}

												app.UseSwagger();
												app.UseSwaggerUI(c =>
												{
																c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
																c.RoutePrefix = "api";
												});
												app.UseDeveloperExceptionPage();
												app.UseStatusCodePages();
												app.UseMyMiddleware();
												app.UseStaticFiles();
												app.UseRouting();

												app.UseAuthentication();
												app.UseAuthorization();

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
																				pattern: "{controller=Product}/{action=ListAll}"
																				);
																routes.MapControllerRoute(
																				name: null,
																				pattern: "Product/{category}",
																				defaults: new 
																				{
																								controller = "Product",
																								action = "List" 
																				});
																routes.MapHub<ChatHub>("/chathub");
																routes.MapHub<CounterHub>("/counterhub");
												});

												SeedData.EnsurePopulated(app);
								}
				}
}
